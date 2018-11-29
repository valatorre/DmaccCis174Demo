using System;
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
                Address = null,
                DateOfBirth = null
            });

            return await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            var students = await _schoolContext.Students
                .Include(x => x.Address)
                .Select(x => new StudentViewModel
                {
                    StudentId = x.StudentId,
                    StudentName = x.StudentName,
                    Height = x.Height,
                    Weight = x.Weight,
                    Address = new AddressViewModel
                    {
                        AddressId = x.Address.AddressId,
                        AddressType = x.Address.AddressType,
                        City = x.Address.City,
                        Country = x.Address.Country,
                        State = x.Address.State,
                        StreetAddress1 = x.Address.StreetAddress1,
                        StreetAddress2 = x.Address.StreetAddress2,
                        Zip = x.Address.Zip
                    }
                }).ToListAsync();

            return students;
        }

        public async Task<StudentViewModel> GetStudentById(Guid studentId)
        {
            var student = await _schoolContext.Students
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null)
                return new StudentViewModel();

            return new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                DateOfBirth = student.DateOfBirth,
                Height = student.Height,
                Weight = student.Weight,
                Address = new AddressViewModel
                {
                    AddressId = student.Address.AddressId,
                    AddressType = student.Address.AddressType,
                    City = student.Address.City,
                    Country = student.Address.Country,
                    State = student.Address.State,
                    StreetAddress1 = student.Address.StreetAddress1,
                    StreetAddress2 = student.Address.StreetAddress2,
                    Zip = student.Address.Zip
                }
            };
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
