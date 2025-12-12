using BlogAPI.Core.Domain.Entidades;

namespace BlogAPI.Core.Domain.Interfaces.Repositorios.SomenteLeitura
{
    public interface IBlogPostRepositorioSomenteLeitura
    {
        Task<BlogPost> ObterPorId(Guid id);
    }
}
