using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Sigma_Automation.Dto;
using System.Threading;

namespace Sigma_Automation.Page
{
    public class SearchRiskPage : UIPage
    {
        public SearchRiskPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string vesselNameTextField = "//input[contains(@name, 'VesselFullName')]";
        const string riskReferenceTextField = "(//input[contains(@name, 'RiskReference')])[1]";
        const string memberNumberTextField = "//input[contains(@name, 'PartyRoleReference')]";
        const string imoNumberTextField = "//input[contains(@name, 'VesselIMONumber')]";
        const string memberNameTextField = "//input[contains(@name, 'PartyFullName')]";
        const string vesselNumberTextField = "//input[contains(@name, 'VesselReference')]";
        const string vesselTarigGroupDdl = "//select[contains(@name, 'VesselTariffGroupValue')]";
        const string memberDomicileDdl = "//select[contains(@name, 'PartyGeographicAreaIdDomicile')]";
        const string clearAllBut = "//input[contains(@name, 'ClearAllButton')]";
        const string searchBut = "//input[@type='submit']";
        const string firstCheckBox = "(//input[@type='checkbox'])[3]";
        const string addSelectedBut = "//input[@value='Add Selected']";
        const string addNewBut = "//input[@value='Add New']";
        #endregion
        #region Click actions
        public SearchRiskPage ClickClearAll_Button()
        {
            this.WebDriverWrapper.FindAndClick(clearAllBut, How.XPath);

            return this;
        }
        public SearchRiskPage ClickSearch_Button()
        {
            this.WebDriverWrapper.FindAndClick(searchBut, How.XPath);

            return this;
        }
        public SearchRiskPage Click_FirstCheckBox()
        {
            this.WebDriverWrapper.FindAndClick(firstCheckBox, How.XPath);

            return this;
        }
        public RisksTabPage ClickAddSelected_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(addSelectedBut, How.XPath);
            var alert = this.WebDriverWrapper.WebDriver.SwitchTo().Alert();
            alert.Accept();

            this.SwitchToWindow(data.MainFlowPageId);

            return new RisksTabPage(this);
        }
        public AddNewVesselPage ClickAddNew_Button(WindowsHandlerData data)
        {
            data.GetNumberOfCurrentlyOpenedWindows(this);

            this.WebDriverWrapper.FindAndClick(addNewBut, How.XPath);

            data.AddNewRiskPageId = data.WaitAndGetIdForNewlyOpenedWindow(data, this);
            this.SwitchToWindow(data.AddNewRiskPageId);

            return new AddNewVesselPage(this);
        }
        #endregion
        #region Set actions
        public SearchRiskPage SetVesselName_TextField(string vesselName)
        {
            if (vesselName != null)
            {
                this.WebDriverWrapper.FindAndSetText(vesselNameTextField, vesselName, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SetRiskReference_TextField(string riskReference)
        {
            if (riskReference != null)
            {
                this.WebDriverWrapper.FindAndSetText(riskReferenceTextField, riskReference, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SetMemberNumber_TextField(string memberNumber)
        {
            if (memberNumber != null)
            {
                this.WebDriverWrapper.FindAndSetText(memberNumberTextField, memberNumber, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SetImoNumber_TextField(string imoNumber)
        {
            if (imoNumber != null)
            {
                this.WebDriverWrapper.FindAndSetText(imoNumberTextField, imoNumber, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SetMemberName_TextField(string memberName)
        {
            if (memberName != null)
            {
                this.WebDriverWrapper.FindAndSetText(memberNameTextField, memberName, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SelectVesselTariffGroup_DropdownList(string vesselTariffGroup)
        {
            if (vesselTariffGroup != null)
            {
                this.WebDriverWrapper.FindAndClick(vesselTarigGroupDdl, How.XPath);
                this.WebDriverWrapper.FindAndClick(vesselTarigGroupDdl + $"/option[text()='{vesselTariffGroup}']", How.XPath);
            }
            return this;
        }
        public SearchRiskPage SetVesselNumber_TextField(string vesselNumber)
        {
            if (vesselNumber != null)
            {
                this.WebDriverWrapper.FindAndSetText(vesselNumberTextField, vesselNumber, How.XPath);
            }
            return this;
        }
        public SearchRiskPage SelectMemberDomicile_DropdownList(string memberDomicile)
        {
            if (memberDomicile != null)
            {
                this.WebDriverWrapper.FindAndClick(memberDomicileDdl + $"/option[text()='{memberDomicile}']", How.XPath);
            }
            return this;
        }
        #endregion
    }
}