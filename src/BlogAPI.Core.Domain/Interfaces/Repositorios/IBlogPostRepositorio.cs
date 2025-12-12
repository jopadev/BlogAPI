using BlogAPI.Core.Domain.Entidades;

namespace BlogAPI.Core.Domain.Interfaces.Repositorios
{
    public interface IBlogPostRepositorio : IRepositorioBase<BlogPost>
    {
        Task<IEnumerable<BlogPost>> ObterTodosIncluindoComentarios();
        Task<bool> VerificarSeExisteCadastro(Guid id);
    }
}
