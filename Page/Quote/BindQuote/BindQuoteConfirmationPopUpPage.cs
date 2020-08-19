using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.BindQuote;

namespace Sigma_Automation.Page
{
    public class BindQuoteConfirmationPopUpPage : UIPage
    {
        public BindQuoteConfirmationPopUpPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string submitButton = "//*[@value='Submit']";
        #endregion
        #region Click actions
        public BindQuoteValidationPage ClickSubmit_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            this.WaitForWidowClosed(data.BindQuotePopUpPageId);

            return new BindQuoteValidationPage(this);
        }
        #endregion

    }
}