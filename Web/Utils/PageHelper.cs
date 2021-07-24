
using ModeloAutomacao_CSharp.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace ModeloAutomacao_CSharp.Web.Utils
    {
    class PageHelper
        {

        //Função privada para criação do modo de espera dinamica
        private static DefaultWait<IWebDriver> DefaultWait()
            {
            DefaultWait<IWebDriver> DefaultWait = new DefaultWait<IWebDriver>(DriverFactory.GetWebDriver())
                {
                Timeout = TimeSpan.FromSeconds(8),
                PollingInterval = TimeSpan.FromSeconds(1)
                };
            DefaultWait.IgnoreExceptionTypes
                (
                typeof(Exception)
                );
            return DefaultWait;
            }

        //Método que aguarda o elemento estar visivel e move até o mesmo, retornando o elemento no seu estado manipulavel
        public static IWebElement GetVisibleElement(IWebElement element, string description)
            {
            try
                {
#pragma warning disable CS0618 // Type or member is obsolete
                DefaultWait().Until<IWebElement>(ExpectedConditions.ElementToBeClickable(element));
#pragma warning restore CS0618 // Type or member is obsolete
                MoveToElement(element, description);
                return element;
                }
            catch (Exception e)
                {
                throw new NoSuchElementException($"There was an error while trying to find the element: {description} within 8sec.");
                }
            }

        //Método para mover a algum elemento (MouseOver)
        public static void MoveToElement(IWebElement element, string description)
            {
            try
                {
                Actions actions = new Actions(DriverFactory.GetWebDriver());
                ((IJavaScriptExecutor)DriverFactory.GetWebDriver()).ExecuteScript("window.scroll(" + element.Location.X + "," + (element.Location.Y - 200) + ");");
                actions.MoveToElement(element).Build().Perform();
                }
            catch (Exception e)
                {
                throw new ArgumentOutOfRangeException($"Error while trying to move to the following element: {description}.");
                }
            }

        //Método que cria uma evidencia no formato de imagem, que será salvo na pasta de execução
        public static void TakeScreenshot(string ScenarioName)
            {
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Screenshots/");
            string date = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
            string mainPath = $"{Directory.GetCurrentDirectory()}/Screenshots/";
            ITakesScreenshot screenshotDriver = DriverFactory.GetWebDriver() as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile($"{mainPath}{ScenarioName}_{date}.png");
            }
        }
    }