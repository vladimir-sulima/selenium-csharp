using Sigma_Automation.Dto;
using Sigma_Automation.Page.Quote.Tabs.Covers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class CoversScenarios
    {
        public static CoversTabPage GetCoversInfo(this CoversTabPage page, MainFlowData data)
        {
            return page
                .GetAttachedCoverList(data.CoversData);
        }
        public static CoversTabPage RemoveCoversExcept(this CoversTabPage page, MainFlowData data, string[] coversToLeft)
        {
            page.GetCoversInfo(data);
            data.CoversData.SetCoversToLeft(coversToLeft);

            return page
                .LeaveCoversByName(data);
        }
    }
}
