using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Shared.ViewModels
{
    public class AddressViewModel
    {
        public Guid AddressId { get; set; }
        public string AddressType { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
    }
}
