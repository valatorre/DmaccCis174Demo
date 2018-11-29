using System;
using AutoMoq;
using DMACC.CIS174.Shared.Services;
using DMACC.CIS174.Shared.Services.Interfaces;
using DMACC.CIS174.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Test
{
    [TestClass]
    public class DateOfBirthServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 10, 15));
        }

        [TestMethod]
        public void BirthdayToday_ReturnsTrue_WhenBirthdayMatchesToday()
        {
            var student = CreateStudent(new DateTime(1975, 10, 15));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var isBirthday = dateOfBirthService.IsTodayYourBirthday(student);

            Assert.IsTrue(isBirthday);
        }

        private StudentViewModel CreateStudent(DateTime dateOfBirth)
        {
            return new StudentViewModel
            {
                StudentId = Guid.NewGuid(),
                StudentName = "Luke Skywalker",
                DateOfBirth = dateOfBirth
            };
        }
    }
}
