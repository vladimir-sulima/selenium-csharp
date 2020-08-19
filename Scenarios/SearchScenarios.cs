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
    public static class SearchScenarios
    {
        public static MainWorkflowPage PerformQuickSearch_Quote(this StartPage page, string quoteReference, MainFlowData data)
        {
            return page
            .ExpandQuickSearch_DropdownMenu()
            .SetQiuckSearchDropDown_Value("Quote")
            .SetQuickSearch_TextField(quoteReference)
            .ClickQuickSearch_Button(data.WindowsHandlerData)
            .SwitchToQuoteDetailsPage(data.WindowsHandlerData);
        }
        public static MainWorkflowPage PerformQuickSearch_Policy(this StartPage page, string policyReference, MainFlowData data)
        {
            return page
            .ExpandQuickSearch_DropdownMenu()
            .SetQiuckSearchDropDown_Value("Policy")
            .SetQuickSearch_TextField(policyReference)
            .ClickQuickSearch_Button(data.WindowsHandlerData)
            .SwitchToQuoteDetailsPage(data.WindowsHandlerData);
        }
        public static SearchRiskPage PerformVesselSearch(this RisksTabPage page, MainFlowData data)
        {
            return page
                .ClickAdd_Button(data.WindowsHandlerData)
                .SetVesselName_TextField(data.VesselSearchData.VesselName)
                .SetRiskReference_TextField(data.VesselSearchData.RiskReference)
                .SetMemberName_TextField(data.VesselSearchData.MemberName)
                .SetImoNumber_TextField(data.VesselSearchData.ImoNumber)
                .SetMemberNumber_TextField(data.VesselSearchData.MemberNumber)
                .SelectVesselTariffGroup_DropdownList(data.VesselSearchData.VesselTariffGroup)
                .SetVesselNumber_TextField(data.VesselSearchData.VesselNumber)
                .SelectMemberDomicile_DropdownList(data.VesselSearchData.MemberDomicile)
                .ClickSearch_Button();
        }
        public static SearchPartyPage PerformAssociatedPartySearch(this AssociatedPartiesTabPage page, MainFlowData data)
        {
            return page
                .ClickAdd_Button(data.WindowsHandlerData)
                .SetName_TextField(data.PartySearchData.Name)
                .SetRef_TextField(data.PartySearchData.Ref)
                .SelectDomicile_DropdownList(data.PartySearchData.Domicile)
                .SelectMamberGroup_DropdownList(data.PartySearchData.MemberGroup)
                .ClickSearch_Button();
        }

    }
}
