using System;

// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Api.Models
{
    public class StudentModel
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public AddressModel Address { get; set; }
    }
}