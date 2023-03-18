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
        public Response<(DateTime startDate, DateTime endDate)> GetFertilityWindow(DateTime lastPeriodStartDate);
        public Response<(DateTime, DateTime)> GetSafePeriod(DateTime lastPeriodStartDate, byte cycleLength);
        public Response<DateTime> GetOvulationDay(DateTime lastPeriodStartDate);
        public Task<Response<PeriodDetailsVM>> GetPeriodDetailsAsync(PeriodDetailsVM periodDetail);
    }
}
