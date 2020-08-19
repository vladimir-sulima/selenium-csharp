using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.Tabs.AssociatedParties
{
    public class AddEditAssociatedPartyPage : UIPage
    {
        public AddEditAssociatedPartyPage(IUIPage page) : base(page)
        {
        }

        #region Locators
        const string firstNameTextField = "//input[contains(@id, 'FirstName')]";
        const string lastNameOrOrganisationNameTextField = "//input[contains(@id, 'SecondName')]";
        const string fromDateTextField = "(//input[contains(@id, 'StartDateString')])[1]";
        const string toDateTextField = "(//input[contains(@id, 'EndDateString')])[1]";
        const string addressNameTextField = "(//input[contains(@id, 'AddressName')])[2]";
        const string street1TextField = "(//input[contains(@id, 'Street1')])[2]";
        const string street2TextField = "(//input[contains(@id, 'Street2')])[2]";
        const string cityTextField = "(//input[contains(@id, '_City')])[2]";
        const string postalCodeTextField = "(//input[contains(@id, 'Postcode')])[2]";
        const string phoneTextField = "(//input[contains(@id, 'Phone')])[2]";
        const string faxTextField = "(//input[contains(@id, 'Fax')])[2]";
        const string emailTextField = "(//input[contains(@id, 'Email')])[2]";
        const string descriptionTextArea = "//textarea[contains(@id, 'Description')]";
        const string capacityTextList = "//select[contains(@id, 'PartyRoleSubTypesMultiSelect')]";
        const string partyRoleDdl = "//select[contains(@id, 'PartyRoleTypeValue')]";
        const string clauseDdl = "//select[contains(@id, 'customDropdownList')]";
        const string countryDdl = "//select[contains(@id, 'GeographicAreaId')]";
        const string saveButton = "//input[@value='Save']";
        const string cancelButton = "//input[@value='Cancel']";
        #endregion
        #region Click actions
        public AssociatedPartiesTabPage ClickSave_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(saveButton, How.XPath);

            this.WaitForWidowClosed(data.AddEditAssociatedPartyPopUpPageId);
            this.WaitForWidowClosed(data.SearchPartyPageId);

            this.SwitchToWindow(data.MainFlowPageId);

            return new AssociatedPartiesTabPage(this);
        }
        public MainWorkflowPage ClickCancel_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(cancelButton, How.XPath);

            this.SwitchToWindow(data.MainFlowPageId);

            return new MainWorkflowPage(this);
        }
        #endregion
        #region Set actions 
        public AddEditAssociatedPartyPage SelectPartyRole_DropdownList(string partyRole)
        {
            if (partyRole != null)
            {
                this.WebDriverWrapper.FindAndClick(partyRoleDdl + $"/option[text()='{partyRole}']", How.XPath);
            }

            return this;
        }
        public AddEditAssociatedPartyPage SetFirstName_TextField(string firstName)
        {
            if (firstName != null)
            {
                this.WebDriverWrapper.FindAndSetText(firstNameTextField, firstName, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetLastNameOrOrganisationName_TextField(string lastNamoOrOrganisationName)
        {
            if (lastNamoOrOrganisationName != null)
            {
                this.WebDriverWrapper.FindAndSetText(lastNameOrOrganisationNameTextField, lastNamoOrOrganisationName, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetDescription_TextField(string description)
        {
            if (description != null)
            {
                this.WebDriverWrapper.FindAndSetText(descriptionTextArea, description, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetFromDate_TextField(string fromDate)
        {
            if (fromDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(fromDateTextField, fromDate, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetToDate_TextField(string toDate)
        {
            if (toDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(toDateTextField, toDate, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetCapacity_TextList(string[] capacity)
        {
            if (capacity != null)
            {
                if (capacity.Count() > 0)
                {
                    Actions buttonToHold = new Actions(this.WebDriverWrapper.WebDriver);
                    buttonToHold.KeyDown(Keys.Control);

                    foreach (var cap in capacity)
                    {
                        this.WebDriverWrapper.FindAndClick(capacityTextList + $"/option[text()='{cap}']", How.XPath);
                    }

                    buttonToHold.KeyUp(Keys.Control);
                }
            }
            return this;
        }
        public AddEditAssociatedPartyPage SelectClause_DropdownList(string clause)
        {
            if (clause != null)
            {
                this.WebDriverWrapper.FindAndClick(clauseDdl + $"/option[text()='{clause}']", How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetAddressName_TextField(string addressName)
        {
            if (addressName!=null)
            {
                this.WebDriverWrapper.FindAndSetText(addressNameTextField, addressName, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetStreet1_TextField(string street1)
        {
            if (street1!=null)
            {
                this.WebDriverWrapper.FindAndSetText(street1TextField, street1, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetStreet2_TextField(string street2)
        {
            if(street2!=null)
            {
                this.WebDriverWrapper.FindAndSetText(street2TextField, street2, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetCity_TextField(string city)
        {
            if(city!=null)
            {
                this.WebDriverWrapper.FindAndSetText(cityTextField, city, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetPostalCode_TextField(string postalCode)
        {
            if (postalCode!=null)
            {
                this.WebDriverWrapper.FindAndSetText(postalCodeTextField, postalCode, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SelectCountry_DropdownList(string country)
        {
            if (country!=null)
            {
                this.WebDriverWrapper.FindAndClick(countryDdl + $"/option[text()='{country}']", How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetPhone_TextField(string phone)
        {
            if (phone!=null)
            {
                this.WebDriverWrapper.FindAndSetText(phoneTextField, phone, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetFax_TextField(string fax)
        {
            if(fax!=null)
            {
                this.WebDriverWrapper.FindAndSetText(faxTextField, fax, How.XPath);
            }
            return this;
        }
        public AddEditAssociatedPartyPage SetEmail_TextField(string email)
        {
            if(email!=null)
            {
                this.WebDriverWrapper.FindAndSetText(emailTextField, email, How.XPath);
            }
            return this;
        }
        #endregion
    }
}
