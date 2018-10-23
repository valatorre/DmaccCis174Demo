using DMACC.CIS174.Shared.ViewModels;

namespace DMACC.CIS174.Shared.Services.Interfaces
{
    public interface IDateOfBirthService
    {
        bool IsTodayYourBirthday(StudentViewModel student);
    }
}
