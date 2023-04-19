using Coravel.Pro.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace OnlineJobs.Models;

public class Database : DbContext, ICoravelProDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("data source=app.db");

    public DbSet<CoravelJobHistory> Coravel_JobHistory { get; set; } = default!;
    public DbSet<CoravelScheduledJob> Coravel_ScheduledJobs { get; set; } = default!;
    public DbSet<CoravelScheduledJobHistory> Coravel_ScheduledJobHistory { get; set; } = default!;
}