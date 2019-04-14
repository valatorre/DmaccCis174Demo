using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using DMACC.CIS174.Domain.Entities;

namespace DMACC.CIS174.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Bill Gates
            context.Students.AddOrUpdate(x => x.StudentId,
                new Student
                {
                    StudentId = Guid.Parse("ec7b2e5c-9e6d-4639-8509-0b5e455560cc"),
                    StudentName = "Bill Gates",
                    DateOfBirth = new DateTime(1955, 10, 28),
                    Height = 5.83m,
                    Weight = 167.8f,
                });

            // Steve Jobs
            context.Students.AddOrUpdate(x => x.StudentId,
                new Student
                {
                    StudentId = Guid.Parse("ca1b26a6-9543-4c5e-bf9a-dde2454f04eb"),
                    StudentName = "Steve Jobs",
                    DateOfBirth = new DateTime(1955, 2, 24),
                    Height = 6.17m,
                    Weight = 186.4f
                });

            // Mark Zuckerberg
            context.Students.AddOrUpdate(x => x.StudentId,
                new Student
                {
                    StudentId = Guid.Parse("1d97d3a4-f0d1-4711-9f40-004511f3c249"),
                    StudentName = "Mark Zuckerberg",
                    DateOfBirth = new DateTime(1984, 5, 14),
                    Height = 5.58m,
                    Weight = 141.9f
                });

            // Jeff Bezos
            context.Students.AddOrUpdate(x => x.StudentId,
                new Student
                {
                    StudentId = Guid.Parse("603525d8-b441-4da1-af11-928f8db9f933"),
                    StudentName = "Jeff Bezos",
                    DateOfBirth = new DateTime(1964, 1, 12),
                    Height = 5.58m,
                    Weight = 152.2f
                });
        }
    }
}
