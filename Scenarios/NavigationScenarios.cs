using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using Sigma_Automation.Page.Quote.Tabs.Covers;
using Sigma_Automation.Page.Quote.Tabs.Premiums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class NavigationScenarios
    {
        public static RisksTabPage NavidateToRisksTab(this MainWorkflowPage page)
        {
            return page
                .ClickRisksTab();
        }
        public static AssociatedPartiesTabPage NavigateToAssociatedPartyTab(this MainWorkflowPage page)
        {
            return page.ClickAssociatedPartiesTab();
        }
        public static BrokersTabPage NavigateToBrokersTab(this MainWorkflowPage page)
        {
            return page.ClickBrokersTab();
        }
        public static CoversTabPage NavigateToCoversTab(this MainWorkflowPage page)
        {
            return page.ClickCoversTab()
                .WaitForCoverIFrameAndButtonsDisplayed();
        }
        public static PremiumsTabPage NavigateToPremiumsTab(this MainWorkflowPage page)
        {
            page.WebDriverWrapper.WebDriver.SwitchTo().DefaultContent();

            return page.ClickPremiumsTab()
                .WaitTillPremiumsPageDisplayed();
        }
        public static PremiumsTabPage NavigateToPremiumsTab_CoverDetailsFrame(this MainWorkflowPage page, MainFlowData data)
        {
            return page.ClickPremiumsTab()
                //TODO - remove next method
                .WaitTillCoverLevelDetailsFrameDisplayed(data.WindowsHandlerData);
        }
        public static PremiumsTabPage NavigateToPremiumsTab_RisksPremiumFrame(this MainWorkflowPage page, MainFlowData data)
        {
            return page.ClickPremiumsTab()
                //TODO - remove next method
                .WaitTillRisksPremiumFrameDisplayed(data.WindowsHandlerData);
        }
        public static PremimInstalmentsTabPage NavigateToPremiumIstalmentsTab(this MainWorkflowPage page)
        {
            //page.WebDriverWrapper.WebDriver.SwitchTo().DefaultContent();

            return page.ClickPremiumInstalmentsTab()
            .WaitTillPremiumInstalmentsFrameDisplayed();
        }
    }
}
