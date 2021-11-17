using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OgameAuthomatization
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver webDriver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            webDriver.Navigate().GoToUrl(SecretData.OgameURL);

            wait.Until(ExpectedConditions.ElementExists(By.Name("email")));
            webDriver.FindElement(By.XPath("//ul[@class='tabsList']/li")).Click();
            webDriver.FindElement(By.Name("email")).SendKeys(SecretData.OgameEmail);
            webDriver.FindElement(By.Name("password")).SendKeys(SecretData.OgamePassword);
            webDriver.FindElement(By.XPath("//button[@class='button button-primary button-lg']")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='button button-primary button-md']")));
            webDriver.FindElement(By.XPath("//button[@class='button button-primary button-md']")).Click();


            wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='btn btn-primary']")));
            webDriver.FindElement(By.XPath("//button[@class='btn btn-primary']")).Click();

            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            wait.Until(ExpectedConditions.ElementExists(By.Id("metal_box")));
            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
            webDriver.Close();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
            webDriver.FindElement(By.XPath("//button[.='Accept Cookies']")).Click();
            webDriver.FindElement(By.XPath(SecretData.OgameResourcesPath)).Click();
        }
    }
}