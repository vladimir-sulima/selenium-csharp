namespace Sigma_Automation.Dto
{
    public class PartyData
    {
        public string PartyRole { get; set; }
        public string FirstName { get; set; }
        public string LastNameOrOrganisationName { get; set; }
        public string Description { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string[] Capacity { get; set; }
        public string Clause { get; set; }
        public string AddressName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
}