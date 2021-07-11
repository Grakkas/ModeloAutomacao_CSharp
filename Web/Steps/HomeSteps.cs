
namespace ModeloAutomacao_CSharp.Web.Steps
    {
    class HomeSteps
        {

        public enum ListOfScenarios
            {
            AddSingleProductToCart,
            AddMultipleProductsToCart
            }

        public string ScenarioName { get; set; }
        public string ScenarioMessage { get; set; }
        public bool ScenarioStatus { get; set; }

        public HomeSteps(ListOfScenarios CurrentScenario, string ScenarioMessage, bool ScenarioStatus)
            {
            ScenarioName = CurrentScenario.ToString();
            this.ScenarioMessage = ScenarioMessage;
            this.ScenarioStatus = ScenarioStatus;
            }

        public string UpdateScenarioInfo(string message, bool status)
            {
            ScenarioMessage = message;
            ScenarioStatus = status;
            return GetScenarioInfo();
            }

        public string GetScenarioInfo()
            {
            return $"Scenario Name: {ScenarioName}, Current Status: {ScenarioStatus}, Current Message: {ScenarioMessage}";
            }
        }
    }