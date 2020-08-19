using OpenQA.Selenium;
using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.PremiumInstalments
{
    public class InstalmentsDetailsPage : UIPage
    {
        public InstalmentsDetailsPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string instalmentsPatternDdl = "//select[not(contains(@id, 'entityTypes'))]";
        const string yesBespokeInstalmentPatternRadioButton = "//input[@name='IsBespoke' and contains(@data-bind, 'true')]";
        const string noBespokeInstalmentPatternRadioButton = "//input[@name='IsBespoke' and contains(@data-bind, 'false')]";
        const string checkValidityButton = "//button[contains(@data-bind, 'checkValidity')]";
        const string confirmAndSaveButton = "//button[contains(@data-bind, 'applySchedule')]";

        #endregion
        #region Click actions
        public InstalmentsDetailsPage ClickCkeckValidity_Button()
        {
            this.WebDriverWrapper.FindAndClick(checkValidityButton, How.XPath);

            return this;
        }
        public PremimInstalmentsTabPage ClickConfirmAndSave_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(confirmAndSaveButton, How.XPath);

            IAlert alert = this.WebDriverWrapper.WebDriver.SwitchTo().Alert();
            var t = alert.Text;
            alert.Accept();

            this.WaitForWidowClosed(data.InstalmentsDetailsPopUpPageId);

            this.SwitchToWindow(this.WebDriverWrapper.WebDriver.WindowHandles.Last());

            return new PremimInstalmentsTabPage(this);
        }
        #endregion
        #region Set actions
        public InstalmentsDetailsPage SelectInstalmentsPattern_DropdownList(string instalmentPattern)
        {
            this.WebDriverWrapper.FindAndClick(instalmentsPatternDdl + $"/option[text()='{instalmentPattern}']", How.XPath);

            return this;
        }
        public InstalmentsDetailsPage SelectWillTheInstalmentPatternBeBespoke_RadioButton(bool isBespokeInstalmentPattern = false)
        {
            if (isBespokeInstalmentPattern)
            {
                this.WebDriverWrapper.FindAndClick(yesBespokeInstalmentPatternRadioButton, How.XPath);

                WaitTillPageLoaded();
            }

            return this;
        }
        #endregion
        #region Other actions
        #endregion
        
    }
}
