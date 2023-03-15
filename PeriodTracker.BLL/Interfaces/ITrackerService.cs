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
        public Task<Response<PeriodDetail>> NextPeriodAsync(PeriodDetail periodDetail);
        public Task<Response<PeriodDetail>> FertilityWindowAsync(PeriodDetail periodDetail);
        public Task<Response<PeriodDetail>> SafePeriodAsync(PeriodDetail periodDetail);
        public Task<Response<PeriodDetail>> OvulationDayAsync(PeriodDetail periodDetail);
    }
}
