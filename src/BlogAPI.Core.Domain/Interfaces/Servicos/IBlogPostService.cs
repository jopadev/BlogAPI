using BlogAPI.Core.Domain.Entidades;

namespace BlogAPI.Core.Domain.Interfaces.Servicos
{
    public interface IBlogPostServico : IServicoBase<BlogPost>
    {
        Task<BlogPost> ObterPorId(Guid id, bool readOnly = true);
        Task<IEnumerable<BlogPost>> ObterTodosIncluindoComentarios();
        Task<bool> VerificarSeExisteCadastro(Guid id);
    }

}
