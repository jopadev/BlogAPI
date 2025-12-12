using AutoMapper;
using BlogAPI.Core.Application.Dtos;
using BlogAPI.Core.Application.Interfaces;
using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Servicos;
using BlogAPI.Core.Domain.Servicos;
using FluentValidation;

namespace BlogAPI.Core.Application.Servicos
{
    public class CommentServicoApp : ICommentServicoApp
    {
        private readonly IBlogPostServico _blogPostServico;
        private readonly ICommentServico _commentServico;
        private readonly IValidator<Comment> _commentValidador;
        private readonly IMapper _mapper;

        public CommentServicoApp(IBlogPostServico blogPostService, ICommentServico commentServico, IValidator<Comment> commentValidador, IMapper mapper)
        {
            _blogPostServico = blogPostService;
            _commentServico = commentServico;
            _commentValidador = commentValidador;
            _mapper = mapper;
        }

        public ValidacaoResultadoApp ValidarComment(Comment comment)
        {
            var oValidacaoResultado = _commentValidador.Validate(comment);

            var sErrorList = new List<string>();

            if (!oValidacaoResultado.IsValid)
                sErrorList = oValidacaoResultado.Errors.Select(x => x.ErrorMessage).ToList();

            return new ValidacaoResultadoApp(oValidacaoResultado.IsValid, sErrorList);
        }

        public async Task<CommentDto> Adicionar(CommentDto dto)
        {
            var oComment = _mapper.Map<CommentDto, Comment>(dto);

            await _commentServico.Adicionar(oComment);

            return dto;
        }

        public async Task<ResultadoCrudDto> AdicionarComentario(Guid postId, string comentario)
        {
            if (!await _blogPostServico.VerificarSeExisteCadastro(postId))
                return new ResultadoCrudDto(false, "O post informado não existe.");

            try
            {
                var oCommentDto = new CommentDto() { PostId = postId, Conteudo = comentario };

                var oValidacaoResultadoApp = ValidarComment(_mapper.Map<CommentDto, Comment>(oCommentDto));

                if (!oValidacaoResultadoApp.Valido)
                    return new ResultadoCrudDto(false, string.Join(",", oValidacaoResultadoApp.Erros));

                await Adicionar(oCommentDto);

                return new ResultadoCrudDto(true, "Comentário adicionado com sucesso!!!");
            }
            catch (Exception ex)
            {
                return new ResultadoCrudDto(false, ex.Message);
            }
        }
    }

}
