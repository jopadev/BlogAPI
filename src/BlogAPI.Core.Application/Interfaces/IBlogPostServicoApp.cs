using BlogAPI.Core.Application.Dtos;

namespace BlogAPI.Core.Application.Interfaces
{
    public interface IBlogPostServicoApp
    {
        Task<ResultadoCrudDto> Adicionar(BlogPostDto dto);
        Task<IEnumerable<PostBlogResumoDto>> ObterTodosResumo();
        Task<BlogPostReportDto> ObterPorId(Guid id);
    }

}
