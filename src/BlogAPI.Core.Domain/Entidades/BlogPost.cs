namespace BlogAPI.Core.Domain.Entidades
{
    public class BlogPost
    {
        public Guid PostId { get; set; }
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public DateTime DataCadastro { get; set; }
    }
}
