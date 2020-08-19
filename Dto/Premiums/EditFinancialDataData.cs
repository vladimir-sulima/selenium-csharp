namespace Sigma_Automation.Dto
{
    public class EditFinancialDataData
    {
        public string Currency { get; set; }
        public string ApplicableTax { get; set; }
        public string Comments { get; set; }
        public bool FlagAtRenewals { get; set; }
        public string RenewalComments { get; set; }
    }
}