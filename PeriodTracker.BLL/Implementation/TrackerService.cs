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
        public async Task<Response<PeriodDetail>> FertilityWindowAsync(PeriodDetail periodDetail)
        {
            if (periodDetail is null)
            {
                return new Response<PeriodDetail>
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
            var fertilityWindow = ovulationDay - FertilityWindow.Fertility;
            detail.LastPeriod = detail.LastPeriod.AddDays((double)fertilityWindow);
            await _context.PeriodDetails.AddAsync(detail);
            var saveResult = await _context.SaveChangesAsync();
            var result = new Response<PeriodDetail>
            {
                Message = "Fertility window details",
                IsSuccessful = true,
                Result = detail
            };
            return saveResult > 0 ? result : new Response<PeriodDetail>
            {
                Message = "Invalid details",
                IsSuccessful = false,

            };
            



        }

        public async Task<Response<PeriodDetail>> NextPeriodAsync(PeriodDetail periodDetail)
        {
            if (periodDetail is null)
            {
                return new Response<PeriodDetail>
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
            detail.LastPeriod = detail.LastPeriod.AddDays(detail.CycleLength);
            await _context.PeriodDetails.AddAsync(detail);
            var saveResult = await _context.SaveChangesAsync();
            var result = new Response<PeriodDetail>
            {
                Message = "Next period details",
                IsSuccessful = true,
                Result = detail
            };
            return saveResult > 0 ? result : new Response<PeriodDetail>
            {
                Message = "Invalid details",
                IsSuccessful = false,

            };
          
            

            
        }

        public async Task<Response<PeriodDetail>> OvulationDayAsync(PeriodDetail periodDetail)
        {
            if (periodDetail is null)
            {
                return new Response<PeriodDetail>
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
            var result = new Response<PeriodDetail>
            {
                Message = "Ovulation day details",
                IsSuccessful = true,
                Result = detail
            };
            return saveResult > 0 ? result : new Response<PeriodDetail>
            {
                Message = "Invalid details",
                IsSuccessful = false,

            };

            
        }

        public async Task<Response<PeriodDetail>> SafePeriodAsync(PeriodDetail periodDetail)
        {
            throw new NotImplementedException();
        }
    }
}
