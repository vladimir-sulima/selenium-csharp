using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.AssociatedParties
{
    public class SearchPartyPage: UIPage
    {
        public SearchPartyPage(IUIPage page) : base (page)
        {

        }
        #region Locators
        const string nameTextField = "//input[contains(@id, 'PartyRoleFullName')]";
        const string refTextField = "//input[contains(@id, 'PartyRoleReference')]";
        const string domicilieDdl = "//select[contains(@id, 'PartyGeographicAreaIdDomicile')]";
        const string memberGroupDdl = "//select[contains(@id, 'PartyMemberGroupId')]";
        const string clearAllButton = "//input[@value='Clear All']";
        const string searchButton = "//input[@value='Search']";
        const string firstLinkButton = "(//input[@value='Link'])[1]";
        const string addNewButton = "//input[@value='Add New']";
        #endregion
        #region Click actions
        public SearchPartyPage ClickSearch_Button()
        {
            this.WebDriverWrapper.FindAndClick(searchButton, How.XPath);

            return this;
        }
        public SearchPartyPage ClickClearAll_Button()
        {
            this.WebDriverWrapper.FindAndClick(clearAllButton, How.XPath);

            return this;
        }
        public AddDetailsToExistingAssociatedPartyPage ClickFirstPartyLink_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(firstLinkButton, How.XPath);

            data.AddDetailsToExistAssociatedPartyPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.AddDetailsToExistAssociatedPartyPopUpPageId);

            return new AddDetailsToExistingAssociatedPartyPage(this);
        }
        public AddEditAssociatedPartyPage ClickAddNew_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(addNewButton, How.XPath);

            data.AddEditAssociatedPartyPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.AddEditAssociatedPartyPopUpPageId);

            return new AddEditAssociatedPartyPage(this);
        }
        #endregion
        #region Set actions
        public SearchPartyPage SetName_TextField(string partyName)
        {
            if (partyName != null)
            {
                this.WebDriverWrapper.FindAndSetText(nameTextField, partyName, How.XPath);
            }
            return this;
        }
        public SearchPartyPage SetRef_TextField(string partyReference)
        {
            if (partyReference != null)
            {
                this.WebDriverWrapper.FindAndSetText(refTextField, partyReference, How.XPath);
            }
            return this;
        }
        public SearchPartyPage SelectDomicile_DropdownList(string partyDomicilie)
        {
            if (partyDomicilie != null)
            {
                this.WebDriverWrapper.FindAndClick(domicilieDdl + $"/option[text()='{partyDomicilie}']", How.XPath);
            }
            return this;
        }
        public SearchPartyPage SelectMamberGroup_DropdownList(string partyMemberGroup)
        {
            if (partyMemberGroup != null)
            {
                this.WebDriverWrapper.FindAndClick(memberGroupDdl + $"/option[text()='{partyMemberGroup}']", How.XPath);
            }
            return this;
        }
        #endregion
        #region Other actions
        #endregion
    }
}
