using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Repositorios;
using BlogAPI.Core.Domain.Interfaces.Repositorios.SomenteLeitura;
using BlogAPI.Core.Domain.Interfaces.Servicos;

namespace BlogAPI.Core.Domain.Servicos
{
    public class BlogPostServico : ServicoBase<BlogPost>, IBlogPostServico
    {
        private readonly IBlogPostRepositorio _blogPostRepositorio;
        private readonly IBlogPostRepositorioSomenteLeitura _blogPostRepositorioSomenteLeitura;
        public BlogPostServico(IBlogPostRepositorio blogPostRepositorio, IBlogPostRepositorioSomenteLeitura blogPostRepositorioSomenteLeitura) : base(blogPostRepositorio)
        {
            _blogPostRepositorio = blogPostRepositorio;
            _blogPostRepositorioSomenteLeitura = blogPostRepositorioSomenteLeitura;
        }

        public async Task<IEnumerable<BlogPost>> ObterTodosIncluindoComentarios()
        {
            return await _blogPostRepositorio.ObterTodosIncluindoComentarios();
        }

        public async Task<BlogPost> ObterPorId(Guid id, bool readOnly = true)
        {
            return readOnly ? await _blogPostRepositorioSomenteLeitura.ObterPorId(id) : await _blogPostRepositorio.ObterPorId(id);
        }

        public async Task<bool> VerificarSeExisteCadastro(Guid id)
        {
            return await _blogPostRepositorio.VerificarSeExisteCadastro(id);
        }
    }
}
