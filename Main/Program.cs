
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
            foreach (HomeScenarios.ListOfScenarios scenario in (HomeScenarios.ListOfScenarios[])Enum.GetValues(typeof(HomeScenarios.ListOfScenarios)))
                {
                Logger.log($"###Initializing the scenario: {scenario}####");
                DriverFactory.SetDriverType(DriverType.CHROME);
                HomePage homePage = new HomePage();
                switch (scenario)
                    {
                    //Example of how to implement an scenario execution
                    case HomeScenarios.ListOfScenarios.AddSingleProductToCart:
                        try
                            {
                            Assert.IsTrue(homePage.CleanCart());
                            string[] ListOfProducts = { "Faded Short Sleeve T-shirts" };
                            Assert.IsTrue(homePage.AddProductToCart(ListOfProducts));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success", true);
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }

                    case HomeScenarios.ListOfScenarios.AddMultipleProductsToCart:
                        try
                            {
                            Assert.IsTrue(homePage.CleanCart());
                            string[] ListOfProducts = { "Printed Chiffon Dress", "Blouse", "Printed Dress" };
                            Assert.IsTrue(homePage.AddProductToCart(ListOfProducts));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }
                    default:
                        throw new ArgumentException("Scenario not found, did you registered it on the enum list and made an case for it ?");
                    }
                Logger.log($"End of Execution for Scenario: {scenario}");
                DriverFactory.CloseWebDriver();
                }
            #endregion

            #region Execute all the scenarios found on the AuthenticationSteps Enum called ListOfScenarios
            foreach (AuthenticationScenarios.ListOfScenarios scenario in (AuthenticationScenarios.ListOfScenarios[])Enum.GetValues(typeof(AuthenticationScenarios.ListOfScenarios)))
                {
                Logger.log($"###Initializing the scenario: {scenario}####");
                DriverFactory.SetDriverType(DriverType.CHROME);
                HomePage homePage = new HomePage();
                AuthenticationPage authenticationPage = new AuthenticationPage();
                switch (scenario)
                    {
                    case AuthenticationScenarios.ListOfScenarios.RealizarLoginComSucesso:
                        try
                            {
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.SUCCESSFULLY));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }

                    case AuthenticationScenarios.ListOfScenarios.RealizarLoginComEmailInvalido:
                        try
                            {
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("invalid", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}, Stacktrace: {e.StackTrace}");
                            break;
                            }

                    case AuthenticationScenarios.ListOfScenarios.RealizarLoginComEmailVazio:
                        try
                            {
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("", "123456"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }

                    case AuthenticationScenarios.ListOfScenarios.RealizarLoginComSenhaInvalida:
                        try
                            {
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", "invalid"));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }

                    case AuthenticationScenarios.ListOfScenarios.RealizarLoginComSenhaVazia:
                        try
                            {
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer("gabriel.silva@auditeste.com.br", ""));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED");
                            Logger.log("Scenario executed with success");
                            break;
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.log($"Scenario executed with problems: {e.Message}");
                            break;
                            }
                    default:
                        throw new ArgumentException("Scenario not found, did you registered it on the enum list and made an case for it ?");
                    }
                Logger.log($"End of Execution for Scenario: {scenario}");
                DriverFactory.CloseWebDriver();
                }
            #endregion
            }

        }
    }