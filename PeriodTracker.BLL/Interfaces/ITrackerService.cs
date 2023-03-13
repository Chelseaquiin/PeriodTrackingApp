using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Interfaces
{
    public interface ITrackerService
    {
        public void NextPeriod();
        public void FertilityWindow();
        public void SafePeriod();
    }
}
