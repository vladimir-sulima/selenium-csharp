using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class QuoteDetailsTabData
    {
        public string MemberAssuredCapacities { get; set; }
        public bool IsClearMemberCapacities { get; set; }
        public string EntryType { get; set; }
        public string QuoteType { get; set; }
        public string Underwriter { get; set; }
        public bool IsSeparateCommissionNote { get; set; }
        public string ValidTo { get; set; }
        public string PolicyCondition { get; set; }
        public bool IsClearPolicyConditions { get; set; }
        public string TradingLimitsStandardText { get; set; }
    }
}
