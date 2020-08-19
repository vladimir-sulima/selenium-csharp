using OpenQA.Selenium;
using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.Premiums
{
    public class InstalmentsAndCommissionsPopUpPage : UIPage
    {
        public InstalmentsAndCommissionsPopUpPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string comissionPercentageTextField = "//input[contains(@id, 'CommissionPercentage')]";
        const string callTypeDdl = "//select[contains(@id, 'CallTypeValue')]";
        const string premiumTypeValueDdl = "//select[contains(@id, 'PremiumTypeValue')]";
        const string saveButton = "//input[@value='Save']";
        const string cancelButton = "//input[@value='Cancel']";
        const string updateAllCoversEnabledCheckbox = "//input[contains(@id, 'PopulateToAllCovers') and not(@disabled)]";
        #endregion
        #region Click actions
        public PremiumsTabPage ClickSave_Button(MainFlowData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            this.WebDriverWrapper.BrowserRestart(data.FlowURL);

            return new PremiumsTabPage(this);
        }
        public PremiumsTabPage ClickCancel_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(cancelButton, How.XPath);

            this.SwitchToWindow(data.MainFlowPageId);

            return new PremiumsTabPage(this);
        }
        public InstalmentsAndCommissionsPopUpPage ClickUpdateAllCovers_CheckBox()
        {
            var isUpdateAllCoversCheckBoxEnabled = VerifyIsUpdateAllCoversEnabled();
            if (isUpdateAllCoversCheckBoxEnabled)
            {
                this.WebDriverWrapper.FindAndClick(updateAllCoversEnabledCheckbox, How.XPath);
            }

            return this;
        }
        #endregion
        #region Set actions
        public InstalmentsAndCommissionsPopUpPage SetComissionPercentage_TextField(string comissionPercentage)
        {
            this.WebDriverWrapper.FindAndSetText(comissionPercentageTextField, comissionPercentage, How.XPath);

            return this;
        }
        public InstalmentsAndCommissionsPopUpPage SelectCallType_DropdownList(string callType)
        {
            this.WebDriverWrapper.FindAndClick(callTypeDdl + $"/option[text()='{callType}']", How.XPath);

            return this;
        }
        public InstalmentsAndCommissionsPopUpPage SelectPremiumType_DropdownList(string premiumType)
        {
            this.WebDriverWrapper.FindAndClick(premiumTypeValueDdl + $"/option[text()='{premiumType}']", How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        private bool VerifyIsUpdateAllCoversEnabled()
        {
            return this.WebDriverWrapper.CheckElementExistsByXpath(updateAllCoversEnabledCheckbox);
        }
        #endregion
    }
}
