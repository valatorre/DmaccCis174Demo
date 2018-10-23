using System;
using DMACC.CIS174.Shared.Services.Interfaces;

namespace DMACC.CIS174.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
