using System;
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

            context.Students.AddOrUpdate(x => x.StudentId,
                new Student()
                {
                    StudentId = Guid.Parse("ec7b2e5c-9e6d-4639-8509-0b5e455560cc"),
                    StudentName = "Bill Gates", 
                    Height = 6.05m,
                    Weight = 167.8f
                });
        }
    }
}
