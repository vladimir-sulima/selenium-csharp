using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class QuotePolicyData
    {
        public string QuoteReference { get; set; }
        public string ExpiryDate { get; set; }
        public string PolicyPeriod { get; set; }
        public string AssuredOrMember { get; set; }
        public string QuoteStatus { get; set; }
        public string MemberCreditStatus { get; set; }
        public string VersionNumber { get; set; }
        public string Broker { get; set; }
        public string PeriodOfInsurance { get; set; }
        public string Underwriter { get; set; }
        public string EntryType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}
    