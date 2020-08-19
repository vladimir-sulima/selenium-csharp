using OpenQA.Selenium;
using Sigma_Automation.Dto;
using System;
using System.Linq;
using System.Threading;

namespace Sigma_Automation.Page.Quote.Tabs.Premiums
{
    public class EditFinancialDataPopUpPage : UIPage
    {
        public EditFinancialDataPopUpPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string currencyDdl = "//select[contains(@id, 'CurrencyCode')]";
        const string applicationTaxDdl = "//select[contains(@id, 'ApplicableTaxDomicile')]";
        const string premiumCommentsTextArea = "//textarea[contains(@id,'PremiumComments')]";
        const string renewalCommentsTextArea = "//textarea[contains(@id, 'RenewalComments')]";
        const string yesFlagAtRenewalRadioButton = "//input[@type='radio' and @value='true']";
        const string noFlagAtRenewalRadioButton = "//input[@type='radio' and @value='false']";
        const string saveButton = "//input[@type='submit' and @value='Save']";
        const string cancelButton = "//input[@type='submit' and @value='Cancel']";
        const string coversFrameId = "premiumsInfoFrame";

        #endregion
        #region Click actions
        public PremiumsTabPage ClickSave_Button(MainFlowData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            return new PremiumsTabPage(this);
        }
        public PremiumsTabPage ClickSave_Button2(MainFlowData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            this.WebDriverWrapper.WebDriver.SwitchTo().Window(this.WebDriverWrapper.WebDriver.WindowHandles.Last());

            return new PremiumsTabPage(this);
        }
        public PremiumsTabPage ClickCancel_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(cancelButton, How.XPath);

            this.WaitForWidowClosed(data.EditFinancialDataPopUpPageId);
            this.SwitchToWindow(data.MainFlowPageId);

            return new PremiumsTabPage(this);
        }
        #endregion
        #region Set actions
        public EditFinancialDataPopUpPage SelectCurrency_DropdownList(string currency)
        {
            this.WebDriverWrapper.FindAndClick(currencyDdl + $"/option[text()='{currency}']", How.XPath);

            return this;
        }
        public EditFinancialDataPopUpPage SelectApplicationTax_DropdownList(string applicationTax)
        {
            if (applicationTax != null)
            {
                this.WebDriverWrapper.FindAndClick(applicationTaxDdl + $"/option[text()='{applicationTax}']", How.XPath);
            }
            return this;
        }
        public EditFinancialDataPopUpPage SetPremiumComments_TextArea(string premiumComments)
        {
            if (premiumComments != null)
            {
                this.WebDriverWrapper.FindAndSetText(premiumCommentsTextArea, premiumComments, How.XPath);
            }

            return this;
        }
        public EditFinancialDataPopUpPage SelectFlagAtRenewals_RadioButtons(bool isFlagAtRenewals)
        {
            if (isFlagAtRenewals)
            {
                this.WebDriverWrapper.FindAndClick(yesFlagAtRenewalRadioButton, How.XPath);
            }

            return this;
        }
        public EditFinancialDataPopUpPage SetRenewalComments_TextArea(string renewalComments)
        {
            if (renewalComments != null)
            {
                this.WebDriverWrapper.FindAndSetText(renewalCommentsTextArea, renewalComments, How.XPath);
            }

            return this;
        }
        #endregion
        #region Other actions
        public EditFinancialDataPopUpPage WaitForEditFinancialDataPopupPageDisplayed()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(currencyDdl).Count > 0);

            return this;
        }
        #endregion
    }
}