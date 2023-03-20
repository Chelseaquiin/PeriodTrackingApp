using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.BLL.Model
{
    public class BasePeriodDetailsVM
    {
        [Required(ErrorMessage = "Please select your last period start date")]
        public string LastPeriod { get; set; }
        [Required(ErrorMessage = "Please input the length of your period")]
        [Range(3, 10, ErrorMessage = "Should be between the range of 3 and 10")]
        public byte PeriodLength { get; set; }
        [Required]
        [Range(25, 35, ErrorMessage = "Should be between the range of 25 and 35")]
        public byte CycleLength { get; set; }
    }
}
