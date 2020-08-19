using System.Linq;

namespace Sigma_Automation.Page
{
    public class IssueQuotePage : UIPage
    {
        public IssueQuotePage(IUIPage page) : base(page)
        {
        }
        #region Locators
        const string issueQuoteHeader = "//span[text()='IssueQuote.aspx']";
        const string issueRadioButton = "//input[@value='Issue']";
        const string cancelRadioButton = "//td/input[@value='Cancel']";
        const string referRadioButton = "//input[@value='Refer']";
        const string submitButton = "//input[@value='Submit']";
        #endregion
        #region Click actions
        public StartPage ClickSubmit_Button()
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            return new StartPage(this.WebDriverWrapper);
        }
        #endregion
        #region Set actions
        public IssueQuotePage SelectIssue_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(issueRadioButton, How.XPath);

            return this;
        }
        public IssueQuotePage SelectCancel_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(cancelRadioButton, How.XPath);

            return this;
        }
        public IssueQuotePage SelectRefer_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(referRadioButton, How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        public IssueQuotePage WaitForIssueQuotePageDisplayed()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(issueQuoteHeader).Any());

            return this;
        }
        
        #endregion
    }
}