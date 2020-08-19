using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page.Quote.BindQuote
{
    public class QuoteReinsurancePage : UIPage
    {
        public QuoteReinsurancePage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string bindRadioButton = "//input[@value='Bind']";
        const string addButton = "//input[@value='Add']";
        const string subbmitButton = "//input[@value='Submit']";
        #endregion
        #region Click actions
        public BindQuoteAddPatternPopUpPage ClickAdd_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(addButton, How.XPath);

            data.BindQuoteAddPatternPopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            SwitchToWindow(data.BindQuoteAddPatternPopUpPageId);

            return new BindQuoteAddPatternPopUpPage(this);
        }
        public StartPage ClickSubmitButton()
        {
            this.WebDriverWrapper.FindAndClick(subbmitButton, How.XPath);

            return new StartPage(this.WebDriverWrapper);
        }
        #endregion
        #region Set actions
        public QuoteReinsurancePage SelectBind_RadioButton()
        {
            this.WebDriverWrapper.FindAndClick(bindRadioButton, How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        public QuoteReinsurancePage WaitForQuoteReinsurancePageDisplayed()
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(bindRadioButton).Any());
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(addButton).Any());
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(subbmitButton).Any());

            return this;
        }
        #endregion
    }
}
