using Sigma_Automation.Dto;
using System.Linq;

namespace Sigma_Automation.Page
{
    public class AddAssureMemberPage : UIPage
    {
        public AddAssureMemberPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string nameSearchTextField = "//input[contains(@id, 'PartyRoleFullName')]";
        const string nameSearchreferenceTextField = "//input[contains(@id, 'PartyRoleReference')]";
        const string searchButton = "//input[@type='submit']";
        const string selectButton = "//input[contains(@id,'customButton_Select')]";
        const string addNewButton = "//input[@value='Add New']";
        const string tableResultPageWaiter = "//table[contains(@id, 'itemPlaceholderContainerId')]";

        #endregion
        #region Click actions
        public AddAssureMemberPage ClickSearch_Button()
        {
            this.WebDriverWrapper.FindAndClick(searchButton, How.XPath);

            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(tableResultPageWaiter).Any());

            return this;
        }
        public AddNewMemberPage ClickAddNew_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(addNewButton, How.XPath);

            data.AddNewMemberPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.AddNewMemberPageId);

            return new AddNewMemberPage(this);
        }
        #endregion
        #region Set region
        public AddAssureMemberPage SetMemberSearchName(string memberName)
        {
            if (memberName != null)
            {
                this.WebDriverWrapper.FindAndSetText(nameSearchTextField, memberName, How.XPath);
            }

            return this;
        }
        public AddAssureMemberPage SetMemberSearchReference(string memberReference)
        {
            if (memberReference != null)
            {
                this.WebDriverWrapper.FindAndSetText(nameSearchreferenceTextField, memberReference, How.XPath);
            }
            return this;
        }
        public QuoteDetailsPage SelectFirstMemberInList(WindowsHandlerData data)
        {
            this.WebDriverWrapper.Wait.Until(x => this.WebDriverWrapper.FindElementsByXPath(selectButton).Count > 0);
            var firsSelectButton = this.WebDriverWrapper.FindElementsByXPath(selectButton);
            this.WebDriverWrapper.Click(firsSelectButton[0]);

            this.WaitForWidowClosed(data.AddAssuredMemberPageId);

            this.SwitchToWindow(data.MainFlowPageId);

            return new QuoteDetailsPage(this);
        }
        #endregion
    }
}