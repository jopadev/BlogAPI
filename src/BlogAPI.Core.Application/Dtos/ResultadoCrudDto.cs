namespace BlogAPI.Core.Application.Dtos
{
    public class ResultadoCrudDto
    {
        public bool Sucesso { get; set; }
        public string Resultado { get; set; } = string.Empty;

        public ResultadoCrudDto()
        {

        }

        public ResultadoCrudDto(bool sucesso, string resultado)
        {
            Sucesso = sucesso;
            Resultado = resultado;
        }
    }


}
