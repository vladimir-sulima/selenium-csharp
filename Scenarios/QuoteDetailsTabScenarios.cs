using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class QuoteDetailsTabScenarios
    {
        public static QuoteDetailsPage ManageQuoteDetails(this QuoteDetailsPage page, MainFlowData data )
        {
            return page
                .SelectMemberAssuredCapacities_TextList(data.QuoteDetailsTabData.MemberAssuredCapacities)
                .SelectClearMemberCapacties_RadioButton(data.QuoteDetailsTabData.IsClearMemberCapacities)
                .SelectEntryType_DropdownList(data.QuoteDetailsTabData.EntryType)
                .SelectQuoteType_DropdownList(data.QuoteDetailsTabData.QuoteType)
                .SelectUnderwriter_DropdownList(data.QuoteDetailsTabData.Underwriter)
                .SelectSeparateCommisionNote_RadioButton(data.QuoteDetailsTabData.IsSeparateCommissionNote)
                .SetValidTo_TextField(data.QuoteDetailsTabData.ValidTo)
                .SelectPolicyConditions_TextList(data.QuoteDetailsTabData.PolicyCondition)
                .SelectClearPolicyConditions_RadioButton(data.QuoteDetailsTabData.IsClearPolicyConditions)
                .SetTradingLimitStandardText_DropdownList(data.QuoteDetailsTabData.TradingLimitsStandardText);
        }
        //TODO remove after switch between frames issue will be resolved
        public static MainWorkflowPage SaveQuoteDetails(this QuoteDetailsPage page, MainFlowData data)
        {
            return page
                .SelectSave_RadioButton()
                .CickSubmit_Button()
                .WaitForQuoteDataSaved(data.WindowsHandlerData);
        }
    }
}
