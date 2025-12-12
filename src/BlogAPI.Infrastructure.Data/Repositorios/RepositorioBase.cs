using BlogAPI.Core.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogAPI.Infrastructure.Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public BlogAPIContexto _contexto;
        public DbSet<T> Set;

        public RepositorioBase(BlogAPIContexto contexto)
        {
            _contexto = contexto;
            Set = contexto.Set<T>();
        }

        public async Task<T> Adicionar(T entity)
        {
            await Set.AddAsync(entity);
            await _contexto.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Atualizar(T entity)
        {
            await Task.Run(() => Set.Update(entity));
            await _contexto.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Apagar(T entity)
        {
            await Task.Run(() => Set.Remove(entity));
            await _contexto.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _contexto.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> EncontrarPor(Expression<Func<T, bool>> predicate)
        {
            return await _contexto.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
