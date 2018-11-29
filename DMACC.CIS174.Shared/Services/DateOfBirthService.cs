using DMACC.CIS174.Shared.Services.Interfaces;
using DMACC.CIS174.Shared.ViewModels;

// ReSharper disable once IdentifierTypo
namespace DMACC.CIS174.Shared.Services
{
    public class DateOfBirthService : IDateOfBirthService
    {
        private readonly IDateTimeService _dateTimeService;

        public DateOfBirthService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public bool IsTodayYourBirthday(StudentViewModel student)
        {
            return student.DateOfBirth?.DayOfYear == _dateTimeService.Now().DayOfYear;
        }
    }
}
