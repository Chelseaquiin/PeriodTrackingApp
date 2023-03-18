using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;
using PeriodTracker.DAL.Models;
using PeriodTracker.DAL.Enums;

namespace PeriodTracker.BLL.Implementation
{
    public class TrackerService : ITrackerService
    {
        private readonly PeriodTrackerDbContext _context;

        public TrackerService(PeriodTrackerDbContext context)
        {
            _context = context;
        }
        public Response<(DateTime, DateTime)> GetFertilityWindow(DateTime lastPeriodStartDate)
        {
            var startDate = (int)FertilityWindow.Ovulation - (int)FertilityWindow.Fertility;
            var fertilityStartDate = lastPeriodStartDate.AddDays(startDate);
            var fertilityEndDate = lastPeriodStartDate.AddDays((int)FertilityWindow.Ovulation);

            return lastPeriodStartDate > DateTime.MinValue ?
           new Response<(DateTime startDate, DateTime endDate)>
           {
               Message = "Succesful",
               IsSuccessful = true,
               Result = (startDate: fertilityStartDate, endDate: fertilityEndDate)
           } : new Response<(DateTime, DateTime)>
           {
               Message = "Invalid fields",
               IsSuccessful = false,
           };
        }

        public Response<(DateTime, DateTime)> GetNextPeriod(DateTime lastPeriodStartDate, byte cycleLength, byte periodLength)
        {
            var periodStartDate = lastPeriodStartDate.AddDays(cycleLength);
            var periodEndDate = periodStartDate.AddDays(periodLength);

            return lastPeriodStartDate > DateTime.MinValue && cycleLength > 0 ?
           new Response<(DateTime startDate, DateTime endDate)>
           {
               Message = "Succesful",
               IsSuccessful = true,
               Result = (startDate: periodStartDate, endDate: periodEndDate)
           } : new Response<(DateTime, DateTime)>
           {
               Message = "Invalid fields",
               IsSuccessful = false,  
           };
        }
        public Response<DateTime> GetOvulationDay(DateTime lastPeriodStartDate)
        {
            var ovulationDate = lastPeriodStartDate.AddDays((int)FertilityWindow.Ovulation);

            return lastPeriodStartDate > DateTime.MinValue ?
           new Response<DateTime>
           {
               Message = "Succesful",
               IsSuccessful = true,
               Result = ovulationDate
           } : new Response<DateTime>
           {
               Message = "Invalid fields",
               IsSuccessful = false,

           };

        }
        public Task<Response<PeriodDetailsVM>> GetPeriodDetailsAsync(PeriodDetailsVM periodDetail)
        {
            throw new NotImplementedException();
        }
        public Response<(DateTime, DateTime)> GetSafePeriod(DateTime lastPeriodStartDate, byte cycleLength)
        {
            var safeDate = (int)FertilityWindow.Ovulation + (int)FertilityWindow.Fertility;
            var safePeriodStartDate = lastPeriodStartDate.AddDays(safeDate);
            var safePeriodEndDate = safePeriodStartDate.AddDays((int)FertilityWindow.SafeDate);

            return lastPeriodStartDate > DateTime.MinValue && cycleLength >= 28 ?
           new Response<(DateTime startDate, DateTime endDate)>
           {
               Message = "Succesful",
               IsSuccessful = true,
               Result = (startDate: safePeriodStartDate, endDate: safePeriodEndDate)
           } : new Response<(DateTime, DateTime)>
           {
               Message = "Invalid fields",
               IsSuccessful = false,
           };
        }
    }
}
