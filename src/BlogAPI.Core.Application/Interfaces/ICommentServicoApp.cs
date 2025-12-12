using BlogAPI.Core.Application.Dtos;

namespace BlogAPI.Core.Application.Interfaces
{
    public interface ICommentServicoApp
    {
        Task<ResultadoCrudDto> AdicionarComentario(Guid postId, string comment);
    }

}
