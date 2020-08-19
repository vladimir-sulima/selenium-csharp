using Sigma_Automation.Dto;

namespace Sigma_Automation.Page.Quote.Tabs.AssociatedParties
{
    public class AddDetailsToExistingAssociatedPartyPage : UIPage
    {
        public AddDetailsToExistingAssociatedPartyPage(IUIPage page) : base (page)
        {

        }
        #region Locators
        const string descriptionTextArea = "//textarea[contains(@id, 'Description')]";
        const string roleDdl = "//select[contains(@id, 'PartyRoleTypeCustom')]";
        const string fromDateTextField = "//input[@type='text' and contains(@id, 'StartDateString')]";
        const string toDateTextField = "//input[@type='text' and contains(@id, 'EndDateString')]";
        const string capacityList = "//select[contains(@id, 'PartyRoleSubTypesMultiSelect')]";
        const string clauseDdl = "//select[contains(@id, 'customDropdownList')]";
        const string saveButton = "//input[@value='Save']";
        const string cancelButton = "//input[@value='Cancel']";
        #endregion
        #region Click actions
        public AssociatedPartiesTabPage ClickSave_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            //TODO Change to window handles waiting
            this.SwitchToWindow(data.MainFlowPageId);

            return new AssociatedPartiesTabPage(this);
        }
        public SearchPartyPage ClickCancel_Button()
        {
            this.WebDriverWrapper.FindAndClick(cancelButton, How.XPath);

            return new SearchPartyPage(this);
        }
        #endregion
        #region Set actions
        public AddDetailsToExistingAssociatedPartyPage SetDescription_TextAreaField(string partyDescriprion)
        {
            //this.WebDriverWrapper.SwithToNewPage(500);
            if (partyDescriprion != null)
            {
                this.WebDriverWrapper.FindAndSetText(descriptionTextArea, partyDescriprion, How.XPath);
            }

            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage SelectRole_DropdownList(string partyRole)
        {
            if (partyRole != null)
            {
                this.WebDriverWrapper.FindAndClick(roleDdl, How.XPath);
                this.WebDriverWrapper.FindAndClick(roleDdl + $"/option[text()='{partyRole}']", How.XPath);
            }
            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage SetFromDate_TextField(string partyFromDate)
        {
            if (partyFromDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(fromDateTextField, partyFromDate, How.XPath);
            }
            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage SetToDate_TextField(string partyToDate)
        {
            if (partyToDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(toDateTextField, partyToDate, How.XPath);
            }
            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage SelectCapacity_TextList(string partyCapacity)
        {
            if (partyCapacity != null)
            {
                this.WebDriverWrapper.FindAndClick(capacityList + $"/option[text()='{partyCapacity}']", How.XPath);
            }
            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage SelectClause_DropdownList(string partyClause)
        {
            if (partyClause != null)
            {
                this.WebDriverWrapper.FindAndClick(clauseDdl, How.XPath);
                this.WebDriverWrapper.FindAndClick(clauseDdl + $"/option[text()='{partyClause}']", How.XPath);
            }
            return this;
        }
        #endregion
        #region Other actions
        #endregion
    }
}