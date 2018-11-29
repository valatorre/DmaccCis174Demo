using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DMACC.CIS174.Api.Models;
using DMACC.CIS174.Shared.Orchestrators;

// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Api.Controllers
{
    [Route("api/v1/students")]
    public class StudentController : ApiController
    {
        private readonly StudentOrchestrator _studentOrchestrator;

        public StudentController()
        {
            _studentOrchestrator = new StudentOrchestrator();
        }

        [HttpGet]
        public async Task<List<StudentModel>> GetAllStudents()
        {
            var students = await _studentOrchestrator.GetAllStudents();

            var studentModels = students.Select(x => new StudentModel
            {
                StudentId = x.StudentId,
                StudentName = x.StudentName,
                Address = new AddressModel
                {
                    StreetAddress1 = x.Address.StreetAddress1,
                    StreetAddress2 = x.Address.StreetAddress2,
                    City = x.Address.City,
                    State = x.Address.State,
                    Zip = x.Address.Zip
                }
            }).ToList();

            return studentModels;
        }

        [HttpPost]
        public async Task<StudentModel> GetStudentById(Guid studentId)
        {
            var student = await _studentOrchestrator.GetStudentById(studentId);

            var studentModel = new StudentModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Address = new AddressModel
                {
                    StreetAddress1 = student.Address.StreetAddress1,
                    StreetAddress2 = student.Address.StreetAddress2,
                    City = student.Address.City,
                    State = student.Address.State,
                    Zip = student.Address.Zip
                }
            };

            return studentModel;
        }
    }
}
