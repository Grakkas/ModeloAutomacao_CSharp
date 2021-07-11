
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Web.Utils;
using OpenQA.Selenium;

namespace ModeloAutomacao_CSharp.Web.Pages
    {
    class AuthenticationPage
        {

        //Modelo de referenciamento para casos de validação
        public enum AuthenticationType
            {
            SUCCESSFULLY,
            PENDING_EMAIL,
            INVALID_EMAIL,
            PENDING_PASSWORD,
            INVALID_PASSWORD
            }

        //Implementação de Page Objects (Modelo CSharp) 
        public IWebElement TxtNavigationPage => DriverFactory.GetWebDriver().FindElement(By.ClassName("navigation_page"));
        public  IWebElement InputEmailAddress => DriverFactory.GetWebDriver().FindElement(By.Id("email"));
        public  IWebElement InputPassword => DriverFactory.GetWebDriver().FindElement(By.Id("passwd"));
        public  IWebElement BtnSubmitLogin => DriverFactory.GetWebDriver().FindElement(By.Id("SubmitLogin"));
        public  IWebElement TextAuthenticationError => DriverFactory.GetWebDriver().FindElement(By.XPath("//div[@class='alert alert-danger']//li"));
        
        //Metodo para realização de login, recebendo parametros, (Futuramente poderia ser feito um modelo de objeto Customer para reutilização e herança para o fluxo de cadastro
        public bool AuthenticateCustomer(string email, string password)
            {
            PageHelper.GetVisibleElement(InputEmailAddress, "InputEmailAddress").SendKeys(email);
            PageHelper.GetVisibleElement(InputPassword, "InputPassword").SendKeys(password);
            PageHelper.GetVisibleElement(BtnSubmitLogin, "BtnSubmitLogin").Click();
            return true;
            }

        //Método para validação do login, recebendo enum para identificação da mensagem esperada ou redirecionamento do usuario
        public bool ValidateAuthentication(AuthenticationType AuthenticationType)
            {
            switch (AuthenticationType)
                {
                case AuthenticationType.SUCCESSFULLY:
                    Assert.AreEqual(DriverFactory.GetWebDriver().Url, "http://automationpractice.com/index.php?controller=my-account");
                    Assert.AreEqual(PageHelper.GetVisibleElement(TxtNavigationPage, "TxtNavigationPage").Text, "My account");
                    return true;
                case AuthenticationType.PENDING_EMAIL:
                    Assert.AreEqual(PageHelper.GetVisibleElement(TextAuthenticationError, "TextAuthenticationError").Text, "An email address required.");
                    return true;
                case AuthenticationType.INVALID_EMAIL:
                    Assert.AreEqual(PageHelper.GetVisibleElement(TextAuthenticationError, "TextAuthenticationError").Text, "Invalid email address.");
                    return true;
                case AuthenticationType.PENDING_PASSWORD:
                    Assert.AreEqual(PageHelper.GetVisibleElement(TextAuthenticationError, "TextAuthenticationError").Text, "Password is required.");
                    return true;
                case AuthenticationType.INVALID_PASSWORD:
                    Assert.IsTrue(PageHelper.GetVisibleElement(TextAuthenticationError, "TextAuthenticationError").Text.Length> 0) ;
                    return true;
                default:
                    return false;
                }
            }
        }
    }
