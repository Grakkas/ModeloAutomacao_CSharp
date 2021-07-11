
using OpenQA.Selenium.Firefox;

namespace ModeloAutomacao_CSharp.Factory.Manager
    {
    class MozilaFirefoxManager
        {

        private FirefoxDriver firefoxDriver = null;

        //Função para criação da sesssão do navegador com suas configurações
        public FirefoxDriver GetFirefoxDriver()
            {
            if(firefoxDriver == null)
                {
                firefoxDriver = new FirefoxDriver(GetFirefoxOptions());
                }
            return firefoxDriver;
            }

        //Função privada para criação das configurações do navegador
        private FirefoxOptions GetFirefoxOptions()
            {
            FirefoxOptions firefoxOptions = new FirefoxOptions();

            return firefoxOptions;
            }
        }
    }
