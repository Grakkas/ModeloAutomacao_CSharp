
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Model;
using ModeloAutomacao_CSharp.Web.Pages;
using ModeloAutomacao_CSharp.Web.Utils;
using System;

namespace ModeloAutomacao_CSharp.Web.Steps
    {
    class AuthenticationScenarios
        {

        private readonly DriverType DriverType;
        private readonly AuthenticationPage authenticationPage;
        private readonly HomePage homePage;

        //Enum that serves as a list of all the scenarios that will be executed
        private enum ListOfScenarios
            {
            RealizarLoginComSucesso,
            RealizarLoginComEmailInvalido,
            RealizarLoginComEmailVazio,
            RealizarLoginComSenhaInvalida,
            RealizarLoginComSenhaVazia
            }

        public AuthenticationScenarios(DriverType driverType)
            {
            this.DriverType = driverType;
            homePage = new HomePage();
            authenticationPage = new AuthenticationPage();
            }

        //Method that will be called to execute all the scenarios found on the Enum ListOfScenarios
        //To create a new test you just need to specify it on the Enum, and create an case for it
        public void StartScenariosExecution()
            {
            foreach (ListOfScenarios scenario in (ListOfScenarios[])Enum.GetValues(typeof(ListOfScenarios)))
                {
                DriverFactory.SetDriverType(DriverType);
                Logger.Log($"|__ Starting the test {scenario} __|");
                switch (scenario)
                    {
                    case ListOfScenarios.RealizarLoginComSucesso:
                        try
                            {
                            CustomerModel customer = new CustomerModel("gabriel.silva@auditeste.com.br", "123456");
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer(customer));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.SUCCESSFULLY));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED", authenticationPage.TxtNavigationPage, "authenticationPage.TxtNavigationPage");
                            Logger.Log("***** Test Executed with Success *****");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source} *****");
                            }
                        break;

                    case ListOfScenarios.RealizarLoginComEmailInvalido:
                        try
                            {
                            CustomerModel customer = new CustomerModel("invalid_email", "123456");
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer(customer));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED", authenticationPage.TextAuthenticationError, "authenticationPage.TextAuthenticationError");
                            Logger.Log("***** Test Executed with Success *****");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source} *****");
                            }
                        break;

                    case ListOfScenarios.RealizarLoginComEmailVazio:
                        try
                            {
                            CustomerModel customer = new CustomerModel("", "123456");
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer(customer));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_EMAIL));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED", authenticationPage.TextAuthenticationError, "authenticationPage.TextAuthenticationError");
                            Logger.Log("***** Test Executed with Success *****");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source} *****");
                            }
                        break;

                    case ListOfScenarios.RealizarLoginComSenhaInvalida:
                        try
                            {
                            CustomerModel customer = new CustomerModel("gabriel.silva@auditeste.com.br", "invalid_password");
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer(customer));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.INVALID_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED", authenticationPage.TextAuthenticationError, "authenticationPage.TextAuthenticationError");
                            Logger.Log("***** Test Executed with Success *****");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source} *****");
                            }
                        break;

                    case ListOfScenarios.RealizarLoginComSenhaVazia:
                        try
                            {
                            CustomerModel customer = new CustomerModel("gabriel.silva@auditeste.com.br", "");
                            Assert.IsTrue(homePage.GoToAuthenticationPage());
                            Assert.IsTrue(authenticationPage.AuthenticateCustomer(customer));
                            Assert.IsTrue(authenticationPage.ValidateAuthentication(AuthenticationPage.AuthenticationType.PENDING_PASSWORD));
                            PageHelper.TakeScreenshot($"{scenario}_PASSED", authenticationPage.TextAuthenticationError, "authenticationPage.TextAuthenticationError");
                            Logger.Log("***** Test Executed with Success *****");
                            }
                        catch (Exception e)
                            {
                            PageHelper.TakeScreenshot($"{scenario}_FAILED");
                            Logger.Log($"***** There was an error while executing the test: {e.Message} ::: {e.Source} *****");
                            }
                        break;

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