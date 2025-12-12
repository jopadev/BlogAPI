using BlogAPI.Core.Domain.Interfaces.Repositorios;
using BlogAPI.Core.Domain.Interfaces.Servicos;
using System.Linq.Expressions;

namespace BlogAPI.Core.Domain.Servicos
{
    public class ServicoBase<T> : IServicoBase<T> where T : class
    {
        private readonly IRepositorioBase<T> _repository;

        public ServicoBase(IRepositorioBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Adicionar(T entity)
        {
            return await _repository.Adicionar(entity);
        }

        public async Task<T> Atualizar(T entity)
        {
            return await _repository.Atualizar(entity);
        }

        public async Task<T> Apagar(T entity)
        {
            return await _repository.Apagar(entity);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task<IEnumerable<T>> EncontrarPor(Expression<Func<T, bool>> predicate)
        {
            return await _repository.EncontrarPor(predicate);
        }
    }
}
