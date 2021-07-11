using ModeloAutomacao_CSharp.Factory.Manager;
using OpenQA.Selenium;

namespace ModeloAutomacao_CSharp.Factory
    {

    #region Enum para seleção do navegador a ser utilizado nos testes
    enum DriverType
        {
        CHROME,
        FIREFOX
        }
    #endregion
    class DriverFactory
        {

        private static IWebDriver WebDriver = null;
        private static GoogleChromeManager GoogleChromeManager = null;
        private static MozilaFirefoxManager MozilaFirefoxManager = null;

        //Método utilizado para leitura das configurações bases dos navegadores e criação da sessão
        public static void SetDriverType(DriverType driverType)
            {
            switch (driverType)
                {
                case DriverType.CHROME:
                    if(GoogleChromeManager == null)
                        {
                        GoogleChromeManager = new GoogleChromeManager();
                        }
                    WebDriver = GoogleChromeManager.GetChromeDriver();
                    break;
                case DriverType.FIREFOX:
                    if(MozilaFirefoxManager == null)
                        {
                        MozilaFirefoxManager = new MozilaFirefoxManager();
                        }
                    WebDriver = MozilaFirefoxManager.GetFirefoxDriver();
                    break;
                default:
                    throw new WebDriverException("Error while trying to set the current WebDriver:");
                }
            WebDriver.Url = "http://automationpractice.com/";
            }

        //Função para recebimento do navegador em execução atual
        public static IWebDriver GetWebDriver()
            {
            return WebDriver;
            }

        //Função para finalização do navegador atual assim como suas configurações
        public static void CloseWebDriver()
            {
            if(WebDriver != null)
                {
                WebDriver.Dispose();
                WebDriver = null;
                GoogleChromeManager = null;
                MozilaFirefoxManager = null;
                }
            }
        }
    }
