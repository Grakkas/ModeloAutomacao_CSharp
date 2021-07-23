
namespace ModeloAutomacao_CSharp.Web.Steps
    {
    class AuthenticationScenarios
        {

        //Enum que servira como base para a indicação dos cenarios existentes
        public enum ListOfScenarios
            {
            RealizarLoginComSucesso,
            RealizarLoginComEmailInvalido,
            RealizarLoginComEmailVazio,
            RealizarLoginComSenhaInvalida,
            RealizarLoginComSenhaVazia
            }
        }
    }