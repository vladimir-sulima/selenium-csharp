using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.Tabs.AssociatedParties;

namespace Sigma_Automation.Page
{
    public class AssociatedPartiesTabPage : MainWorkflowPage
    {
        public AssociatedPartiesTabPage(IUIPage page) : base (page)
        {

        }
        #region Locators
        const string addButton = "//input[contains(@onclick, 'return redirectAddExistingAssociatedParty')]";
        const string associatedPartiesInfoFrameNeme = "associatedPartiesInfoFrame";
        #endregion
        #region Click actions
        public SearchPartyPage ClickAdd_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(associatedPartiesInfoFrameNeme);

            data.GetNumberOfCurrentlyOpenedWindows(this);
            
            this.WebDriverWrapper.FindAndClick(addButton, How.XPath);

            data.SearchPartyPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.SearchPartyPageId);

            return new SearchPartyPage(this);
        }
        #endregion
        #region Set actions
        #endregion
        #region Other actions
        #endregion
    }
}