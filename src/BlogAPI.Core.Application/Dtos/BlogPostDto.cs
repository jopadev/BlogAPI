namespace BlogAPI.Core.Application.Dtos
{
    public class BlogPostDto
    {
        public Guid PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
        public DateTime DataCadastro { get; set; }

        public BlogPostDto()
        {
            PostId = Guid.NewGuid();
            Comments = new HashSet<CommentDto>();
            DataCadastro = DateTime.Now;

        }

        public BlogPostDto(string titulo, string conteudo)
        {
            PostId = Guid.NewGuid();
            Comments = new HashSet<CommentDto>();
            DataCadastro = DateTime.Now;
            Titulo = titulo;
            Conteudo = conteudo;
        }
    }
}
