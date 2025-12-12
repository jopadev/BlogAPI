namespace BlogAPI.Core.Application.Dtos
{
    public class ValidacaoResultadoApp
    {
        public bool Valido { get; set; }
        public List<string> Erros { get; set; }
        public ValidacaoResultadoApp()
        {

        }

        public ValidacaoResultadoApp(bool valido, List<string> erros)
        {
            Valido = valido;
            Erros = erros;
        }
    }
}
