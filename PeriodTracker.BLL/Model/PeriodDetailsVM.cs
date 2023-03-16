using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Model
{
    public class PeriodDetailsVM
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastPeriod { get; set; }
        [Required]
        public int PeriodLength { get; set; }
        [Required]
        public int CycleLength { get; set; }
        [StringLength(200), MinLength(20)]
        public string Note { get; set; }
    }
}
