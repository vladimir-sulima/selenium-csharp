using Sigma_Automation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Page
{
    public class StartPage : UIPage
    {
        public StartPage(WebDriverWrapper page) : base(page)
        {
        }
        #region Locators
        const string createQuoteButton = "createQuoteButton";
        #endregion
        #region Click actions
        public CreateQuotePopUpPage ClickCreateQuote_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(createQuoteButton);

            data.CreateQuotePopUpPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.CreateQuotePopUpPageId);

            return new CreateQuotePopUpPage(this);
        }
        public MainWorkflowPage ClickQuickSearch_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick("//div[@class='quickSearchEntryBox']/input[@type='button']", How.XPath);
            
            return new MainWorkflowPage(this);
        } 
        #endregion
        #region Set Actions
        public StartPage ExpandQuickSearch_DropdownMenu()
        {
            this.WebDriverWrapper.FindAndClick("quickSearchType");

            return this;
        }
        public StartPage SetQiuckSearchDropDown_Value(string dropdownValue)
        {
            this.WebDriverWrapper.FindAndClick($"//select[@id='quickSearchType']/option[@value='{dropdownValue}']", How.XPath);

            return this;
        }
        public StartPage SetQuickSearch_TextField(string searchValue)
        {
            this.WebDriverWrapper.FindAndSetText("quickSearchRef", searchValue);

            return this;
        }

        #endregion
    }
}
