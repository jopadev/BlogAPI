using System.Linq.Expressions;

namespace BlogAPI.Core.Domain.Interfaces.Servicos
{
    public interface IServicoBase<T> where T : class
    {
        Task<T> Adicionar(T entity);
        Task<T> Atualizar(T entity);
        Task<T> Apagar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> EncontrarPor(Expression<Func<T, bool>> predicate);
    }

}
