using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.Tabs.PremiumInstalments;
using System.Linq;
using System.Threading;

namespace Sigma_Automation.Page
{
    public class PremimInstalmentsTabPage : MainWorkflowPage
    {
        public PremimInstalmentsTabPage(IUIPage page) : base(page)
        {
        }
        #region Locators
        const string premiumInstalmentsIframe = "premiumInstalmentsFrame";
        const string editButton = "//button[text()='Edit']";
        #endregion
        #region Click actions
        public InstalmentsDetailsPage ClickEdit_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(editButton).Any());
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.CheckElementExistsByXpath("//div[@class='loader visible']") == false);

            this.WebDriverWrapper.FindAndClick(editButton, How.XPath);

            data.InstalmentsDetailsPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.InstalmentsDetailsPopUpPageId);
            return new InstalmentsDetailsPage(this);
        } 
        #endregion
        #region Set actions
        #endregion
        #region Other actions
        public PremimInstalmentsTabPage WaitTillPremiumInstalmentsFrameDisplayed()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsById(premiumInstalmentsIframe).Any());
            this.WebDriverWrapper.WebDriver.SwitchTo().Frame(premiumInstalmentsIframe);
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(editButton).Any());

            return this;
        }
        #endregion
    }
}