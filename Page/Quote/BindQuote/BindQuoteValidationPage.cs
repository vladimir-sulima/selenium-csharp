using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.BindQuote
{
    public class BindQuoteValidationPage : UIPage
    {
        public BindQuoteValidationPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string bindQuoteValidationPageTitle = "//span[text()='BindQuoteValidation.aspx']";
        const string continueRadioButton = "//input[@value='Continue']";
        const string submitButton = "//input[contains(@id,'btnSubmit')]";
        #endregion
        #region Click actions
        public BindQuoteSelectDocumentationPage ClickSubmit_Button()
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            return new BindQuoteSelectDocumentationPage(this);
        }
        #endregion
        #region Set actions
        public BindQuoteValidationPage SelectContinue_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(continueRadioButton, How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        public BindQuoteValidationPage WaitForQuoteValidationPageDisplayedDisplayed(WindowsHandlerData data)
        {
            this.SwitchToWindow(data.MainFlowPageId);

            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(bindQuoteValidationPageTitle).Any());

            return this;
        }
        #endregion
    }
}
