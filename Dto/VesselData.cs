using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class VesselData
    {
        public string VesselName { get; set; }
        public string CertificateName { get; set; }
        public string DistinctIdOrCallSign { get; set; }
        public string ImoNumber { get; set; }
        public string Type { get; set; }
        public string YearOfBuilt { get; set; }
        public string Flag { get; set; }
        public string Tonnage { get; set; }
        public string InlandTonnage { get; set; }
        public string CertificateAuthority { get; set; }
        public string Class { get; set; }
        public string PassangerNo { get; set; }
        public string CrewNo { get; set; }
        public bool IsPrivateUse { get; set; }
        public string VesselTariffGroup { get; set; }
        public string HullAndMachineryValue { get; set; }
        public string HullAndMachineryCurrency { get; set; }
        public string LenghtOveral { get; set; }
        public string EngineHorsePower { get; set; }
        public string TradeMarkAndEngineModelAndNumber { get; set; }
        public string EngineNumber { get; set; }
        public string TradingArea { get; set; }
        public string PortOfRegistry { get; set; }
        public string TradesOutsidePort { get; set; }
        public string Domestic { get; set; }
        public string OtherMaterialFacts { get; set; }
        public string AncillaryCraft { get; set; }
        public string Comments { get; set; }

    }
}
