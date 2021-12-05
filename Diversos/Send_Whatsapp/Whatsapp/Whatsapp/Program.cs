using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Whatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string telDestino;
            string urlSend = "https://api.whatsapp.com/";

            

            Console.WriteLine("Informe o número de telefone para envio no formato 5571999999999: ");
            
            telDestino = "send?phone="+Console.ReadLine();

            string textoEnvio = "&text="+@"Favor não responda essa mensagem, tentando enviar msg automática";

            urlSend = urlSend + telDestino + textoEnvio;

            IWebDriver whatsappSend = new ChromeDriver("C:\\");

            whatsappSend.Url = urlSend;

            Thread.Sleep(5000);

            whatsappSend.FindElement(By.Id("action-button")).Click();

            Thread.Sleep(3000);

            whatsappSend.FindElement(By.XPath("//*[@id='fallback_block']/div/div/a")).Click();
            
            Thread.Sleep(10000);

            whatsappSend.FindElement(By.XPath("//span[@data-icon='send']")).Click();

            // Thread.Sleep(50000);

            //whatsappSend.Close();


        }
    }
}
