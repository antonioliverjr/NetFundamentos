using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Auto_Linkedin
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver seleniumSite = new ChromeDriver("C:\\");

            seleniumSite.Url = "https://www.selenium.dev/pt-br/documentation/webdriver/";

            Thread.Sleep(5000);

            seleniumSite.SwitchTo().NewWindow(WindowType.Tab);

            LinkedinAcesso(seleniumSite);
        }

        public static void LinkedinAcesso(IWebDriver seleniumSite)
        {
            //IWebDriver driver = new ChromeDriver("C:\\");

            IWebDriver driver = seleniumSite;

            driver.Url = "https://www.linkedin.com/login";

            driver.FindElement(By.Id("username")).SendKeys("antoniobatistajr@gmail.com");

            driver.FindElement(By.Id("password")).SendKeys("" + Keys.Enter);

            driver.FindElement(By.XPath("//input[@placeholder='Pesquisar']")).SendKeys("Developer Backend Net" + Keys.Return);

            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//button[@aria-label='Vagas']")).Click();
        }
    }
}
