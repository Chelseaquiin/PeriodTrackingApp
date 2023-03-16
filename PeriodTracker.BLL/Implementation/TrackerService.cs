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
        public async Task<Response<PeriodDetailsVM>> FertilityWindowAsync(PeriodDetailsVM periodDetail)
        {
            if (periodDetail is null)
            {
                return new Response<PeriodDetailsVM>
                {
                    Message = "Invalid Period Details",
                    IsSuccessful = false,

                };
            }
            var detail = new PeriodDetail
            {
                LastPeriod = periodDetail.LastPeriod,
                CycleLength = periodDetail.CycleLength,
                PeriodLength = periodDetail.PeriodLength,
                Note = periodDetail.Note
            };
            var ovulationDay = detail.CycleLength / (int)FertilityWindow.Ovulation;
            var fertilityWindow = ovulationDay - FertilityWindow.Fertility;
            detail.LastPeriod = detail.LastPeriod.AddDays((double)fertilityWindow);
            await _context.PeriodDetails.AddAsync(detail);
            var saveResult = await _context.SaveChangesAsync();
            var result = new Response<PeriodDetailsVM>
            {
                Message = "Fertility window details",
                IsSuccessful = true,
                Result = periodDetail
            };
            return saveResult > 0 ? result : new Response<PeriodDetailsVM>
            {
                Message = "Invalid details",
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
            


        public DateTime GetOvulationDayAsync(DateTime lastPeriodStartDate, byte cycleLength)
        {
           /* if (periodDetail is null)
            {
                return new Response<PeriodDetailsVM>
                {
                    Message = "Invalid Period Details",
                    IsSuccessful = false,

                };
            }
            var detail = new PeriodDetail
            {
                LastPeriod = periodDetail.LastPeriod,
                CycleLength = periodDetail.CycleLength,
                PeriodLength = periodDetail.PeriodLength,
                Note = periodDetail.Note,
            };
            var ovulationDay = detail.CycleLength / (int)FertilityWindow.Ovulation;
            detail.LastPeriod = detail.LastPeriod.AddDays(ovulationDay);
            await _context.PeriodDetails.AddAsync(detail);
            var saveResult = await _context.SaveChangesAsync();
            var result = new Response<PeriodDetailsVM>
            {
                Message = "Ovulation day details",
                IsSuccessful = true,
                Result = periodDetail
            };
            return saveResult > 0 ? result : new Response<PeriodDetailsVM>
            {
                Message = "Invalid details",
                IsSuccessful = false,

            };

           */
           throw new NotImplementedException();
        }

        public Task<Response<PeriodDetailsVM>> GetPeriodDetailsAsync(PeriodDetailsVM periodDetail)
        {
            throw new NotImplementedException();
        }

        public DateTime OvulationDayAsync(DateTime lastPeriodStartDate, byte cycleLength)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PeriodDetailsVM>> SafePeriodAsync(PeriodDetailsVM periodDetail)
        {
            throw new NotImplementedException();
        }
    }
}
