using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class GetValuesScenarios
    {
        public static MainWorkflowPage GetQuoteDetails(this MainWorkflowPage page, QuotePolicyData data)
        {
            return page
                .GetQuoteReferenceValue(data)
                .GetExpiryDateValue(data)
                .GetPolicyPeriodValue(data)
                .GetAssuredOrMemberValue(data)
                .GetQuoteStatusValue(data)
                .GetMemberCreditStatusValue(data);
        }
    }
}
