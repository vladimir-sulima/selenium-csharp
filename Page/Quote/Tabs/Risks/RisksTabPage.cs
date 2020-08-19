using Sigma_Automation.Dto;
using System.Linq;

namespace Sigma_Automation.Page
{
    public class RisksTabPage : MainWorkflowPage
    {
        public RisksTabPage(IUIPage page) : base (page)
        {

        }
        #region Locators
        const string addBut = "//input[@value='Add']";
        #endregion
        #region Click actions
        public SearchRiskPage ClickAdd_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(addBut, How.XPath);

            data.AddRiskPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.AddRiskPageId);

            return new SearchRiskPage(this);
        }
        #endregion
        #region Other actions
        public RisksTabPage WaitForAddedVesselDisplayed(VesselData data)
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath($"//span[@title='VesselName'and text()='{data.VesselName}']").Any());

            return this;
        }
        #endregion
    }
}