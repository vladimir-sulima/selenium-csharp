using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using Sigma_Automation.Page.Quote.BindQuote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class BindQuoteScenarios
    {
        public static BindQuoteSelectDocumentationPage BindQuote(this MainWorkflowPage page, MainFlowData data)
        {
            return page
                .ClickBindQuote_Button(data.WindowsHandlerData)
                .ClickSubmit_Button(data.WindowsHandlerData)
                .WaitForQuoteValidationPageDisplayedDisplayed(data.WindowsHandlerData)
                .SelectContinue_RadioButton()
                .ClickSubmit_Button();
        }
        public static QuoteReinsurancePage ManageInvoiceDetails(this BindQuoteSelectDocumentationPage page, MainFlowData data)
        {
            return page
                .WaitForBindQuoteSelectDocumentationPageDisplayed()
                .SelectFormTradingCertificate_RadioButton(data.BindQuoteSelectDocumentationData.IsShortFormTradingCertificate)
                .SelectLongFormCertificate_DropdownList(data.BindQuoteSelectDocumentationData.LongFormCertificate)
                .SelectInvoice_DropdownList(data.BindQuoteSelectDocumentationData.Invoice)
                .SelectIvoiceAddressee_DropdownList(data.BindQuoteSelectDocumentationData.InvoiceAddressee)
                .SelectInvoiceFormat_DropdownList(data.BindQuoteSelectDocumentationData.InvoiceFormat)
                .SelectFirsAddress_DropdownList(data.BindQuoteSelectDocumentationData.InvoiceAddressee)
                .SelectPrintMemberAddress_RadioButton(data.BindQuoteSelectDocumentationData.PrintMemberAddress)
                .SelectFirstSendToBrokerContact_DropdownList()
                .SetPremiumComments_TextArea(data.BindQuoteSelectDocumentationData.Comments)
                .SelectContinue_RadioButton()
                .ClickSubmit_Button();
        }
        public static StartPage ManageQuoteReinsurance(this QuoteReinsurancePage page, MainFlowData data)
        {
            return page
                .WaitForQuoteReinsurancePageDisplayed()
                .ClickAdd_Button(data.WindowsHandlerData)
                .SetComments_TextArea(data.BindQuoteAddPatternData.Comments)
                .ClickSaveButton(data.WindowsHandlerData)
                .SelectBind_RadioButton()
                .ClickSubmitButton();
        }

    }
}
