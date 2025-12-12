namespace BlogAPI.Core.Domain.Entidades
{
    public class Comment
    {
        public Guid ComentarioId { get; set; }
        public Guid PostId { get; set; }
        public virtual BlogPost Post { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
