using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class QuoteCreationData
    {
        public string RiskType { get; set; }
        public string ProductType { get; set; }
        public string PolicyBilling { get; set; }
        public string TemplateType { get; set; }
        public string TemplateCategory { get; set; }
        public string TemplateName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsDateToBeConfirmed { get; set; }
    }
}
