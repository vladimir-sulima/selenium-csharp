using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class CreateQuoteScenarios 
    {
        public static MainWorkflowPage CreateVesselRiskQuote(this StartPage page, MainFlowData data)
        {
            return page
                .ClickCreateQuote_Button(data.WindowsHandlerData)
                .SelectRiskType_DropdownList(data.QuoteCreationData.RiskType)
                .SelectProductType_DropdownList(data.QuoteCreationData.ProductType)
                .SelectPolicyBilling_DropdownList(data.QuoteCreationData.PolicyBilling)
                .SelectTemplateType_DropdownList(data.QuoteCreationData.TemplateType)
                .SelectTemplateCategory_DropdownList(data.QuoteCreationData.TemplateCategory)
                .SelectTemplateName_DropdownList(data.QuoteCreationData.TemplateName)
                .SetFromDate_TextFiedl(data.QuoteCreationData.FromDate)
                .SetToDate_TextFiedl(data.QuoteCreationData.ToDate)
                .SelectTBC_RadioButtons(data.QuoteCreationData.IsDateToBeConfirmed)
                .ClickSubmit_Button(data.WindowsHandlerData);
        }
    }
}
