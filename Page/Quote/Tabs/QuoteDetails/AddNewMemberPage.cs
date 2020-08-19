using Sigma_Automation.Dto;

namespace Sigma_Automation.Page
{
    public class AddNewMemberPage : UIPage
    {
        public AddNewMemberPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string partyRoleInputTextField = "//input[contains(@name, 'PartyRoleTypeValue')]";
        const string firstNameInputTextField = "//input[contains(@name, 'FirstName')]";
        const string secondOrOrganisationNameInputTextField = "//input[contains(@name, 'SecondName')]";
        const string domicilieDropdownList = "//select[contains(@name, 'PartyGeographicAreaIdDomicile')]";
        const string groupDropdownList = "//select[contains(@name, 'PartyMemberGroupId')]";
        const string addressNameInputTextField = "//input[contains(@name, 'AddressName')]";
        const string street1InputTextField = "//input[contains(@name, 'Street1')]";
        const string street2InputTextField = "//input[contains(@name, 'Street2')]";
        const string cityInputTextField = "//input[contains(@name, 'City') and @type='text']";
        const string postalCodeInputTextField = "//input[contains(@name, 'Postcode')]";
        const string countryDropdownList = "(//select[contains(@name, 'GeographicAreaId')])[2]";
        const string phoneInputTextField = "//input[contains(@name, 'Phone')]";
        const string faxInputTextField = "//input[contains(@name, 'Fax')]";
        const string emailInputTextField = "//input[contains(@name, 'Email')]";
        const string saveAndCloseButton = "//input[@value='Save']";
        #endregion
        #region Click actions
        public QuoteDetailsPage ClickSave_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(saveAndCloseButton, How.XPath);

            this.WaitForWidowClosed(data.AddNewMemberPageId);
            this.WaitForWidowClosed(data.AddAssuredMemberPageId);

            this.SwitchToWindow(data.MainFlowPageId);

            return new QuoteDetailsPage(this);
        }
        #endregion
        #region Set actions
        public AddNewMemberPage SetPartyRole_TextField(string partyRole)
        {
            if (partyRole != null)
            {
                this.WebDriverWrapper.FindAndSetText(partyRoleInputTextField, partyRole, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetFirstName_TextField(string firstName)
        {
            if (firstName != null)
            {
                this.WebDriverWrapper.FindAndSetText(firstNameInputTextField, firstName, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetLastNameOrOrganisationName_TextField(string lastNameOrOrganisationName)
        {
            if (lastNameOrOrganisationName != null)
            {
                this.WebDriverWrapper.FindAndSetText(secondOrOrganisationNameInputTextField, lastNameOrOrganisationName, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SelectDomicilie_DropdownList(string domicilie)
        {
            if (domicilie != null)
            {
                this.WebDriverWrapper.FindAndClick(domicilieDropdownList + $"/option[text()='{domicilie}']", How.XPath);
            }
            return this;
        }
        public AddNewMemberPage SelectGroup_DropdownList(string group)
        {
            if (group != null)
            {
                this.WebDriverWrapper.FindAndClick(groupDropdownList + $"/option[text()='{group}']", How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetAddressName_TextField(string addressName)
        {
            if (addressName != null)
            {
                this.WebDriverWrapper.FindAndSetText(addressNameInputTextField, addressName, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetStreet1_TextField(string street1)
        {
            if (street1 != null)
            {
                this.WebDriverWrapper.FindAndSetText(street1InputTextField, street1, How.XPath);
            }
            return this;
        }
        public AddNewMemberPage SetStreet2_TextField(string street2)
        {
            if (street2 != null)
            {
                this.WebDriverWrapper.FindAndSetText(street2InputTextField, street2, How.XPath);
            }
            return this;
        }
        public AddNewMemberPage SetCity_TextField(string city)
        {
            if (city != null)
            {
                this.WebDriverWrapper.FindAndSetText(cityInputTextField, city, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetPostalCode_TextField(string postalCode)
        {
            if (postalCode != null)
            {
                this.WebDriverWrapper.FindAndSetText(postalCodeInputTextField, postalCode, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SelectCountry_DropdownList(string country)
        {
            if (country != null)
            {
                this.WebDriverWrapper.FindAndClick(countryDropdownList + $"/option[text()='{country}']", How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetPhone_TextField(string phone)
        {
            if (phone != null)
            {
                this.WebDriverWrapper.FindAndSetText(phoneInputTextField, phone, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetFax_TextField(string fax)
        {
            if (fax != null)
            {
                this.WebDriverWrapper.FindAndSetText(faxInputTextField, fax, How.XPath);
            }

            return this;
        }
        public AddNewMemberPage SetEmail_TextField(string email)
        {
            if (email != null)
            {
                this.WebDriverWrapper.FindAndSetText(emailInputTextField, email, How.XPath);
            }

            return this;
        }
        #endregion
    }
}