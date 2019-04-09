using W3Assesment.ComponentHelper;
using W3Assesment.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Assesment.DataDriven
{
   public class W3Schools
    {
        //string xlpath = @"C:\Users\ee210668\Desktop\Data.xlsx";

        #region Webelements
        //private By LearnHTMLPage = By.XPath("//*[@id='mySidenav']/div/a[1]");
        //private By TryyourselfPage = By.XPath("//*[@id='main']/div[4]/a");

        [FindsBy(How = How.XPath, Using = "//*[@id='mySidenav']/div/a[1]")]
        private IWebElement LearnHTML;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/a")]
        private IWebElement TryItYourself;

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/button")]
        private IWebElement Run;

        public IWebElement Run1 { get => Run; set => Run = value; }
        public IWebElement TryItYourself1 { get => TryItYourself; set => TryItYourself = value; }
        public IWebElement LearnHTML1 { get => LearnHTML; set => LearnHTML = value; }

        #endregion

        public W3Schools()
        {


#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(ObjectRepository.Driver, this);
#pragma warning restore CS0618 // Type or member is obsolete


        }
        #region Actions
        public void NavigatetoW3SchoolsHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
        public void ClickLearnHTML()
        {
            LearnHTML1.Click();
            
        }

        public void ClickTryItYourSelf()
        {
            TryItYourself1.Click();
        }
        public void ClickRun()
        {
            var currentWindow = ObjectRepository.Driver.CurrentWindowHandle;
            foreach (String winHandle in ObjectRepository.Driver.WindowHandles)
            {
                if (winHandle != currentWindow)
                {
                    ObjectRepository.Driver.SwitchTo().Window(winHandle);
                }
            }
            Run1.Click();          
           
        }

        #endregion
        #region Navigation
        public void result()
        {
            Assert.IsNotNull(ObjectRepository.Driver.FindElement(By.XPath("//*[@id='iframeResult']")));
        }

#endregion
        
    }
}
