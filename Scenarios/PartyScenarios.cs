using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using Sigma_Automation.Page.Quote.Tabs.AssociatedParties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class PartyScenarios
    {
        public static AssociatedPartiesTabPage AddExistingParty(this AssociatedPartiesTabPage page, MainFlowData data)
        {
            return page
                .PerformAssociatedPartySearch(data)
                .SelectFirstPartyFromListAndSetDetails(data);
        }
        public static AssociatedPartiesTabPage SelectFirstPartyFromListAndSetDetails(this SearchPartyPage page, MainFlowData data)
        {
            return page
                .ClickFirstPartyLink_Button(data.WindowsHandlerData)
                .SetAssociatedPartyDetails(data);
        }
        public static AssociatedPartiesTabPage SetAssociatedPartyDetails(this AddDetailsToExistingAssociatedPartyPage page, MainFlowData data)
        {
            return page
                .SetDescription_TextAreaField(data.ExistingPartyData.Description)
                .SelectRole_DropdownList(data.ExistingPartyData.Role)
                .SetFromDate_TextField(data.ExistingPartyData.FromDate)
                .SetToDate_TextField(data.ExistingPartyData.ToDate)
                .SelectCapacity_TextList(data.ExistingPartyData.Capacity)
                .SelectClause_DropdownList(data.ExistingPartyData.Clause)
                .ClickSave_Button(data.WindowsHandlerData);
        }
        public static AssociatedPartiesTabPage AddNewParty(this AssociatedPartiesTabPage page, MainFlowData data)
        {
            return page
                .PerformAssociatedPartySearch(data)
                .ClickAddNew_Button(data.WindowsHandlerData)
                .SelectPartyRole_DropdownList(data.PartyData.PartyRole)
                .SetFirstName_TextField(data.PartyData.FirstName)
                .SetLastNameOrOrganisationName_TextField(data.PartyData.LastNameOrOrganisationName)
                .SetDescription_TextField(data.PartyData.Description)
                .SetFromDate_TextField(data.PartyData.FromDate)
                .SetToDate_TextField(data.PartyData.ToDate)
                .SetCapacity_TextList(data.PartyData.Capacity)
                .SelectClause_DropdownList(data.PartyData.Clause)
                .SetAddressName_TextField(data.PartyData.AddressName)
                .SetStreet1_TextField(data.PartyData.Street1)
                .SetStreet2_TextField(data.PartyData.Street2)
                .SetCity_TextField(data.PartyData.City)
                .SetPostalCode_TextField(data.PartyData.PostalCode)
                .SelectCountry_DropdownList(data.PartyData.Country)
                .SetPhone_TextField(data.PartyData.Phone)
                .SetFax_TextField(data.PartyData.Fax)
                .SetEmail_TextField(data.PartyData.Email)
                .ClickSave_Button(data.WindowsHandlerData);
            //TODO - add waiting for Party displayed
        }
    }
}
