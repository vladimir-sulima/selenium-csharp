using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.BindQuote
{
    public class BindQuoteAddPatternPopUpPage : UIPage
    {
        public BindQuoteAddPatternPopUpPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string saveButton = "//input[@value='Save']";
        const string commentsTextArea = "//textarea";
        #endregion
        #region Click actions
        public QuoteReinsurancePage ClickSaveButton(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            SwitchToWindow(data.MainFlowPageId);
            WaitForWidowClosed(data.BindQuoteAddPatternPopUpPageId);

            return new QuoteReinsurancePage(this);
        }
        #endregion
        #region Set actions
        public BindQuoteAddPatternPopUpPage SetComments_TextArea(string comments)
        {
            if(comments!=null)
            {
                this.WebDriverWrapper.FindAndSetText(commentsTextArea, comments, How.XPath);
            }
            return this;
        }
        #endregion
        #region Other actions
        #endregion
    }
}
