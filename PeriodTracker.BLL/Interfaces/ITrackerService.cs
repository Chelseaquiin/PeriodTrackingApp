using PeriodTracker.BLL.Model;
using PeriodTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Interfaces
{
    public interface ITrackerService
    {
        public Response<(DateTime startDate, DateTime endDate)> GetNextPeriod(DateTime lastPeriodStartDate, byte cycleLength, byte periodLength);
        public Task<Response<PeriodDetailsVM>> FertilityWindowAsync(PeriodDetailsVM periodDetail);
        public Task<Response<PeriodDetailsVM>> SafePeriodAsync(PeriodDetailsVM periodDetail);
        public DateTime OvulationDayAsync(DateTime lastPeriodStartDate, byte cycleLength);
        public Task<Response<PeriodDetailsVM>> GetPeriodDetailsAsync(PeriodDetailsVM periodDetail);
    }
}
