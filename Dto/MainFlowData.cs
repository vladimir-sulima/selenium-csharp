using Sigma_Automation.Dto.PremiumInstalments;
using Sigma_Automation.Dto.Premiums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class MainFlowData
    {
        public MainFlowData()
        {
            //QuoteCreationData = new QuoteCreationData();
            //MemberData = new MemberData();
            //QuoteDetailsTabData = new QuoteDetailsTabData();
            //VesselSearchData = new VesselSearchData();
            //VesselData = new VesselData();
            //PartySearchData = new PartySearchData();
            //PartyData = new PartyData();
            CoversData = new CoversData();
            WindowsHandlerData = new WindowsHandlerData();
            QuotePolicyData = new QuotePolicyData();
        }
        #region Properties
        public string FlowURL { get; set; }
        public QuoteCreationData QuoteCreationData { get; set; }
        public MemberData MemberData { get; set; }
        public QuoteDetailsTabData QuoteDetailsTabData { get; set; }
        public VesselSearchData VesselSearchData { get; set; }
        public VesselData VesselData { get; set; }
        public PartySearchData PartySearchData { get; set; }
        public ExistingPartyDetailsData ExistingPartyData { get; set; }
        public PartyData PartyData { get; set; }
        public BrokerData BrokerData { get; set; }
        public CoversData CoversData { get; set; }
        public EditFinancialDataData FinancialData { get; set; }
        public InstalmentsAndCommissionData InstalmentsAndCommissionData { get; set; }
        public SetUpdatePremiumsData SetUpdatePremiumsData { get; set; }
        public WebDriverWrapper CurrentWebDriverWrapper { get; set; }
        public WindowsHandlerData WindowsHandlerData { get; set; }
        public InstalmentsDetailsData InstalmentsDetailsData { get; set; }
        public QuotePolicyData QuotePolicyData { get; set; }
        public BindQuoteSelectDocumentationData BindQuoteSelectDocumentationData { get; set; }
        public BindQuoteAddPatternData BindQuoteAddPatternData { get; set; }
        #endregion
        #region Data set methods
        public MainFlowData SetQuoteCreationData(QuoteCreationData quoteCreationData)
        {
            QuoteCreationData = quoteCreationData;
            return this;
        }

        public MainFlowData SetMemberData(MemberData memberData)
        {
            MemberData = memberData;

            return this;
        }
        public MainFlowData SetQuoteDetailsTabData(QuoteDetailsTabData quoteDetailsTabData)
        {
            QuoteDetailsTabData = quoteDetailsTabData;
            return this;
        }
        public MainFlowData SetVesselSearchData(VesselSearchData vesselSearchData)
        {
            VesselSearchData = vesselSearchData;
            return this;
        }
        public MainFlowData SetVesselSearchData(VesselData vesselData)
        {
            VesselData = vesselData;
            return this;
        }
        public MainFlowData SetPartySearchData(PartySearchData partySearchData)
        {
            PartySearchData = partySearchData;
            return this;
        }
        public MainFlowData SetExistingPartyDetailsData(ExistingPartyDetailsData existingPartyData)
        {
            ExistingPartyData = existingPartyData;
            return this;
        }
        public MainFlowData SetPartyData(PartyData partyData)
        {
            PartyData = partyData;
            return this;
        }
        public MainFlowData SetBrokerData(BrokerData brokerData)
        {
            BrokerData = brokerData;

            return this;
        }
        public MainFlowData SetCoversData(CoversData coversData)
        {
            CoversData = coversData;

            return this;
        }
        public MainFlowData SetEditFinancialData(EditFinancialDataData financialData)
        {
            FinancialData = financialData;

            return this;
        }
        public MainFlowData GetCurrentWebDriverWrapper(WebDriverWrapper wrapper)
        {
            CurrentWebDriverWrapper = wrapper;

            return this;
        }
        public MainFlowData SetInstalmentsAndCommissionData(InstalmentsAndCommissionData instalmentsAndCommissionData)
        {
            InstalmentsAndCommissionData = instalmentsAndCommissionData;

            return this;
        }
        public MainFlowData SetSetUpdatePremiumsData(SetUpdatePremiumsData setUpdatePremiumsData)
        {
            SetUpdatePremiumsData = setUpdatePremiumsData;

            return this;
        }
        public  MainFlowData SetInstalmentsDetailsData(InstalmentsDetailsData instalmentsDetailsData)
        {
            InstalmentsDetailsData = instalmentsDetailsData;

            return this;
        }
        public MainFlowData SetBindQuoteSelectDocumentationData(BindQuoteSelectDocumentationData bindQuoteSelectDocumentationData)
        {
            BindQuoteSelectDocumentationData = bindQuoteSelectDocumentationData;

            return this;
        }
        public MainFlowData SetBindQuoteAddPatternData(BindQuoteAddPatternData bindQuoteAddPatternData)
        {
            BindQuoteAddPatternData = bindQuoteAddPatternData;

            return this;
        }
        #endregion
    }
}
