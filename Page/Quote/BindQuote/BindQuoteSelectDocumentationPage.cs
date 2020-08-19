using Sigma_Automation.Page.Quote.BindQuote;
using System.Linq;

namespace Sigma_Automation.Page
{
    public class BindQuoteSelectDocumentationPage : UIPage
    {
        public BindQuoteSelectDocumentationPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string yesShortFormTradingCertificateRadioButton = "//input[contains(@id, 'GenerateShortFormTradingCertificates') and @value='true']";
        const string noShortFormTradingCertificateRadioButton = "//input[contains(@id, 'GenerateShortFormTradingCertificates') and @value='false']";
        const string yesPrintMemberAddressRadioButton = "//input[contains(@id, 'PrintMemberAddress') and @value='true']";
        const string noPrintMemberAddressRadioButton = "//input[contains(@id, 'PrintMemberAddress') and @value='false']";
        const string longFormCertificatesDdl = "//select[contains(@id, 'LongFormCertificateTypeValue')]";
        const string invoiceDdl = "//select[contains(@id, 'InvoiceTypeValue')]";
        const string invoiceAddresseeDdl = "//select[contains(@id, 'InvoiceAddressTypeValue')]";
        const string addressDdl = "//select[@id='addressDdl']";
        const string invoiceFormatDdl = "//select[contains(@id, 'InvoiceFormatValue')]";
        const string premiumCommentsTextArea = "//textarea[contains(@id, 'PremiumComments')]";
        const string sendToBrokerContactDdl = "//*[@id='sendToDdl']";

        const string bindQuoteSection = "//span[text()='Bind Quote']";
        const string continueRadioButton = "//input[@value='Continue']";
        const string submitButton = "//input[contains(@id,'btnSubmit')]";
        #endregion
        #region Click actions
        public QuoteReinsurancePage ClickSubmit_Button()
        {
            this.WebDriverWrapper.FindAndClick(submitButton, How.XPath);

            return new QuoteReinsurancePage(this);
        }
        #endregion
        #region Set actions
        public BindQuoteSelectDocumentationPage SelectContinue_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(continueRadioButton, How.XPath);

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectFormTradingCertificate_RadioButton(bool isShortForm)
        {
            if (isShortForm == true)
            {
                this.WebDriverWrapper.FindAndClick(yesShortFormTradingCertificateRadioButton, How.XPath);
            }

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectLongFormCertificate_DropdownList(string longFormCertificate)
        {
            this.WebDriverWrapper.FindAndClick(longFormCertificatesDdl + $"/option[text()='{longFormCertificate}']", How.XPath);

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectInvoice_DropdownList(string invoice)
        {
            this.WebDriverWrapper.FindAndClick(invoiceDdl + $"/option[text()='{invoice}']", How.XPath);

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectIvoiceAddressee_DropdownList(string invoiceAddressee)
        {
            this.WebDriverWrapper.FindAndClick(invoiceAddresseeDdl + $"/option[text()='{invoiceAddressee}']", How.XPath);

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectInvoiceFormat_DropdownList(string invoiceFormat)
        {
            this.WebDriverWrapper.FindAndClick(invoiceFormatDdl + $"/option[text()='{invoiceFormat}']", How.XPath);

            return this;
        }
        public BindQuoteSelectDocumentationPage SelectPrintMemberAddress_RadioButton(bool printMemberAddress)
        {
            if (printMemberAddress == true)
            {
                this.WebDriverWrapper.FindAndClick(yesPrintMemberAddressRadioButton, How.XPath);
            }
            return this;
        }
        public BindQuoteSelectDocumentationPage SelectFirsAddress_DropdownList(string invoiceAddressee)
        {
            if (invoiceAddressee == "Member")
            {
                this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(addressDdl).Any());
                this.WebDriverWrapper.FindAndClick("(" + addressDdl + "/option)[2]", How.XPath);
            }
            return this;
        }
        public BindQuoteSelectDocumentationPage SelectFirstSendToBrokerContact_DropdownList()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(sendToBrokerContactDdl).Any());
            this.WebDriverWrapper.FindAndClick("(" + sendToBrokerContactDdl + "/option)[2]", How.XPath);

            return this;
        }

        public BindQuoteSelectDocumentationPage SetPremiumComments_TextArea(string comments)
        {
            if (comments != null)
            {
                this.WebDriverWrapper.FindAndSetText(premiumCommentsTextArea, comments, How.XPath);
            }

            return this;
        }

        #endregion
        #region Other actions
        public BindQuoteSelectDocumentationPage WaitForBindQuoteSelectDocumentationPageDisplayed()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(bindQuoteSection).Any());

            return this;
        }
        #endregion

    }
}