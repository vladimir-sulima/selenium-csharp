using OpenQA.Selenium;
using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.Covers
{
    public class CoversTabPage : MainWorkflowPage
    {
        public CoversTabPage(IUIPage page) : base(page)
        {
        }
        #region Locators
        const string coversIframe = "coversInfoFrame";
        const string addButton = "//input[@value='Add']";
        const string addCustomButton = "//input[@value='Add Custom']";
        const string coversDescriptionList = "(//span[contains(@id,'Description')])";
        #endregion
        #region Click actions
        public CoversTabPage LeaveCoversByName(MainFlowData data)
        {

            var coversToRemove = data.CoversData.Description.Where(i => !data.CoversData.CoversToLeft.Any(e => i.Contains(e)));

            foreach (var cover in coversToRemove)
            {
                ClickRemoveByCoverName_Button(cover, data);
            }

            return this;
        }
        private CoversTabPage ClickRemoveByCoverName_Button(string coverToRemove, MainFlowData data)
        {
            //TODO Refactor
            WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            try
            {
                this.WebDriverWrapper.FindAndClick($"//span[text()='{coverToRemove}']/../following-sibling::td/input[@value='Remove']", How.XPath);

                IAlert alert = this.WebDriverWrapper.WebDriver.SwitchTo().Alert();
                var t = alert.Text;
                alert.Accept();
            }
            catch (WebDriverTimeoutException ex)
            {

            }
            finally
            {
                WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            }

            return this;
        }
        #endregion
        #region Set actions
        #endregion
        #region Other actions
        public CoversTabPage WaitForCoverIFrameAndButtonsDisplayed()
        {
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(coversIframe);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(addButton).Any());

            return this;
        }
        public CoversTabPage GetAttachedCoverList(CoversData data)
        {
            var coverDescriptionCount = this.WebDriverWrapper.FindElementsByXPath(coversDescriptionList).Count;
            for (int i = 1; i <= coverDescriptionCount; i++)
            {
                var value = this.WebDriverWrapper.GetText(coversDescriptionList + $"[{i}]", How.XPath);
                data.Description.Add(value);
            }
            return this;
        }
        #endregion
    }
}
