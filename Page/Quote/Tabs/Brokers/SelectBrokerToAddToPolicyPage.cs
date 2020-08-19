using Sigma_Automation.Dto;

namespace Sigma_Automation.Scenarios
{
    public class SelectBrokerToAddToPolicyPage : UIPage
    {
        public SelectBrokerToAddToPolicyPage(IUIPage page) : base(page)
        {
        }
        #region Locators
        const string fullNameTextField = "//input[contains(@id, 'FullName')]";
        const string brokerRefTextField = "//input[contains(@id, 'Reference')]";
        const string clearAllButton = "//input[@value='Clear All']";
        const string searchButton = "//input[@value='Search']";
        const string firstLinkAtListButton = "(//input[@value='Link'])[1]";
        #endregion
        #region Click actions
        public SelectBrokerToAddToPolicyPage ClickSearch_Button()
        {
            this.WebDriverWrapper.FindAndClick(searchButton, How.XPath);

            return this;
        }
        public SelectBrokerToAddToPolicyPage ClickClearAll_Button()
        {
            this.WebDriverWrapper.FindAndClick(clearAllButton, How.XPath);

            return this;
        }
        public BrokersTabPage ClickFirstLink_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(firstLinkAtListButton, How.XPath);

            this.WaitForWidowClosed(data.SelectBrokerToAddToPolicyPopUpPageId);
            this.SwitchToWindow(data.MainFlowPageId);

            return new BrokersTabPage(this);
        }
        #endregion
        #region Set actions
        public SelectBrokerToAddToPolicyPage SetFullName_TextField(string brokerFullName)
        {
            if (brokerFullName != null)
            {
                this.WebDriverWrapper.FindAndSetText(fullNameTextField, brokerFullName, How.XPath);
            }
            return this;
        }
        public SelectBrokerToAddToPolicyPage SetBrokerReference_TextField(string brokerReference)
        {
            if(brokerReference!=null)
            {
                this.WebDriverWrapper.FindAndSetText(brokerRefTextField, brokerReference, How.XPath);
            }
            return this;
        }
        #endregion

    }
}