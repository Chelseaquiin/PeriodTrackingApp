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
        [Required(ErrorMessage = "Please select your last period date")]
        public string LastPeriod { get; set; }
        [Required(ErrorMessage = "Please input your Period lenght")]
        [Range(3, 10, ErrorMessage = "should be between the range of 3 and 10")]
        public byte PeriodLength { get; set; }
        [Required]
        [Range(25, 35, ErrorMessage = "should be between the range of 25 and 35")]
        public byte CycleLength { get; set; }
        //[StringLength(200), MinLength(20)]
        public string Note { get; set; }
    }
}
