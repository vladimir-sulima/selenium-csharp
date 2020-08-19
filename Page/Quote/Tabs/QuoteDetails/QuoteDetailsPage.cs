using Sigma_Automation.Dto;
using System.Threading;

namespace Sigma_Automation.Page
{
    public class QuoteDetailsPage : MainWorkflowPage
    {
        public QuoteDetailsPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string memberAssuredCapacitiesTextList = "//select[contains(@name, 'MainPolicyHolderPartyRoleSubTypes')]";
        const string membersSelectHyperlink = "//a[contains(@id, 'PartyRoleIdMainPolicyHolder_Select')]";
        const string entryTypeDdl = "//select[contains(@name, 'EntryTypeValue')]";
        const string quoteTypeDdl = "//select[contains(@name, 'PolicyTypeValue')]";
        const string yesClearMemberCapactiesRb = "//label[contains(@for,'ResetMainPolicyHolderPartyRoleSubTypes') and text()='Yes']/preceding-sibling::input";
        const string noClearMemberCapactiesRb = "//label[contains(@for,'ResetMainPolicyHolderPartyRoleSubTypes') and text()='No']/preceding-sibling::input";
        const string underwriterDdl = "//select[contains(@name, 'PartyRoleIdUnderwriter')]";
        const string validToTextField = "//input[@type='text' and contains(@name, 'ExpiryDateString')]";
        const string yesClearPolicyConditionsRb = "//label[contains(@for, 'ResetConditionType') and text()='Yes']/preceding-sibling::input";
        const string noClearPolicyConditionsRb = "//label[contains(@for, 'ResetConditionType') and text()='No']/preceding-sibling::input";
        const string tradingLimitStandardTextDdl = "//select[contains(@name, 'TradingLimitStandardText')]";
        const string yesSeparateCommissionNoteRb = "//label[contains(@for, 'SeparateCommissionNote') and text()='Yes']/preceding-sibling::input";
        const string noSeparateCommissionNoteRb = "//label[contains(@for, 'SeparateCommissionNote') and text()='No']/preceding-sibling::input";
        const string policyConditionTextList = "//select[contains(@name, 'ConditionTypeValue')]";


        #endregion
        #region Click actions
        public AddAssureMemberPage ClickSelectMember_Hyperlink(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(membersSelectHyperlink, How.XPath);

            var winHan = this.WebDriverWrapper.WebDriver.WindowHandles;

            data.AddAssuredMemberPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);

            this.SwitchToWindow(data.AddAssuredMemberPageId);

            Thread.Sleep(500);

            return new AddAssureMemberPage(this);
        }

        #endregion
        #region Set actions
        public QuoteDetailsPage SelectEntryType_DropdownList(string entryType)
        {
            this.WebDriverWrapper.FindAndClick(entryTypeDdl + $"/option[text()='{entryType}']", How.XPath);

            return this;
        }
        public QuoteDetailsPage SelectQuoteType_DropdownList(string quoteType)
        {
            this.WebDriverWrapper.FindAndClick(quoteTypeDdl + $"/option[text()='{quoteType}']", How.XPath);

            return this;
        }
        public QuoteDetailsPage SelectUnderwriter_DropdownList(string underwriter)
        {
            if (underwriter != null)
            {
                this.WebDriverWrapper.FindAndClick(underwriterDdl + $"/option[text()='{underwriter}']", How.XPath);
            }
            return this;
        }
        public QuoteDetailsPage SelectSeparateCommisionNote_RadioButton(bool isSeparateComissioneNote = false)
        {
            if (isSeparateComissioneNote)
            {
                this.WebDriverWrapper.FindAndClick(yesSeparateCommissionNoteRb, How.XPath);
            }
            else
            {
                this.WebDriverWrapper.FindAndClick(noSeparateCommissionNoteRb, How.XPath);
            }

            return this;
        }
        public QuoteDetailsPage SetValidTo_TextField(string validToDate)
        {
            if (validToDate != null)
            {
                this.WebDriverWrapper.FindAndSetText(validToTextField, validToDate, How.XPath);
            }

            return this;
        }
        public QuoteDetailsPage SelectPolicyConditions_TextList(string policyCondition)
        {
            if (policyCondition != null)
            {
                this.WebDriverWrapper.FindAndClick(policyConditionTextList + $"/option[text()='{policyCondition}']", How.XPath);
            }

            return this;
        }
        public QuoteDetailsPage SelectClearPolicyConditions_RadioButton(bool isClearPolicyCondition = false)
        {
            if (isClearPolicyCondition)
            {
                this.WebDriverWrapper.FindAndClick(yesClearPolicyConditionsRb, How.XPath);
            }
            else
            {
                this.WebDriverWrapper.FindAndClick(noClearPolicyConditionsRb, How.XPath);
            }

            return this;
        }
        public QuoteDetailsPage SetTradingLimitStandardText_DropdownList(string tradingLimitStandatdText)
        {
            this.WebDriverWrapper.FindAndClick(tradingLimitStandardTextDdl + $"/option[text()='{tradingLimitStandatdText}']", How.XPath);

            return this;
        }
        #endregion
        #region Other actions
        private void WaitForAddAssuredMemberPageOpen()
        {
            var numberOfDispalyedWindows = this.WebDriverWrapper.WebDriver.WindowHandles.Count;

            this.WebDriverWrapper.Wait.Until(x => x.WindowHandles.Count > numberOfDispalyedWindows);
            this.WebDriverWrapper.SwithToNewPage();
        }
        public QuoteDetailsPage SelectClearMemberCapacties_RadioButton(bool isClearMemberCapacties = false)
        {
            if (isClearMemberCapacties)
            {
                this.WebDriverWrapper.FindAndClick(yesClearMemberCapactiesRb, How.XPath);
            }
            else
            {
                this.WebDriverWrapper.FindAndClick(noClearMemberCapactiesRb, How.XPath);
            }

            return this;
        }
        public QuoteDetailsPage SelectMemberAssuredCapacities_TextList(string memberAssuredCapacities)
        {
            if(memberAssuredCapacities!=null)
            {
                this.WebDriverWrapper.FindAndClick(memberAssuredCapacitiesTextList + $"/option[text()='{memberAssuredCapacities}']", How.XPath);
            }

            return this;
        }


        #endregion
    }
}