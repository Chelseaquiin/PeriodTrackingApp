using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodTracker.DAL.Models;

public class PeriodTrackerDbContext : DbContext
{
    public PeriodTrackerDbContext(DbContextOptions<PeriodTrackerDbContext> options): base(options)
    {

    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<PeriodDetail> PeriodDetails { get; set; }

}
