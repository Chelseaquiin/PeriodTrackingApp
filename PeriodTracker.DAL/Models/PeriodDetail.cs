using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.DAL.Models;

public class PeriodDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PeriodDetailId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime LastPeriod { get; set; }
    [Required]
    public int PeriodLength { get; set; }
    [Required]
    public int CycleLength { get; set; }
    [StringLength(200), MinLength(20)]
    public string Note { get; set; }
    public int UserId { get; set; }
    public User Users { get; set; }
}
