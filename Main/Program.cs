
using ModeloAutomacao_CSharp.Web.Steps;

namespace ModeloAutomacao_CSharp.Main
    {
    class Program
        {
        static void Main(string[] args)
            {

            //Create an instance of the class passing the browser of wich will be used to execute the tests
            AuthenticationScenarios authenticationScenarios = new AuthenticationScenarios(Factory.DriverType.CHROME);
            HomeScenarios homeScenarios = new HomeScenarios(Factory.DriverType.CHROME);

            //Start the execution of the scenarios
            authenticationScenarios.StartScenariosExecution();
            homeScenarios.StartScenariosExecution();            
            }
        }
    }