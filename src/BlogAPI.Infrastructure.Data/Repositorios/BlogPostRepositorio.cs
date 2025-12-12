using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data.Repositorios
{
    public class BlogPostRepositorio : RepositorioBase<BlogPost>, IBlogPostRepositorio
    {
        public BlogPostRepositorio(BlogAPIContexto context)
           : base(context)
        {
        }

        public async Task<IEnumerable<BlogPost>> ObterTodosIncluindoComentarios()
        {
            return await _contexto.Set<BlogPost>().Include(x => x.Comments).ToListAsync();
        }

        public async Task<bool> VerificarSeExisteCadastro(Guid id)
        {
            return await _contexto.Set<BlogPost>().AnyAsync(x => x.PostId == id);
        }
    }


}
