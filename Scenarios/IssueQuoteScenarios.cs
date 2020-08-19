using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class IssueQuoteScenarios
    {
        public static StartPage IssueQuote(this MainWorkflowPage page)
        {
            return page
                .SelectIssue_RadioButton()
                .CickSubmit_Button()
                .SwitchToIssueQuotePage()
                .WaitForIssueQuotePageDisplayed()
                .SelectIssue_RadioButton()
                .ClickSubmit_Button();
        }
    }
}
