using Sigma_Automation.Dto;
using Sigma_Automation.Page;

namespace Sigma_Automation.Scenarios
{
    public class BrokersTabPage : MainWorkflowPage
    {
        public BrokersTabPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string addButton = "//input[@value='Add']";
        const string brokerFrameId = "brokersInfoFrame";
        #endregion
        #region Click actions
        public SelectBrokerToAddToPolicyPage ClickAdd_Button(WindowsHandlerData data)
        {
            
            data.GetNumberOfCurrentlyOpenedWindows(this);
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(brokerFrameId);

            this.WebDriverWrapper.FindAndClick(addButton, How.XPath);

            data.SelectBrokerToAddToPolicyPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.SelectBrokerToAddToPolicyPopUpPageId);

            return new SelectBrokerToAddToPolicyPage(this);
        }
        #endregion
    }
}