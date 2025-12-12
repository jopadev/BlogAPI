namespace BlogAPI.Core.Application.Dtos
{
    public record PostBlogResumoDto
    {
        public Guid PostId { get; set; }
        public string Titulo { get; set; }
        public int NumeroComentarios { get; set; }
    }


}
