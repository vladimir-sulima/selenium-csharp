using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class MemberManipulationScenarios
    {
        public static QuoteDetailsPage SelectExistingMember(this QuoteDetailsPage page, MainFlowData data)
        {
            return page
                .ClickSelectMember_Hyperlink(data.WindowsHandlerData)
                .SetMemberSearchName(data.MemberData.Name)
                .SetMemberSearchReference(data.MemberData.Reference)
                .ClickSearch_Button()
                .SelectFirstMemberInList(data.WindowsHandlerData);
        }
        public static QuoteDetailsPage SelectNewMember(this QuoteDetailsPage page, MainFlowData data)
        {
            return page
                .ClickSelectMember_Hyperlink(data.WindowsHandlerData)
                .SetMemberSearchName(data.MemberData.Name)
                .SetMemberSearchReference(data.MemberData.Reference)
                .ClickSearch_Button()
                .ClickAddNew_Button(data.WindowsHandlerData)
                .SetPartyRole_TextField(data.MemberData.PartyRole)
                .SetFirstName_TextField(data.MemberData.FirstName)
                .SetLastNameOrOrganisationName_TextField(data.MemberData.LastNameOrOrganisationName)
                .SelectDomicilie_DropdownList(data.MemberData.Domicilie)
                .SelectGroup_DropdownList(data.MemberData.Group)
                .SetAddressName_TextField(data.MemberData.AddressName)
                .SetStreet1_TextField(data.MemberData.Street1)
                .SetStreet2_TextField(data.MemberData.Street2)
                .SetCity_TextField(data.MemberData.City)
                .SelectCountry_DropdownList(data.MemberData.Country)
                .SetPostalCode_TextField(data.MemberData.PostalCode)
                .SetPhone_TextField(data.MemberData.Phone)
                .SetFax_TextField(data.MemberData.Fax)
                .SetEmail_TextField(data.MemberData.Email)
                .ClickSave_Button(data.WindowsHandlerData);
        }
    }
}
