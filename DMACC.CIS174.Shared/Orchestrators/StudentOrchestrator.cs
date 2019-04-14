using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DMACC.CIS174.Domain;
using DMACC.CIS174.Domain.Entities;
using DMACC.CIS174.Shared.Orchestrators.Interfaces;
using DMACC.CIS174.Shared.ViewModels;

namespace DMACC.CIS174.Shared.Orchestrators
{
    public class StudentOrchestrator : IStudentOrchestrator
    {
        private readonly SchoolContext _schoolContext;

        public StudentOrchestrator()
        {
            _schoolContext = new SchoolContext();
        }

        public async Task<int> CreateStudent(StudentViewModel student)
        {
            _schoolContext.Students.Add(new Student
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Height = student.Height,
                Weight = student.Weight,
                Addresses = null,
                DateOfBirth = null
            });

            return await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            var students = await _schoolContext.Students.Select(x => new StudentViewModel
            {
                StudentId = x.StudentId,
                StudentName = x.StudentName,
                Height = x.Height,
                Weight = x.Weight,
                DateOfBirth = x.DateOfBirth.Value
            }).ToListAsync();

            return students;
        }

        public async Task<StudentViewModel> SearchStudent(string searchString)
        {
            var student = await _schoolContext.Students
                .Where(x => x.StudentName.StartsWith(searchString))
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return new StudentViewModel();
            }

            var viewModel = new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Height = student.Height,
                Weight = student.Weight
            };

            return viewModel;
        }

        public async Task<bool> UpdateStudent(StudentViewModel student)
        {
            var updateEntity = await _schoolContext.Students.FindAsync(student.StudentId);

            if (updateEntity == null)
            {
                return false;
            }

            updateEntity.StudentName = student.StudentName;
            updateEntity.Height = student.Height;
            updateEntity.Weight = student.Weight;

            await _schoolContext.SaveChangesAsync();

            return true;
        }
    }
}
