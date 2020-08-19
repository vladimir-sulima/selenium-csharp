using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using Sigma_Automation.Page.Quote.Tabs.Premiums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class PremiumsScenarios
    {
        public static PremiumsTabPage ManagePremiumsFinancialData(this PremiumsTabPage page, MainFlowData data)
        {
            //TODO: Refactor if possible
            //Horrable idea, but woks
            //Reason: Unable switch to previous page
            page
                .GetCurrentFlowUrl(data)
                .ClickEditFinancialData_Button(data.WindowsHandlerData)
                .WaitForEditFinancialDataPopupPageDisplayed()
                .SelectCurrency_DropdownList(data.FinancialData.Currency)
                .SelectApplicationTax_DropdownList(data.FinancialData.ApplicableTax)
                .SetPremiumComments_TextArea(data.FinancialData.Comments)
                .SelectFlagAtRenewals_RadioButtons(data.FinancialData.FlagAtRenewals)
                .SetRenewalComments_TextArea(data.FinancialData.RenewalComments)
                .ClickSave_Button(data);


            return page;
        }
        public static PremiumsTabPage ManageInstallmentsAndCommissionsData(this PremiumsTabPage page, MainFlowData data)
        {
            //TODO Remove after solution with switch between widows will be solved
            return page.NavigateToPremiumsTab_CoverDetailsFrame(data)
                
                .ClickFirsEditCoverLevelDetails_Button(data.WindowsHandlerData)
                .SetComissionPercentage_TextField(data.InstalmentsAndCommissionData.CommissionPercentage)
                .SelectCallType_DropdownList(data.InstalmentsAndCommissionData.CallType)
                .SelectPremiumType_DropdownList(data.InstalmentsAndCommissionData.PremiumType)
                .ClickUpdateAllCovers_CheckBox()
                .ClickSave_Button(data);
        }
        public static PremiumsTabPage ManageSetAndUpdatePremiumData(this PremiumsTabPage page, MainFlowData data)
        {
            //var cover = "Yacht Legal Costs Cover";
            //foreach (var cover in data.CoversData.CoversToLeft)
            //{
                page.NavigateToPremiumsTab_RisksPremiumFrame(data)
                  .ClickSetUpdatePremium_Button(data.WindowsHandlerData)
                  //.SelectCover_DropdownList(cover)
                  .SetAmount_TextField(data.SetUpdatePremiumsData.Ammount)
                  .CliclSave_Button(data);
            //}
            return page;
        }
    }
}
