using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.Tabs.Covers;
using Sigma_Automation.Page.Quote.Tabs.Premiums;
using Sigma_Automation.Scenarios;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sigma_Automation.Page
{
    public class MainWorkflowPage : UIPage
    {
        public MainWorkflowPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string quoteDetailsTab = "//a[@title='Quote Details']";
        const string risksTab = "//a[@title='Risks']";
        const string associatedPartiesTab = "//a[@title='Associated Parties']";
        const string brokersTab = "//a[@title='Brokers']";
        const string coversTab = "//a[@title='Covers']";
        const string premiumsTab = "//a[@title='Premiums']";
        const string premiumInstalmentsTab = "//a[@title='Premium Instalments']";
        const string internalNotesTab = "//a[@title='Internal Notes']";
        const string associatedPartiesListHeader = "//span[@class='ms-standardheader ms-WPTitle' and text()='Associated Parties']";
        const string memberAssuredLabel = "//label[text()='Member / Assured:']";
        const string requestApprovalRadioButton = "//input[@value='Request Approval']";
        const string issueQuoteRadioButton = "//input[@value='Issue Quote']";
        const string closeQuoteRadioButton = "//input[@value='Close Quote']";
        const string saveAndExitRadioButton = "//input[@value='Save and Exit']";
        const string saveRadioButton = "//input[@value='Save']";
        const string referRadioButton = "//input[@value='Refer']";
        const string submitButton = "//span[@class='WorkflowControl']//input[@value='Submit']";
        const string cancelButton = "//span[@class='WorkflowControl']//input[@value='Cancel']";

        const string pageTitle = "//span[text()='QuoteDetails.aspx']";
        const string quoteReferenceValue = "//span[contains(@id,'Reference')]";
        const string expiryDateValue = "//span[contains(@id,'FormattedExpiryDate')]";
        const string policyPeriodValue = "//span[contains(@id,'QuoteSummaryControl__formView_fld_PolicyStartDateString')]";
        const string assuredOrMemberValue = "//span[contains(@id,'PartyRoleMainPolicyHolderSummary')]";
        const string quoteStatusValue = "//span[contains(@id,'CurrentStatus')]";
        const string memberCreditStatus = "//span[contains(@id,'MainPolicyHolderMessages')]";

        const string bindQuoteButton = "//td[contains(@id, 'ActionsMenun3')]//a";
        #endregion
        #region Click actions
        public QuoteDetailsPage ClickQuoteDetailsTab()
        {
            this.WebDriverWrapper.FindAndClick(quoteDetailsTab, How.XPath);

            return new QuoteDetailsPage(this);
        }
        public RisksTabPage ClickRisksTab()
        {
            this.WebDriverWrapper.FindAndClick(risksTab, How.XPath);

            return new RisksTabPage(this);
        }
        public AssociatedPartiesTabPage ClickAssociatedPartiesTab()
        {
            this.WebDriverWrapper.FindAndClick(associatedPartiesTab, How.XPath);

            return new AssociatedPartiesTabPage(this);
        }
        public BrokersTabPage ClickBrokersTab()
        {
            bool isBrokerTabDisplayed = false;

            while(isBrokerTabDisplayed == false)
            {
                isBrokerTabDisplayed = this.WebDriverWrapper.CheckElementExistsByXpath(brokersTab);
            }

            this.WebDriverWrapper.FindAndClick(brokersTab, How.XPath);

            return new BrokersTabPage(this);
        }
        public CoversTabPage ClickCoversTab()
        {
            WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
            try
            {
                this.WebDriverWrapper.WebDriver.FindElement(By.XPath(coversTab)).Click();
            }
            catch (WebDriverException ex)
            {

            }
            finally
            {
                WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            }

            return new CoversTabPage(this);
        }
        public PremiumsTabPage ClickPremiumsTab()
        {
            WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            WebDriverWrapper.Wait.Timeout = TimeSpan.FromSeconds(5);
            try
            {
                this.WebDriverWrapper.FindAndClick(premiumsTab, How.XPath);

            }
            catch (WebDriverException ex)
            {

            }
            finally
            {
                WebDriverWrapper.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
                WebDriverWrapper.Wait.Timeout = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"]));
            }

            return new PremiumsTabPage(this);
        }
        public PremimInstalmentsTabPage ClickPremiumInstalmentsTab()
        {
            this.WebDriverWrapper.FindAndClick(premiumInstalmentsTab, How.XPath);

            return new PremimInstalmentsTabPage(this);
        }
        public MainWorkflowPage CickSubmit_Button()
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            return this;
        }
        public BindQuoteConfirmationPopUpPage ClickBindQuote_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(bindQuoteButton).Any());

            this.WebDriverWrapper.FindAndClick(bindQuoteButton, How.XPath);
            data.BindQuotePopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            Thread.Sleep(1000);

            this.SwitchToWindow(data.BindQuotePopUpPageId);

            return new BindQuoteConfirmationPopUpPage(this);
        }
        #endregion
        #region Set actions
        public MainWorkflowPage SelectRequestApproval_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(requestApprovalRadioButton, How.XPath);

            return this;
        }
        public MainWorkflowPage SelectIssue_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(issueQuoteRadioButton, How.XPath);

            return this;
        }
        public MainWorkflowPage SelectCloseQuote_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(closeQuoteRadioButton, How.XPath);

            return this;
        }
        public MainWorkflowPage SelectSaveAndExit_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(saveAndExitRadioButton, How.XPath);

            return this;
        }
        public MainWorkflowPage SelectSave_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(saveRadioButton, How.XPath);

            return this;
        }
        public MainWorkflowPage SelectRefer_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(referRadioButton, How.XPath);

            return this;
        }
        #endregion
        #region Other Actions 

        public QuoteDetailsPage WaitToQuotePageOpen(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);
            data.MainFlowPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.MainFlowPageId);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(pageTitle).Any());

            return new QuoteDetailsPage(this);
        }

        public MainWorkflowPage ResolveSwitchBetweenWindowIssue(MainFlowData data)
        {
            this.WebDriverWrapper.BrowserRestart(data.FlowURL);

            return this;
        }
        public IssueQuotePage SwitchToIssueQuotePage()
        {
            return new IssueQuotePage(this);
        }

        public MainWorkflowPage GetQuoteReferenceValue(QuotePolicyData data)
        {
            data.QuoteReference = this.WebDriverWrapper.GetText(quoteReferenceValue, How.XPath);

            return this;
        }
        public MainWorkflowPage GetExpiryDateValue(QuotePolicyData data)
        {
            data.ExpiryDate = this.WebDriverWrapper.GetText(expiryDateValue, How.XPath);

            return this;
        }
        public MainWorkflowPage GetPolicyPeriodValue(QuotePolicyData data)
        {
            data.PolicyPeriod = this.WebDriverWrapper.GetText(policyPeriodValue, How.XPath);

            return this;
        }
        public MainWorkflowPage GetAssuredOrMemberValue(QuotePolicyData data)
        {
            data.AssuredOrMember = this.WebDriverWrapper.GetText(assuredOrMemberValue, How.XPath);

            return this;
        }
        public MainWorkflowPage GetQuoteStatusValue(QuotePolicyData data)
        {
            data.QuoteStatus = this.WebDriverWrapper.GetText(quoteStatusValue, How.XPath);

            return this;
        }
        public MainWorkflowPage GetMemberCreditStatusValue(QuotePolicyData data)
        {
            data.MemberCreditStatus = this.WebDriverWrapper.GetText(memberCreditStatus, How.XPath);

            return this;
        }
        public MainWorkflowPage WaitForQuoteDataSaved(WindowsHandlerData data)
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(saveRadioButton).Any());

            data.MainFlowPageId = this.WebDriverWrapper.WebDriver.CurrentWindowHandle;
            
            return this;
        }
        public MainWorkflowPage SwitchToQuoteDetailsPage(WindowsHandlerData data)
        {
            data.MainFlowPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            //TODO refactor
            Thread.Sleep(2500);

            this.SwitchToWindow(data.MainFlowPageId);

            return this;
        }
        #endregion
    }
}