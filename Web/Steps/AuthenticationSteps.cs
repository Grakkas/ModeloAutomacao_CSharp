
namespace ModeloAutomacao_CSharp.Web.Steps
    {
    class AuthenticationSteps
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

        //Propriedades que o cenário contem para ser adicionada em logs etc 
        public string ScenarioName { get; set; }
        public string ScenarioMessage { get; set; }
        public bool ScenarioStatus { get; set; }

        //Construtor para criação do ouvinte do cenário
        public AuthenticationSteps(ListOfScenarios CurrentScenario, string ScenarioMessage, bool ScenarioStatus)
            {
            ScenarioName = CurrentScenario.ToString();
            this.ScenarioMessage = ScenarioMessage;
            this.ScenarioStatus = ScenarioStatus;
            }

        //Método para utilização das informações do cenário que retorna o status atualizado
        public string UpdateScenarioInfo(string message, bool status)
            {
            ScenarioMessage = message;
            ScenarioStatus = status;
            return GetScenarioInfo();
            }

        //Método para receber as informações do cenario como string
        public string GetScenarioInfo()
            {
            return $"Scenario Name: {ScenarioName}, Current Status: {ScenarioStatus}, Current Message: {ScenarioMessage}";
            }
        }
    }