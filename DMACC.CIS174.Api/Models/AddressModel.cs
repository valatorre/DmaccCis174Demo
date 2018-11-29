// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Api.Models
{
    public class AddressModel
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}