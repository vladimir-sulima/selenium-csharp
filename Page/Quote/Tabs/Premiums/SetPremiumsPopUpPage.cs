using Sigma_Automation.Dto;
using System.Linq;
using System.Threading;

namespace Sigma_Automation.Page.Quote.Tabs.Premiums
{
    public class SetPremiumsPopUpPage : UIPage
    {
        public SetPremiumsPopUpPage(IUIPage page) : base(page)
        {
        }
        #region Locators
        const string coverTypeDdl = "//select[contains(@id, 'ProductTermId')]";
        //const string amountTextFiedl = "(//input[contains(@id, 'EnteredPremium')])[2]";""
        const string amountTextFiedl = "(//table//td//input[@id])[37]";
        const string saveButton = "//input[@value='Save']";
        const string cancelButton = "//input[@value='Cancel']";
        #endregion
        #region Click actions
        public PremiumsTabPage CliclSave_Button(MainFlowData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            return new PremiumsTabPage(this);
        }
        public PremiumsTabPage CliclCancel_Button()
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            return new PremiumsTabPage(this);
        }
        #endregion
        #region Set actions
        public SetPremiumsPopUpPage SelectCover_DropdownList(string coverType)
        {
            this.WebDriverWrapper.FindAndClick(coverTypeDdl, How.XPath);
            this.WebDriverWrapper.FindAndClick(coverTypeDdl + $"/option[text()='{coverType}']", How.XPath);

            return this;
        }
        public SetPremiumsPopUpPage SetAmount_TextField(string ammount)
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(amountTextFiedl).Any());
            this.WebDriverWrapper.FindAndSetText(amountTextFiedl, ammount, How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        #endregion
    }
}