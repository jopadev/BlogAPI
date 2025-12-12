using AutoMapper;
using BlogAPI.Core.Application.Dtos;
using BlogAPI.Core.Application.Interfaces;
using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Servicos;
using FluentValidation;

namespace BlogAPI.Core.Application.Servicos
{
    public class BlogPostServicoApp : IBlogPostServicoApp
    {
        private readonly IBlogPostServico _blogPostServico;
        private readonly IMapper _mapper;
        private readonly IValidator<BlogPost> _postBlogValidador;

        public BlogPostServicoApp(IBlogPostServico blogPostServico, IMapper mapper, IValidator<BlogPost> postBlogValidador)
        {
            _blogPostServico = blogPostServico;
            _mapper = mapper;
            _postBlogValidador = postBlogValidador;
        }

        public ValidacaoResultadoApp ValidarBlogPost(BlogPost blogPost)
        {
            var oValidacaoResultado = _postBlogValidador.Validate(blogPost);

            var sErrorList = new List<string>();

            if (!oValidacaoResultado.IsValid)
                sErrorList = oValidacaoResultado.Errors.Select(x => x.ErrorMessage).ToList();

            return new ValidacaoResultadoApp(oValidacaoResultado.IsValid, sErrorList);
        }

        public async Task<ResultadoCrudDto> Adicionar(BlogPostDto dto)
        {
            try
            {
                var oBlogPost = _mapper.Map<BlogPostDto, BlogPost>(dto);

                var oValidacaoResultadoApp = ValidarBlogPost(oBlogPost);

                if (!oValidacaoResultadoApp.Valido)
                    return new ResultadoCrudDto(false, string.Join(",", oValidacaoResultadoApp.Erros));

                await _blogPostServico.Adicionar(oBlogPost);

                return new ResultadoCrudDto(true, "Post adicionado com sucesso!!!");
            }
            catch (Exception ex)
            {
                return new ResultadoCrudDto(false, ex.Message);
            }
        }

        public async Task<IEnumerable<PostBlogResumoDto>> ObterTodosResumo()
        {
            var oBlogPostList = await _blogPostServico.ObterTodosIncluindoComentarios();

            return oBlogPostList.Select(x => new PostBlogResumoDto
            {
                PostId = x.PostId,
                Titulo = x.Titulo,
                NumeroComentarios = x.Comments.Count,
            });
        }

        public async Task<BlogPostReportDto> ObterPorId(Guid id)
        {
            var oBlogPost = await _blogPostServico.ObterPorId(id);

            var oBlogPostReportDto = new BlogPostReportDto
            {
                PostId = oBlogPost.PostId,
                Titulo = oBlogPost.Titulo,
                Conteudo = oBlogPost.Conteudo,
                Comentarios = oBlogPost.Comments.Select(x => new CommentReportDto
                {
                    Conteudo = x.Conteudo,
                })
            };

            return oBlogPostReportDto;
        }
    }
}
