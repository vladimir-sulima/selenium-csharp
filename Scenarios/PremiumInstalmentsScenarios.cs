using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class PremiumInstalmentsScenarios
    {
        public static PremimInstalmentsTabPage SetInstalmentDetails(this PremimInstalmentsTabPage page, MainFlowData data)
        {
            return page
                .ClickEdit_Button(data.WindowsHandlerData)
                .SelectWillTheInstalmentPatternBeBespoke_RadioButton(data.InstalmentsDetailsData.IsInstalmentPatternBespoke)
                .SelectInstalmentsPattern_DropdownList(data.InstalmentsDetailsData.InstalmentsPattern)
                .ClickCkeckValidity_Button()
                .ClickConfirmAndSave_Button(data.WindowsHandlerData);
        }
    }
}
