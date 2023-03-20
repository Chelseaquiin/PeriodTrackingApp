using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Model
{
    public class PeriodDetailsVM : BasePeriodDetailsVM
    {
        [StringLength(200), MinLength(20)]
        public string Note { get; set; }
    }
}
