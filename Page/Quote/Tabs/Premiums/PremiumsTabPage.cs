using OpenQA.Selenium;
using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.Tabs.Premiums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.Premiums
{
    public class PremiumsTabPage : MainWorkflowPage
    {
        public PremiumsTabPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string coversFrameId = "premiumsInfoFrame";
        //const string instalmentsFrame = "premiumInstalmentsFrame";
        const string instalmentsFrame = "//iframe";
        const string financialDataEditButton = "//button[contains(@onclick, 'EditInstalmentAndCurrency')]";
        const string coverLevelDetailsFirsEditButton = "(//tbody/tr[@id]/td/input[@value='Edit'])[1]";
        const string setUpdatePremiumButton = "(//input[contains(@id, 'Set2fUpdate_Premium')])";
        #endregion

        #region Click actions
        public EditFinancialDataPopUpPage ClickEditFinancialData_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(financialDataEditButton, How.XPath);

            this.WebDriverWrapper.WebDriver.SwitchTo().DefaultContent();

            data.EditFinancialDataPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.EditFinancialDataPopUpPageId);

            return new EditFinancialDataPopUpPage(this);
        }
        public InstalmentsAndCommissionsPopUpPage ClickFirsEditCoverLevelDetails_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.WebDriver.FindElement(By.XPath(coverLevelDetailsFirsEditButton)).Click();

            data.InstalmentsAndCommissionPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.InstalmentsAndCommissionPopUpPageId);

            return new InstalmentsAndCommissionsPopUpPage(this);
        }
        public SetPremiumsPopUpPage ClickSetUpdatePremium_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            var element = this.WebDriverWrapper.FindElementsByXPath(setUpdatePremiumButton).Last();
            this.WebDriverWrapper.Click(element);

            data.SetPremiumsPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.SetPremiumsPopUpPageId);

            return new SetPremiumsPopUpPage(this);
        }
        #endregion
        #region Other actions
        public PremiumsTabPage WaitTillPremiumsPageDisplayed()
        {
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(coversFrameId);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(financialDataEditButton).Any());

            return this;
        }
        public PremiumsTabPage WaitTillCoverLevelDetailsFrameDisplayed(WindowsHandlerData data)
        {
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(coversFrameId);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(coverLevelDetailsFirsEditButton).Any());

            return this;
        }
        public PremiumsTabPage WaitTillRisksPremiumFrameDisplayed(WindowsHandlerData data)
        {
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(coversFrameId);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(setUpdatePremiumButton).Any());

            return this;
        }
        public PremiumsTabPage GetCurrentFlowUrl(MainFlowData data)
        {
            data.FlowURL = this.WebDriverWrapper.WebDriver.Url;

            return this;
        }
        #endregion
    }
}
