
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Model;
using ModeloAutomacao_CSharp.Web.Pages;
using ModeloAutomacao_CSharp.Web.Utils;
using System;
using System.Collections.Generic;

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
                Logger.Log($"|__ Starting the test {scenario}");
                switch (scenario)
                    {

                    case ListOfScenarios.AddSingleProductToCart:
                        try
                            {
                            List<ProductModel> products = new List<ProductModel>
                                {
                                new ProductModel("Faded Short Sleeve T-shirts")
                                };
                            Assert.IsTrue(homePage.AddProductToCart(products));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source}");
                            }
                        break;

                    case ListOfScenarios.AddMultipleProductsToCart:
                        try
                            {
                            List<ProductModel> products = new List<ProductModel>
                                {
                                new ProductModel("Faded Short Sleeve T-shirts"),
                                new ProductModel("Printed Chiffon Dress"),
                                new ProductModel("Printed Summer Dress")
                                };
                            Assert.IsTrue(homePage.AddProductToCart(products));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source}");
                            }
                        break;

                    default:
                        Logger.Log($"***** You tried to execute an scenario without specifying the case for it: {scenario}");
                        break;
                    }
                DriverFactory.CloseWebDriver();
                Logger.Log($"|__ End of the test: {scenario}");
                }
            }
        }
    }