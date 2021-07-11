
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAutomacao_CSharp.Factory;
using ModeloAutomacao_CSharp.Web.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ModeloAutomacao_CSharp.Web.Pages
    {
    class HomePage
        {

        //Implementação de Page Object (Modelo CSHarp)
        public IWebElement TxtNavigationPage => DriverFactory.GetWebDriver().FindElement(By.ClassName("navigation_page"));
        public IWebElement BtnSignIn => DriverFactory.GetWebDriver().FindElement(By.XPath("//a[@class='login'][contains(.,'Sign in')]"));
        public IWebElement BtnCart => DriverFactory.GetWebDriver().FindElement(By.XPath("//a[@title='View my shopping cart']"));
        public IWebElement BtnRemoveCartItem => DriverFactory.GetWebDriver().FindElement(By.XPath("//a[@title='remove this product from my cart']"));
        public IWebElement BtnCheckout => DriverFactory.GetWebDriver().FindElement(By.XPath("//span[contains(.,'Check out')]"));
        public IList<IWebElement> ListOfProductsInHome => DriverFactory.GetWebDriver().FindElements(By.XPath("//div[@class='right-block']"));
        public IWebElement CardProductAddedToCart => DriverFactory.GetWebDriver().FindElement(By.Id("layer_cart"));
        public IWebElement BtnProceedToCheckout => DriverFactory.GetWebDriver().FindElement(By.XPath("(//span[contains(.,'Proceed to checkout')])[2]"));

        //Função para redirecionar o usuário para a tela de autenticação
        public bool GoToAuthenticationPage()
            {
            PageHelper.GetVisibleElement(BtnSignIn, "BtnSignIn").Click();
            Assert.AreEqual(PageHelper.GetVisibleElement(TxtNavigationPage, "TxtNavigationPage").Text.ToLower(), "authentication");
            return true;
            }

        //Método para adição de multiplos produtos no carrinho, vindo de uma Array de Strings (podendo conter tanto o nome do produto quanto o valor)
        //Ponto de melhoria: Recebimento de um array bidimensional com o nome e produto para melhor seleção do produto, pois existem produtos com os mesmos nomes
        public bool AddProductToCart(string[] ListOfProductsToAdd)
            {
            //Iteração para a lista de produtos a serem adicionadas ao carrinho
            foreach (string productToAdd in ListOfProductsToAdd)
                {
                //Iteração sobre a lista de produtos encontradas na pagina home
                foreach (IWebElement productInList in ListOfProductsInHome)
                    {
                    //Verificação do produto a ser adicionado com as informações do produto na pagina
                    if (productInList.Text.Contains(productToAdd))
                        {
                        PageHelper.MoveToElement(productInList, "productInList");
                        productInList.FindElement(By.XPath(".//span[contains(.,'Add to cart')]")).Click();
                        PageHelper.GetVisibleElement(CardProductAddedToCart, "TxtProductAddedToCart");
                        CardProductAddedToCart.FindElement(By.XPath(".//span[contains(.,'Continue shopping')]")).Click();
                        }
                    }
                }
            //Jornada para ir ao checkout após adição de todos os itens no carrinho (poderia ser uma função apartada)
            PageHelper.MoveToElement(BtnCart, "BtnCart");
            PageHelper.GetVisibleElement(BtnCheckout, "BtnCheckout").Click();
            PageHelper.GetVisibleElement(BtnProceedToCheckout, "BtnProceedToCheckout");
            return true;
            }

        //Função para limpeza do carrinho atual, caso haja algum problema com o cache ou o usuário contenha um carrinho existente
        public bool CleanCart()
            {
            string cartItems = PageHelper.GetVisibleElement(BtnCart, "BtnCart").Text;
            while (!cartItems.Contains("empty"))
                {
                PageHelper.MoveToElement(BtnCart, "BtnCart");
                PageHelper.GetVisibleElement(BtnRemoveCartItem, "BtnRemoveCartItem").Click();
                cartItems = PageHelper.GetVisibleElement(BtnCart, "BtnCart").Text;
                }
            return true;
            }
        }
    }
