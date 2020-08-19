using NUnit.Framework;
using Sigma_Automation.Dto;
using Sigma_Automation.Dto.PremiumInstalments;
using Sigma_Automation.Dto.Premiums;
using Sigma_Automation.Framework;
using Sigma_Automation.Page;
using Sigma_Automation.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Test
{
    [TestFixture]
    [Parallelizable]
    class SigmaSmokeTests_Part2 : TestBase
    {
        [Test]
        public void SmokeTest_ExistingMemberAndVessel()
        {
            var mainflowData = new MainFlowData();


            Start<StartPage>(mainflowData, page => page
            #region Create application
            .CreateVesselRiskQuote(mainflowData.SetQuoteCreationData(new QuoteCreationData
            {
                RiskType = "Vessel Risk",
                ProductType = "YACHT",
                PolicyBilling = "Standard",
                TemplateType = "Yacht",
                TemplateCategory = "Yacht",
                TemplateName = "Yacht Liability Insurance",
                //FromDate = "01/01/2018",
                //ToDate = "31/12/2018",
                IsDateToBeConfirmed = false
            }))
            .WaitToQuotePageOpen(mainflowData.WindowsHandlerData)
            #endregion
            #region Set data for Quote Details tab
            //Also available method SelectNewMember() or SelectExistingMember()
            .SelectExistingMember(mainflowData.SetMemberData(new MemberData
            {
                //Reference = "20082"
                //Name = "SD P"
                Name = "Member1809_02"
            }))
            .ManageQuoteDetails(mainflowData.SetQuoteDetailsTabData(new QuoteDetailsTabData
            {
                ////Commented fields not mandatory, uncomment particular property if you want to populate it
                //MemberAssuredCapacities = "Crew Manager",
                IsClearMemberCapacities = false,
                EntryType = "Charterers Liability",
                QuoteType = "Quotation",
                //Underwriter = "Janie Welsh",
                IsSeparateCommissionNote = true,
                //ValidTo = "01/01/2019",
                //PolicyCondition = "Watersports Exclusion",
                //IsClearPolicyConditions = true,
                TradingLimitsStandardText = "CANADA TRADE"
            }))
            .SaveQuoteDetails(mainflowData)
            .GetQuoteDetails(mainflowData.QuotePolicyData)
            #endregion
            #region Set data for Risks tab
            .NavidateToRisksTab()
            ////Also available method:
            //.AddExistingVessel() - use instead PerformVesselSearch() and AddNewVessel() methods
            .AddExistingVessel(mainflowData.SetVesselSearchData(new VesselSearchData
            {
                VesselName = "Vessel"

            }))
            #endregion
            #region Set data for Party tab
            //Uncoment this set of code to manage Associated parties
            ////Commented fields not mandatory, please uncomment if you want to populate them
            //.NavigateToAssociatedPartyTab()
            ////Available AddNewParty() and AddExistingParty() methods
            //.AddNewParty(mainflowData
            //    .SetPartySearchData(
            //    new PartySearchData
            //    {
            //        Ref = "26448"
            //    }).SetPartyData(
            //    new PartyData
            //    {
            //        PartyRole = "Joint Assured",
            //        FirstName = "First name",
            //        LastNameOrOrganisationName = "Last name",
            //        Description = "Description",
            //        //FromDate = "01/02/2018",
            //        //ToDate = "31/12/2018",
            //        //Here you could select multiple capacities
            //        Capacity = new string[] { "Agent", "Adjuster" },
            //        Clause = "Crew Managers Clause",
            //        AddressName = "Address name",
            //        Street1 = "Street1",
            //        Street2 = "Street2",
            //        City = "City",
            //        PostalCode = "Postal code",
            //        Country = "ARUBA",
            //        Phone = "Phone",
            //        Fax = "Fax",
            //        Email = "automation@jumar.com"
            //    }
            //    ))
            ////Uncoment this code to Add existing party
            ////.AddExistingParty(mainflowData.SetPartySearchData(
            ////    new PartySearchData
            ////{
            ////    Ref = "26448",
            ////}).SetExistingPartyDetailsData(
            ////    new ExistingPartyDetailsData
            ////{
            ////    Description = "Description",
            ////    Role = "Joint Assured",
            ////    FromDate = "01/01/2018",
            ////    ToDate = "01/12/2018",
            ////    Capacity = "Agent",
            ////    Clause = "Crew Managers Clause"
            ////}
            ////))
            #endregion
            #region Set data for Broker tab
            .NavigateToBrokersTab()
            .AddBrokerToPolicy(mainflowData.SetBrokerData(
                new BrokerData
                {
                    //FullName = "Broker",
                    Reference = "2189"
                }
            ))
            #endregion
            #region Set data for Cover tab
            .NavigateToCoversTab()
            //For now, implemented just removing unnecessary Covers
            .RemoveCoversExcept(mainflowData, new string[]
            {
                "Yacht Legal Costs Cover"
            })
            #endregion
            #region Set data for Premiums tab
            .NavigateToPremiumsTab()
            .ManagePremiumsFinancialData(mainflowData.SetEditFinancialData(
                new EditFinancialDataData
                {
                    ////Commented fields not mandatory, please uncomment if you want to populate them
                    Currency = "CANADIAN DOLLARS (CAD)",
                    //ApplicableTax = "AUSTRALIA",
                    //Comments = "Comments",
                    //FlagAtRenewals = true,
                    //RenewalComments = "Renewal comments"
                }
            ))
            .ManageInstallmentsAndCommissionsData(mainflowData.SetInstalmentsAndCommissionData(
                new InstalmentsAndCommissionData
                {
                    CommissionPercentage = "10",
                    CallType = "Fixed Premium",
                    PremiumType = "Annual"
                }))
            .ManageSetAndUpdatePremiumData(mainflowData.SetSetUpdatePremiumsData(
                new SetUpdatePremiumsData
                {
                    Ammount = "1000"
                }
                ))
            #endregion
            #region Set data for Premium Instalments tab
            .NavigateToPremiumIstalmentsTab()
            .SetInstalmentDetails(mainflowData.SetInstalmentsDetailsData(
                new InstalmentsDetailsData
                {
                    IsInstalmentPatternBespoke = false,
                    InstalmentsPattern = "100%"
                }))
            #endregion
            #region Issue and Bind quote
            .IssueQuote()
            .PerformQuickSearch_Quote(mainflowData.QuotePolicyData.QuoteReference, mainflowData)
            .GetQuoteDetails(mainflowData.QuotePolicyData)
            .BindQuote(mainflowData)
            .ManageInvoiceDetails(mainflowData.SetBindQuoteSelectDocumentationData(
                new BindQuoteSelectDocumentationData
                {
                    IsShortFormTradingCertificate = true,
                    LongFormCertificate = "Singular",
                    Invoice = "Singular",
                    InvoiceAddressee = "Member",
                    InvoiceFormat = "Include Commission",
                    Comments = "Some comments"
                }
                ))
            .ManageQuoteReinsurance(mainflowData.SetBindQuoteAddPatternData(
                new BindQuoteAddPatternData
                {
                    Comments = "Some comments"
                }
            ))
            #endregion
            .PerformQuickSearch_Policy(mainflowData.QuotePolicyData.QuoteReference, mainflowData)
            );
        }
        [Test]
        public void Test()
        {
            var mainflowData = new MainFlowData();

            Start<StartPage>(mainflowData, page => page
            //.SwitchToQuoteDetailPage(mainflowData)
            .SwitchToBindQuteSelectDocumentationPage(mainflowData)
            //.NavigateToCoversTab()
            ////For now, implemented just removing unnecessary Covers
            //.RemoveCoversExcept(mainflowData, new string[]
            //{
            //    "Yacht Legal Costs Cover"
            //})
            //.ResolveSwitchBetweenWindowIssue(mainflowData)
            //.NavigateToPremiumsTab()
            //.ManagePremiumsFinancialData(mainflowData.SetEditFinancialData(
            //    new EditFinancialDataData
            //    {
            //        Currency = "CANADIAN DOLLARS (CAD)",
            //        //ApplicableTax = "AUSTRALIA",
            //        //Comments = "Comments",
            //        //FlagAtRenewals = true,
            //        //RenewalComments = "Renewal comments"
            //    }
            //))
            //.ManageInstallmentsAndCommissionsData(mainflowData.SetInstalmentsAndCommissionData(
            //    new InstalmentsAndCommissionData
            //    {
            //        CommissionPercentage = "10",
            //        CallType = "Fixed Premium",
            //        PremiumType = "Annual"
            //    }))
            //.ManageSetAndUpdatePremiumData(mainflowData.SetSetUpdatePremiumsData(
            //    new SetUpdatePremiumsData
            //    {
            //        Ammount = "1000"
            //    }
            //    ))
            //.NavigateToPremiumIstalmentsTab()
            //.SetInstalmentDetails(mainflowData.SetInstalmentsDetailsData(
            //    new InstalmentsDetailsData
            //    {
            //        IsInstalmentPatternBespoke = false,
            //        InstalmentsPattern = "100%"
            //    }))
            //.IssueQuote()
            .ManageInvoiceDetails(mainflowData.SetBindQuoteSelectDocumentationData(
                new BindQuoteSelectDocumentationData
                {
                    IsShortFormTradingCertificate = true,
                    LongFormCertificate = "Singular",
                    Invoice = "Singular",
                    InvoiceAddressee = "Member",
                    InvoiceFormat = "Include Commission",
                    Comments = "Some comments"
                }
                ))
            .ManageQuoteReinsurance(mainflowData.SetBindQuoteAddPatternData(
                new BindQuoteAddPatternData
                {
                    Comments = "Some comments"
                }
            ))
            );

        }
        [Test]
        public void SmokeTest()
        {
            var mainflowData = new MainFlowData();


            Start<StartPage>(mainflowData, page => page
            #region Create application
            .CreateVesselRiskQuote(mainflowData.SetQuoteCreationData(new QuoteCreationData
            {
                RiskType = "Vessel Risk",
                ProductType = "YACHT",
                PolicyBilling = "Standard",
                TemplateType = "Yacht",
                TemplateCategory = "Yacht",
                TemplateName = "Yacht Liability Insurance",
                //FromDate = "01/01/2018",
                //ToDate = "31/12/2018",
                IsDateToBeConfirmed = false
            }))
            .WaitToQuotePageOpen(mainflowData.WindowsHandlerData)
            #endregion
            #region Set data for Quote Details tab
            //Also available method SelectNewMember() or SelectExistingMember()
            .SelectNewMember(mainflowData.SetMemberData(new MemberData
            {
                ////Commented fields not mandatory, uncomment particular property if you want to populate it
                Reference = "69937",
                FirstName = "SigmaMember2009_02",
                LastNameOrOrganisationName = "Member1909_02",
                Domicilie = "ARUBA",
                //Group = "A10 - ACAV",
                AddressName = "AN",
                //Street1 = "S1",
                //Street2 = "S2",
                City = "City",
                //PostalCode = "PC",
                Country = "AZORES",
                //Phone = "12345",
                //Fax = "67890",
                Email = "test@email.com"
            }))
            .ManageQuoteDetails(mainflowData.SetQuoteDetailsTabData(new QuoteDetailsTabData
            {
                ////Commented fields not mandatory, uncomment particular property if you want to populate it
                //MemberAssuredCapacities = "Crew Manager",
                IsClearMemberCapacities = false,
                EntryType = "Charterers Liability",
                QuoteType = "Quotation",
                //Underwriter = "Janie Welsh",
                IsSeparateCommissionNote = true,
                //ValidTo = "01/01/2019",
                //PolicyCondition = "Watersports Exclusion",
                IsClearPolicyConditions = true,
                TradingLimitsStandardText = "CANADA TRADE"
            }))
            .SaveQuoteDetails(mainflowData)
            .GetQuoteDetails(mainflowData.QuotePolicyData)
            #endregion
            #region Set data for Risks tab
            .NavidateToRisksTab()
            ////Also available method:
            //.AddExistingVessel() - use instead PerformVesselSearch() and AddNewVessel() methods
            .PerformVesselSearch(mainflowData.SetVesselSearchData(new VesselSearchData
            {
                VesselName = "Unexising Vessel"

            }))
            .AddNewVessel(mainflowData.SetVesselSearchData(new VesselData
            {
                ////Commented fields not mandatory, please uncomment if you want to populate them
                VesselName = "VesselName",
                //CertificateName = "CertificateName",
                //ImoNumber = "1234567",
                //DistinctIdOrCallSign = "DistinctIdOrCallSign",
                Type = "YOO - YACHT - OWNER OPERATED",
                YearOfBuilt = "2000",
                Flag = "AZORES",
                Tonnage = "1000",
                CertificateAuthority = "Affaires Fluviales",
                Class = "Belarus",
                //PassangerNo = "300",
                //CrewNo = "200",
                IsPrivateUse = true,
                //VesselTariffGroup = "AM - AMERICAS",
                //HullAndMachineryValue = "7000",
                //HullAndMachineryCurrency = "EURO (EUR)",
                //LenghtOveral = "8000",
                //EngineHorsePower = "111",
                //TradeMarkAndEngineModelAndNumber = "tradeMark",
                //EngineNumber = "10",
                TradingArea = "USA",
                //PortOfRegistry = "ADEN",
                //TradesOutsidePort = "Yes",
                //Domestic = "Yes",
                //OtherMaterialFacts = "OtherMaterialFacts",
                //AncillaryCraft = "AncillaryCraft",
                //Comments = "Comments"
            }))
            #endregion
            #region Set data for Party tab
            ////Uncoment this set of code to manage Associated parties
            ////Commented fields not mandatory, please uncomment if you want to populate them
            //.NavigateToAssociatedPartyTab()
            ////Available AddNewParty() and AddExistingParty() methods
            //.AddNewParty(mainflowData
            //    .SetPartySearchData(
            //    new PartySearchData
            //    {
            //        Ref = "26448"
            //    }).SetPartyData(
            //    new PartyData
            //    {
            //        PartyRole = "Joint Assured",
            //        FirstName = "First name",
            //        LastNameOrOrganisationName = "Last name",
            //        Description = "Description",
            //        //FromDate = "01/02/2018",
            //        //ToDate = "31/12/2018",
            //        //Here you could select multiple capacities
            //        //Capacity = new string[] { "Agent", "Additional Assured" },
            //        //Clause = "Crew Managers Clause",
            //        AddressName = "Address name",
            //        Street1 = "Street1",
            //        Street2 = "Street2",
            //        City = "City",
            //        PostalCode = "Postal code",
            //        Country = "ARUBA",
            //        Phone = "Phone",
            //        Fax = "Fax",
            //        Email = "automation@jumar.com"
            //    }
            //    ))
            ////Uncoment this code to Add existing party
            //.AddExistingParty(mainflowData.SetPartySearchData(
            //    new PartySearchData
            //{
            //    Ref = "26448",
            //}).SetExistingPartyDetailsData(
            //    new ExistingPartyDetailsData
            //{
            //    Description = "Description",
            //    Role = "Joint Assured",
            //    FromDate = "01/01/2018",
            //    ToDate = "01/12/2018",
            //    Capacity = "Agent",
            //    Clause = "Crew Managers Clause"
            //}
            //))
            #endregion
            #region Set data for Broker tab
            .NavigateToBrokersTab()
            .AddBrokerToPolicy(mainflowData.SetBrokerData(
                new BrokerData
                {
                    //FullName = "Broker",
                    Reference = "2189"
                }
            ))
            #endregion
            #region Set data for Cover tab
            .NavigateToCoversTab()
            //For now, implemented just removing unnecessary Covers
            .RemoveCoversExcept(mainflowData, new string[]
            {
                "Yacht Legal Costs Cover"
            })
            #endregion
            #region Set data for Premiums tab
            .NavigateToPremiumsTab()
            .ManagePremiumsFinancialData(mainflowData.SetEditFinancialData(
                new EditFinancialDataData
                {
                    ////Commented fields not mandatory, please uncomment if you want to populate them
                    Currency = "CANADIAN DOLLARS (CAD)",
                    //ApplicableTax = "AUSTRALIA",
                    //Comments = "Comments",
                    //FlagAtRenewals = true,
                    //RenewalComments = "Renewal comments"
                }
            ))
            .ManageInstallmentsAndCommissionsData(mainflowData.SetInstalmentsAndCommissionData(
                new InstalmentsAndCommissionData
                {
                    CommissionPercentage = "10",
                    CallType = "Fixed Premium",
                    PremiumType = "Annual"
                }))
            .ManageSetAndUpdatePremiumData(mainflowData.SetSetUpdatePremiumsData(
                new SetUpdatePremiumsData
                {
                    Ammount = "1000"
                }
                ))
            #endregion
            #region Set data for Premium Instalments tab
            .NavigateToPremiumIstalmentsTab()
            .SetInstalmentDetails(mainflowData.SetInstalmentsDetailsData(
                new InstalmentsDetailsData
                {
                    IsInstalmentPatternBespoke = false,
                    InstalmentsPattern = "100%"
                }))
            #endregion
            #region Issue and Bind quote
            .IssueQuote()
            .PerformQuickSearch_Quote(mainflowData.QuotePolicyData.QuoteReference, mainflowData)
            .GetQuoteDetails(mainflowData.QuotePolicyData)
            .BindQuote(mainflowData)
            .ManageInvoiceDetails(mainflowData.SetBindQuoteSelectDocumentationData(
                new BindQuoteSelectDocumentationData
                {
                    IsShortFormTradingCertificate = true,
                    LongFormCertificate = "Singular",
                    Invoice = "Singular",
                    InvoiceAddressee = "Member",
                    InvoiceFormat = "Include Commission",
                    Comments = "Some comments"
                }
                ))
            .ManageQuoteReinsurance(mainflowData.SetBindQuoteAddPatternData(
                new BindQuoteAddPatternData
                {
                    Comments = "Some comments"
                }
            ))
            .PerformQuickSearch_Policy(mainflowData.QuotePolicyData.QuoteReference, mainflowData)
            );
            #endregion
        }

    }
}
