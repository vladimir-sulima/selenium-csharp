using Sigma_Automation.Dto;
using Sigma_Automation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Scenarios
{
    public static class VesselsScenarios
    {
        public static RisksTabPage AddExistingVessel(this RisksTabPage page, MainFlowData data)
        {
            return page
                .PerformVesselSearch(data)
                .SelectFirsRiskFromList(data);
        }

        public static RisksTabPage SelectFirsRiskFromList(this SearchRiskPage page, MainFlowData data)
        {
            return page
                .Click_FirstCheckBox()
                .ClickAddSelected_Button(data.WindowsHandlerData)
                //.WaitForAddedVesselDisplayed(data.VesselData)
                ;
        }
        public static RisksTabPage AddNewVessel(this SearchRiskPage page, MainFlowData data)
        {
            return page
                .ClickAddNew_Button(data.WindowsHandlerData)
                .SetVesselName_TextField(data.VesselData.VesselName)
                .SetCertificateName_TextField(data.VesselData.CertificateName)
                .SetImoNumber_TextField(data.VesselData.ImoNumber)
                .SetDistinctIdOrCallSign_TextField(data.VesselData.DistinctIdOrCallSign)
                .SelectType_DropdownList(data.VesselData.Type)
                .SetYearBuild_TextField(data.VesselData.YearOfBuilt)
                .SelecFlag_DropdownList(data.VesselData.Flag)
                .SetTonnage_TextField(data.VesselData.Tonnage)
                .SetInlandTonnage_TextField(data.VesselData.InlandTonnage)
                .SelectCertifyingAuthority_DropdownList(data.VesselData.CertificateAuthority)
                .SelectClass_DropdownList(data.VesselData.Class)
                .SetPassangerNo_textField(data.VesselData.PassangerNo)
                .SetCrewNo_TextField(data.VesselData.CrewNo)
                .SelectPrivateUsage_RadioButton(data.VesselData.IsPrivateUse)
                .SelectVesselTariffGroup_DropdownList(data.VesselData.VesselTariffGroup)
                .SetHullAndMachineryValue_TextField(data.VesselData.HullAndMachineryValue)
                .SelectHullAndMachineryCurrency_DropdownList(data.VesselData.HullAndMachineryCurrency)
                .SetLenghtOveral_TextField(data.VesselData.LenghtOveral)
                .SetEngineHorsePower_TextField(data.VesselData.EngineHorsePower)
                .SetTradeMarkAndEngineModelAndNumber_TextField(data.VesselData.TradeMarkAndEngineModelAndNumber)
                .SetEngineNumber_TextField(data.VesselData.EngineNumber)
                .SelectTradingArea_DropdownList(data.VesselData.TradingArea)
                .SelectPortOfRegistry_DropdownList(data.VesselData.PortOfRegistry)
                .SelectTradesOutsidePort_Radiobutton(data.VesselData.TradesOutsidePort)
                .SelectDomestic_RadioButton(data.VesselData.Domestic)
                .SetOtherMaterialFacts_TextArea(data.VesselData.OtherMaterialFacts)
                .SetAncillaryCraft_TextArea(data.VesselData.AncillaryCraft)
                .SetComments_TextArea(data.VesselData.Comments)
                .ClickSaveAndClose_Button(data.WindowsHandlerData)
                .WaitForAddedVesselDisplayed(data.VesselData);
        }


    }
}
