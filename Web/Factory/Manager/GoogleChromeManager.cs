
using OpenQA.Selenium.Chrome;

namespace ModeloAutomacao_CSharp.Factory.Manager
    {
    class GoogleChromeManager
        {

        private ChromeDriver chromeDriver = null;

        //Função para criação da sesssão do navegador com suas configurações
        public ChromeDriver GetChromeDriver()
            {
            if (chromeDriver == null) 
                {
                chromeDriver = new ChromeDriver(GetChromeOptions());
                }
            return chromeDriver;
            }

        //Função privada para criação das configurações do navegador
        private ChromeOptions GetChromeOptions()
            {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments
                (
                "test-type",
                "start-maximized",
                "ignore-certificate-errors",
                "disable-infobar",
                "headless"
                );
            return chromeOptions;
            }
        }
    }
