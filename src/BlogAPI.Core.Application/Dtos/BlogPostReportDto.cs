namespace BlogAPI.Core.Application.Dtos
{
    public class BlogPostReportDto
    {
        public Guid PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public virtual IEnumerable<CommentReportDto> Comentarios { get; set; }
    }


}
