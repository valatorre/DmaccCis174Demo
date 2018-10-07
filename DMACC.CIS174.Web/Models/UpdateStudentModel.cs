using System;

namespace DMACC.CIS174.Web.Models
{
    public class UpdateStudentModel
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }
}