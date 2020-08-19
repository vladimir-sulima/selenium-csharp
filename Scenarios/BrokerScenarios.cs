using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class BrokerScenarios
    {
        public static BrokersTabPage AddBrokerToPolicy(this BrokersTabPage page, MainFlowData data)
        {
            return page
                .PerformBrokerSearch(data)
                .ClickFirstLink_Button(data.WindowsHandlerData);
        }
        public static SelectBrokerToAddToPolicyPage PerformBrokerSearch(this BrokersTabPage page, MainFlowData data)
        {
            return page
                .ClickAdd_Button(data.WindowsHandlerData)
                .SetFullName_TextField(data.BrokerData.FullName)
                .SetBrokerReference_TextField(data.BrokerData.Reference)
                .ClickSearch_Button();
        }
    }
}
