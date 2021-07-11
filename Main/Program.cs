
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Web.Pages;
using ModeloAutomacao_CSharp.Web.Steps;
using ModeloAutomacao_CSharp.Web.Utils;
using System;

namespace ModeloAutomacao_CSharp.Main
    {
    class Program
        {
        static void Main(string[] args)
            {
            Logger.log("*** Starting automation execution ***");
            #region Execute all the scenarios found on the HomeSteps Enum called ListOfScenarios
            foreach (HomeSteps.ListOfScenarios scenario in (HomeSteps.ListOfScenarios[])Enum.GetValues(typeof(HomeSteps.ListOfScenarios)))
                {
                DriverFactory.SetDriverType(DriverType.CHROME);
                HomeSteps homeSteps = new HomeSteps(scenario, $"### Starting Execution From Scenario:  {scenario} ###" , false);
                HomePage homePage = new HomePage();
                switch (scenario)
                    {
                    //Example of how to implement an scenario execution
                    case HomeSteps.ListOfScenarios.AddSingleProductToCart:
                        try
                            {
                            Logger.log(homeSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.CleanCart());
                            string[] ListOfProducts = { "Faded Short Sleeve T-shirts" };
                            Logger.log(homeSteps.UpdateScenarioInfo($"Adding products to cart {ListOfProducts}", false));
                            Assert.IsTrue(homePage.AddProductToCart(ListOfProducts));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(homeSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(homeSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }

                    case HomeSteps.ListOfScenarios.AddMultipleProductsToCart:
                        try
                            {
                            Logger.log(homeSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.CleanCart());
                            string[] ListOfProducts = { "Printed Chiffon Dress", "Blouse", "Printed Dress" };
                            Logger.log(homeSteps.UpdateScenarioInfo($"Adding products to cart {ListOfProducts}", false));
                            Assert.IsTrue(homePage.AddProductToCart(ListOfProducts));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(homeSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(homeSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }
                    default:
                        throw new ArgumentException("Scenario not found, did you registered it on the enum list and made an case for it ?");
                    }
                DriverFactory.CloseWebDriver();
                }
            //banho shitzu valor
            #endregion

            #region Execute all the scenarios found on the AuthenticationSteps Enum called ListOfScenarios
            foreach (AuthenticationSteps.ListOfScenarios scenario in (AuthenticationSteps.ListOfScenarios[])Enum.GetValues(typeof(AuthenticationSteps.ListOfScenarios)))
                {
                AuthenticationSteps authenticationSteps = new AuthenticationSteps(scenario, $"### Starting Execution From Scenario: {scenario} ###", false);
                DriverFactory.SetDriverType(DriverType.CHROME);
                HomePage homePage = new HomePage();
                AuthenticationPage authenticationPage = new AuthenticationPage();
                switch (scenario)
                    {
                    case AuthenticationSteps.ListOfScenarios.RealizarLoginComSucesso:
                        try
                            {
                            Logger.log(authenticationSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.SUCCESSFULLY));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }

                    case AuthenticationSteps.ListOfScenarios.RealizarLoginComEmailInvalido:
                        try
                            {
                            Logger.log(authenticationSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("invalid", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }

                    case AuthenticationSteps.ListOfScenarios.RealizarLoginComEmailVazio:
                        try
                            {
                            Logger.log(authenticationSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }

                    case AuthenticationSteps.ListOfScenarios.RealizarLoginComSenhaInvalida:
                        try
                            {
                            Logger.log(authenticationSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", "invalid"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }

                    case AuthenticationSteps.ListOfScenarios.RealizarLoginComSenhaVazia:
                        try
                            {
                            Logger.log(authenticationSteps.GetScenarioInfo());
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", ""));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo("Scenario executed with success", true));
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log(authenticationSteps.UpdateScenarioInfo($"Scenario executed with problems: {e.Message}", false));
                            break;
                            }
                    default:
                        throw new ArgumentException("Scenario not found, did you registered it on the enum list and made an case for it ?");
                    }
                DriverFactory.CloseWebDriver();
                Logger.log(" *** End of auomation execution ***");
                }
            #endregion
            }
        }
    }