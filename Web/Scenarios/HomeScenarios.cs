
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Web.Pages;
using ModeloAutomacao_CSharp.Web.Utils;
using System;

namespace ModeloAutomacao_CSharp.Web.Steps
    {
    class HomeScenarios
        {
        private readonly DriverType DriverType;
        private readonly HomePage homePage;

        public HomeScenarios(DriverType driverType)
            {
            DriverType = driverType;
            homePage = new HomePage();
            }

        public enum ListOfScenarios
            {
            AddSingleProductToCart,
            AddMultipleProductsToCart
            }
        public void StartScenariosExecution()
            {
            foreach (ListOfScenarios scenario in (ListOfScenarios[])Enum.GetValues(typeof(ListOfScenarios)))
                {
                DriverFactory.SetDriverType(DriverType);
                Logger.Log($"|__ Starting the test {scenario} __|");
                switch (scenario)
                    {



                    default:
                        Logger.Log($"***** You tried to execute an scenario without specifying the case for it: {scenario} *****");
                        break;
                    }
                DriverFactory.CloseWebDriver();
                Logger.Log($"|__ End of the test: {scenario} __|");
                }
            }
        }
    }