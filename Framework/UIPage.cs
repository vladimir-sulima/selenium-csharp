using OpenQA.Selenium;
using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Sigma_Automation
{
    public abstract class UIPage : IUIPage, ICloneable
    {
        protected UIPage(WebDriverWrapper webDriverWrapper)
        {
            WebDriverWrapper = webDriverWrapper;
        }

        protected UIPage(IUIPage page)
        {
            WebDriverWrapper = page.WebDriverWrapper;
        }

        public WebDriverWrapper WebDriverWrapper { get; set; }

        public void SwitchToWindow(string windowId)
        {
            WebDriverWrapper.WebDriver.SwitchTo().Window(windowId);
        }
        public void WaitForWidowClosed(string windowId)
        {
            WebDriverWrapper.Wait.Until(x => WebDriverWrapper.WebDriver.WindowHandles.Contains(windowId) == false);
        }
        public void WaitTillPageLoaded(int sleep = 200, bool waitForAjax = true)
        {
            WebDriverWrapper.Wait.Until(x => WebDriverWrapper.FindElementsByXPath("//div[@class='loader hidden']").Any());

            if(waitForAjax == true)
            { 
                WebDriverWrapper.WaitForAjax();
            }

            Thread.Sleep(sleep);
        }
        public void WaitTillRulesLoaded(int sleep = 0)
        {
            Thread.Sleep(sleep);

            WebDriverWrapper.Wait.Until(x => WebDriverWrapper.FindElementsByXPath("//fieldset[@disabled]").Count == 0);

            WebDriverWrapper.WaitForAjax();

        }

        public void WaitForElementDisplayed(string elementToBeDisplayed_XPath)
        {
            WebDriverWrapper.Wait.Until(x => WebDriverWrapper.FindElementsByXPath(elementToBeDisplayed_XPath).Any());
        }

        public TPage CreatePage<TPage>() where TPage : UIPage
        {
            return CreatePage<TPage>(this.WebDriverWrapper);
        }

        public static TPage CreatePage<TPage>(WebDriverWrapper webDriverWrapper) where TPage : UIPage
        {
            var page = (TPage)Activator.CreateInstance(typeof(TPage), webDriverWrapper);
            return page;
        }

        public void WaitTillRiskCardDisplayed()
        {
            WebDriverWrapper.Wait.Until(x => WebDriverWrapper
                .FindElementsByXPath("//div[@class='border risk-vessel-card-selectable selected']").Any());
        }
        public void WaitForNewWindowOpened()
        {
            var availableWindows = new List<string>(this.WebDriverWrapper.WebDriver.WindowHandles);

            var currentWindow = this.WebDriverWrapper.WebDriver.CurrentWindowHandle;
            this.WebDriverWrapper.Wait.Until(x => new List<string>(this.WebDriverWrapper.WebDriver.WindowHandles).Count > availableWindows.Count);
        }

        public void CloseCurrentWindow()
        {
            this.WebDriverWrapper.WebDriver.Close();
        }
        public void Login(string userName, string password)
        {
            IAlert alert = WebDriverWrapper.WebDriver.SwitchTo().Alert();
            alert.SendKeys(userName + Keys.Tab.ToString() + password);
            alert.Accept();
        }

        public Stopwatch StartStopwatch(ref Stopwatch timer)
        {
            timer.Start();

            return timer;
        }
        public Stopwatch StopStopwatch(ref Stopwatch timer)
        {
            timer.Stop();

            return timer;
        }
    }
}