using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Repositorios;

namespace BlogAPI.Core.Domain.Servicos
{
    public class CommentServico : ServicoBase<Comment>, ICommentServico
    {
        private readonly ICommentRepositorio _commentRepositorio;

        public CommentServico(ICommentRepositorio commentRepositorio) : base(commentRepositorio)
        {

        }
    }


}
