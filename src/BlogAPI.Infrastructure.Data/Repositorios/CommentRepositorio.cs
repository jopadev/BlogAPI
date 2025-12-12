using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Repositorios;

namespace BlogAPI.Infrastructure.Data.Repositorios
{
    public class CommentRepositorio : RepositorioBase<Comment>, ICommentRepositorio
    {
        public CommentRepositorio(BlogAPIContexto context)
           : base(context)
        {
        }
    }

}
