namespace BlogAPI.Core.Application.Dtos
{
    public record PostCommand
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
    }


}
