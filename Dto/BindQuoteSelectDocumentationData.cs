namespace Sigma_Automation.Dto
{
    public class BindQuoteSelectDocumentationData
    {
        public bool IsShortFormTradingCertificate { get; set; }
        public string LongFormCertificate { get; set; }
        public string Invoice { get; set; }
        public string InvoiceAddressee { get; set; }
        public string InvoiceFormat { get; set; }
        public bool PrintMemberAddress { get; set; }
        public string Comments { get; set; }
    }
}