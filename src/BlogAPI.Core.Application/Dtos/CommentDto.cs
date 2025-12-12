namespace BlogAPI.Core.Application.Dtos
{
    public class CommentDto
    {
        public Guid ComentarioId { get; set; }
        public Guid PostId { get; set; }
        public virtual BlogPostDto Post { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Conteudo { get; set; }

        public CommentDto()
        {
            ComentarioId = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }


}
