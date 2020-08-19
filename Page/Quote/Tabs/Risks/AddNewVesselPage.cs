using Sigma_Automation.Dto;

namespace Sigma_Automation.Page
{
    public class AddNewVesselPage : UIPage
    {
        public AddNewVesselPage(IUIPage page) : base(page)
        {

        }
        #region Locators
        const string vesselNameTextField = "//input[contains(@id, 'FullName')]";
        const string certificateNameTextField = "//input[contains(@id, 'CertificateName')]";
        const string imoNumberTextField = "//input[contains(@id, 'IMONumber')]";
        const string distinctIdOrCallSignTextField = "//input[contains(@id, 'CallSign')]";
        const string yearBuiltTextField = "//input[contains(@id, 'YearBuilt')]";
        const string tonnageTextField = "//input[contains(@id, 'GrossTonnage')]";
        const string inlandTonnageTextField = "//input[contains(@id, 'EnteredTonnage')]";
        const string passangerNoTextField = "//input[contains(@id, 'NoOfPassengers')]";
        const string crewNoTextField = "//input[contains(@id, 'NoOfPermanentCrew')]";
        const string hullAndMachineryValueTextField = "//input[contains(@id, 'HullMachineryValue')]";
        const string lenghtOverallTextField = "//input[contains(@id, 'LOA')]";
        const string engineHorsePowerTextField = "//input[contains(@id, 'EngineHorsePower')]";
        const string tradeMarkAndEngineModelAndNumberTextField = "//input[contains(@id, 'TradeMark')]";
        const string engineNumberTextField = "//input[contains(@id, 'EngineNo')]";
        const string typeDdl = "//select[contains(@id, 'VesselTypeValue')]";
        const string flagDdl = "//select[contains(@id, 'GeographicAreaIdFlag')]";
        const string certifyingAuthorityDdl = "//select[contains(@id, 'CertifyingAuthorityValue')]";
        const string classDdl = "//select[contains(@id, 'VesselClassValue')]";
        const string vesselTariffGroupDdl = "//select[contains(@id, 'TariffGroupValue')]";
        const string hullAndMachineCurrencyDdl = "//select[contains(@id, 'CurrencyCodeHullMachinery')]";
        const string tradingAreaDdl = "//select[contains(@id, 'GeographicAreaIdTradingArea')]";
        const string portOfRegistryDdl = "//select[contains(@id, 'GeographicAreaIdRegisteredPort')]";
        const string otherMaterialFactsTextArea = "//textarea[contains(@id, 'OperationDescription')]";
        const string ancillaryCraftTextArea = "//textarea[contains(@id, 'AncillaryCraftDescription')]";
        const string commentsTextArea = "//textarea[contains(@id, 'InternalComments')]";
        const string yesPrivatUsageRadioButton = "//label[contains(@for, 'PrivateUse') and text()='Yes']/preceding-sibling::*";
        const string noPrivatUsageRadioButton = "//label[contains(@for, 'PrivateUse') and text()='No']/preceding-sibling::*";
        const string yesTradesOutsidePortRadioButton = "//label[contains(@for, 'TradeOutsidePort') and text()='Yes']/preceding-sibling::*";
        const string noTradesOutsidePortRadioButton = "//label[contains(@for, 'TradeOutsidePort') and text()='No']/preceding-sibling::*";
        const string unknownTradesOutsidePortRadioButton = "//label[contains(@for, 'TradeOutsidePort') and text()='Unknown']/preceding-sibling::*";
        const string yesDomesticRadioButton = "//label[contains(@for, 'Domestic') and text()='Yes']/preceding-sibling::*";
        const string noDomesticRadioButton = "//label[contains(@for, 'Domestic') and text()='No']/preceding-sibling::*";
        const string unknownDomesticRadioButton = "//label[contains(@for, 'Domestic') and text()='Unknown']/preceding-sibling::*";
        const string saveAndCloseButton = "//input[@value='Save & Close']";
        const string cancelButton = "//input[@value='Cancel']";
        #endregion
        #region Click actions
        public RisksTabPage ClickSaveAndClose_Button(WindowsHandlerData data)
        {
            this.WebDriverWrapper.FindAndClick(saveAndCloseButton, How.XPath);

            this.WaitForWidowClosed(data.AddNewRiskPageId);
            this.WaitForWidowClosed(data.AddRiskPageId);

            this.SwitchToWindow(data.MainFlowPageId);

            return new RisksTabPage(this);
        }
        public SearchRiskPage ClickCancel_Button()
        {
            this.WebDriverWrapper.FindAndClick(cancelButton, How.XPath);

            this.WebDriverWrapper.SwithToNewPage();

            return new SearchRiskPage(this);
        }
        #endregion
        #region Set actions
        public AddNewVesselPage SetVesselName_TextField(string vesselName)
        {
            if (vesselName != null)
            {
                this.WebDriverWrapper.FindAndSetText(vesselNameTextField, vesselName, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetCertificateName_TextField(string certificateName)
        {
            if (certificateName != null)
            {
                this.WebDriverWrapper.FindAndSetText(certificateNameTextField, certificateName, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetImoNumber_TextField(string imoNumber)
        {
            if (imoNumber != null)
            {
                this.WebDriverWrapper.FindAndSetText(imoNumberTextField, imoNumber, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetDistinctIdOrCallSign_TextField(string distinctIdOrCallSign)
        {
            if (distinctIdOrCallSign != null)
            {
                this.WebDriverWrapper.FindAndSetText(distinctIdOrCallSignTextField, distinctIdOrCallSign, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectType_DropdownList(string type)
        {
            if (type != null)
            {
                this.WebDriverWrapper.FindAndClick(typeDdl + $"/option[text()='{type}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetYearBuild_TextField(string yearBuilt)
        {
            if (yearBuilt != null)
            {
                this.WebDriverWrapper.FindAndSetText(yearBuiltTextField, yearBuilt, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelecFlag_DropdownList(string flag)
        {
            if (flag != null)
            {
                this.WebDriverWrapper.FindAndClick(flagDdl + $"/option[text()='{flag}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetTonnage_TextField(string tonnage)
        {
            if (tonnage != null)
            {
                this.WebDriverWrapper.FindAndSetText(tonnageTextField, tonnage, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetInlandTonnage_TextField(string inlandTonnage)
        {
            if (inlandTonnage != null)
            {
                this.WebDriverWrapper.FindAndSetText(inlandTonnageTextField, inlandTonnage, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectCertifyingAuthority_DropdownList(string certifyingAuthority)
        {
            if (certifyingAuthority != null)
            {
                this.WebDriverWrapper.FindAndClick(certifyingAuthorityDdl + $"/option[text()='{certifyingAuthority}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectClass_DropdownList(string classValue)
        {
            if (classDdl != null)
            {
                this.WebDriverWrapper.FindAndClick(classDdl + $"/option[text()='{classValue}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetPassangerNo_textField(string passangerNo)
        {
            if (passangerNo != null)
            {
                this.WebDriverWrapper.FindAndSetText(passangerNoTextField, passangerNo, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetCrewNo_TextField(string crewNo)
        {
            if (crewNo != null)
            {
                this.WebDriverWrapper.FindAndSetText(crewNoTextField, crewNo, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectPrivateUsage_RadioButton(bool isPrivateUse)
        {
            if (isPrivateUse)
            {
                this.WebDriverWrapper.FindAndClick(yesPrivatUsageRadioButton, How.XPath);
            }
            else
            {
                this.WebDriverWrapper.FindAndClick(noPrivatUsageRadioButton, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectVesselTariffGroup_DropdownList(string vesselTariffGroup)
        {
            if (vesselTariffGroup != null)
            {
                this.WebDriverWrapper.FindAndClick(vesselTariffGroupDdl + $"/option[text()='{vesselTariffGroup}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetHullAndMachineryValue_TextField(string hullAndMachineryValue)
        {
            if (hullAndMachineryValue != null)
            {
                this.WebDriverWrapper.FindAndSetText(hullAndMachineryValueTextField, hullAndMachineryValue, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectHullAndMachineryCurrency_DropdownList(string hullAndMachineryCurrency)
        {
            if (hullAndMachineryCurrency!=null)
            {
                this.WebDriverWrapper.FindAndClick(hullAndMachineCurrencyDdl + $"/option[text()='{hullAndMachineryCurrency}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetLenghtOveral_TextField(string lenghtOveral)
        {
            if(lenghtOveral!=null)
            {
                this.WebDriverWrapper.FindAndSetText(lenghtOverallTextField, lenghtOveral, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetEngineHorsePower_TextField(string engineHorsePower)
        {
            if(engineHorsePower!=null)
            {
                this.WebDriverWrapper.FindAndSetText(engineHorsePowerTextField, engineHorsePower, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetTradeMarkAndEngineModelAndNumber_TextField(string tradeMarkAndEngineModelAndNumber)
        {
            if(tradeMarkAndEngineModelAndNumber!=null)
            {
                this.WebDriverWrapper.FindAndSetText(tradeMarkAndEngineModelAndNumberTextField, tradeMarkAndEngineModelAndNumber, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetEngineNumber_TextField(string engineNumber)
        {
            if (engineNumber!=null)
            {
                this.WebDriverWrapper.FindAndSetText(engineNumberTextField, engineNumber, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectTradingArea_DropdownList(string tradingArea)
        {
            if(tradingArea!=null)
            {
                this.WebDriverWrapper.FindAndClick(tradingAreaDdl + $"/option[text()='{tradingArea}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectPortOfRegistry_DropdownList(string portOfRegistry)
        {
            if(portOfRegistry!=null)
            {
                this.WebDriverWrapper.FindAndClick(portOfRegistryDdl + $"/option[text()='{portOfRegistry}']", How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SelectTradesOutsidePort_Radiobutton(string tradesOutsidePort = "Unknown")
        {
            if(tradesOutsidePort != "Unknown")
            {
                if(tradesOutsidePort == "Yes")
                {
                    this.WebDriverWrapper.FindAndClick(yesTradesOutsidePortRadioButton, How.XPath);
                }
                else
                {
                    this.WebDriverWrapper.FindAndClick(noTradesOutsidePortRadioButton, How.XPath);
                }
            }
            return this;
        }
        public AddNewVesselPage SelectDomestic_RadioButton(string domestic = "Unknown")
        {
            if (domestic != "Unknown")
            {
                if (domestic == "Yes")
                {
                    this.WebDriverWrapper.FindAndClick(yesDomesticRadioButton, How.XPath);
                }
                else
                {
                    this.WebDriverWrapper.FindAndClick(noDomesticRadioButton, How.XPath);
                }
            }
            return this;
        }
        public AddNewVesselPage SetOtherMaterialFacts_TextArea(string otherMaterialFacts)
        {
            if(otherMaterialFacts !=null)
            {
                this.WebDriverWrapper.FindAndSetText(otherMaterialFactsTextArea, otherMaterialFacts, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetAncillaryCraft_TextArea(string ancillaryCraft)
        {
            if(ancillaryCraft!=null)
            {
                this.WebDriverWrapper.FindAndSetText(ancillaryCraftTextArea, ancillaryCraft, How.XPath);
            }
            return this;
        }
        public AddNewVesselPage SetComments_TextArea(string comments)
        {
            if(comments!=null)
            {
                this.WebDriverWrapper.FindAndSetText(commentsTextArea, comments, How.XPath);
            }
            return this;
        }
        #endregion
        #region Other actions
        #endregion
    }
}