using Sigma_Automation.Dto;
using System.Linq;

namespace Sigma_Automation.Page
{
    public class CreateQuotePopUpPage : UIPage
    {
        public CreateQuotePopUpPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string riskTypeDdl = "//select[contains(@name, 'ddlRiskType')]";
        const string productTypeDdl = "//select[contains(@name, 'ddlProductType')]";
        const string policyBillingTypeDdl = "//select[contains(@name, 'ddlPolicyBillingType')]";
        const string templateTypeDdl = "//select[contains(@name, 'ddlTemplateType')]";
        const string templateCategoryDdl = "//select[contains(@name, 'ddlTemplateCategory')]";
        const string templateNameDdl = "//select[contains(@name, 'ddlTemplateName')]";
        const string fromDateTextField = "(//input[contains(@id, 'PolicyStartDateCalendar')])[1]";
        const string toDateTextField = "(//input[contains(@id, 'PolicyEndDateCalendar')])[1]";
        const string submitButton = "//input[@value='Submit']";

        #endregion
        #region Click actions
        public MainWorkflowPage ClickSubmit_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            this.WaitForWidowClosed(data.CreateQuotePopUpPageId);
            this.SwitchToWindow(this.WebDriverWrapper.WebDriver.WindowHandles.Last());
            return new MainWorkflowPage(this);
        }
        #endregion

        #region Set actions
        public CreateQuotePopUpPage SelectRiskType_DropdownList(string riskTypeOption)
        {
            this.WebDriverWrapper.FindAndClick(riskTypeDdl + $"/option[text()='{riskTypeOption}']", How.XPath);

            return this;
        }
        public CreateQuotePopUpPage SelectProductType_DropdownList(string productTypeOption)
        {
            var element = this.WebDriverWrapper.FindBy(How.XPath, productTypeDdl);
            this.WebDriverWrapper.WaitElementIsClickable(element);

            this.WebDriverWrapper.FindAndClick(productTypeDdl + $"/option[text()='{productTypeOption}']", How.XPath);

            return this;
        }

        public CreateQuotePopUpPage SelectPolicyBilling_DropdownList(string policyBillingTypeOption)
        {
            var element = this.WebDriverWrapper.FindBy(How.XPath, policyBillingTypeDdl);
            this.WebDriverWrapper.WaitElementIsClickable(element);

            this.WebDriverWrapper.FindAndClick(policyBillingTypeDdl + $"/option[text()='{policyBillingTypeOption}']", How.XPath);

            return this;
        }
        public CreateQuotePopUpPage SelectTemplateType_DropdownList(string templateTypeOption)
        {
            var element = this.WebDriverWrapper.FindBy(How.XPath, templateTypeDdl);
            this.WebDriverWrapper.WaitElementIsClickable(element);

            this.WebDriverWrapper.FindAndClick(templateTypeDdl + $"/option[text()='{templateTypeOption}']", How.XPath);

            return this;
        }
        public CreateQuotePopUpPage SelectTemplateCategory_DropdownList(string templateCategoryOption)
        {
            var element = this.WebDriverWrapper.FindBy(How.XPath, templateTypeDdl);
            this.WebDriverWrapper.WaitElementIsClickable(element);

            //this.WebDriverWrapper.Click(element);
            this.WebDriverWrapper.FindAndClick(templateCategoryDdl + $"/option[text()='{templateCategoryOption}']", How.XPath);

            return this;
        }
        public CreateQuotePopUpPage SelectTemplateName_DropdownList(string templateNameOption)
        {
            var element = this.WebDriverWrapper.FindBy(How.XPath, templateNameDdl);
            this.WebDriverWrapper.WaitElementIsClickable(element);

            //this.WebDriverWrapper.Click(element);
            this.WebDriverWrapper.FindAndClick(templateNameDdl + $"/option[text()='{templateNameOption}']", How.XPath);

            return this;
        }
        public CreateQuotePopUpPage SelectTBC_RadioButtons(bool dateToBeConfirmed = false)
        {
            if (dateToBeConfirmed)
            {
                this.WebDriverWrapper.FindAndClick("//table[contains(@id, 'rbIsDateTbc')]//input[@value='Yes']", How.XPath);
            }
            else
            {
                this.WebDriverWrapper.FindAndClick("//table[contains(@id, 'rbIsDateTbc')]//input[@value='No']", How.XPath);
            }

            return this;
        }
        public CreateQuotePopUpPage SetFromDate_TextFiedl(string fromDate)
        {
            if (fromDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(fromDateTextField, fromDate, How.XPath);
            }
            return this;
        }
        public CreateQuotePopUpPage SetToDate_TextFiedl(string toDate)
        {
            if (toDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(toDateTextField, toDate, How.XPath);
            }
            return this;
        }
        #endregion
    }
}