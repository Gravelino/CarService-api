using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class CarServiceDbContext :DbContext
{
    public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<Worker> Worker { get; set; }
    public DbSet<WorkerService> WorkerServices { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobSchedule> JobSchedules { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<ServiceTool> ServiceTools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobSchedule)
            .WithOne(js => js.Job)
            .HasForeignKey<JobSchedule>(js => js.JobId);

        modelBuilder.Entity<ServiceTool>()
            .HasKey(st => new { st.ServicesId, st.ToolsId });
        
        modelBuilder.Entity<ServiceTool>()
            .HasOne(st => st.Service)
            .WithMany(s => s.ServiceTools)
            .HasForeignKey(st => st.ServicesId);
        
        modelBuilder.Entity<ServiceTool>()
            .HasOne(st => st.Tool)
            .WithMany(t => t.ServiceTools)
            .HasForeignKey(st => st.ToolsId);
    }

        
        /*
            modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Car>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Worker>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<ServiceCategory>().HasQueryFilter(sc => !sc.IsDeleted);
            modelBuilder.Entity<Service>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<Visit>().HasQueryFilter(v => !v.IsDeleted);
            modelBuilder.Entity<VisitService>().HasQueryFilter(vs => !vs.IsDeleted);
            modelBuilder.Entity<Feedback>().HasQueryFilter(f => !f.IsDeleted);
            modelBuilder.Entity<Payment>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<WorkerService>().HasQueryFilter(ms => !ms.IsDeleted);
            modelBuilder.Entity<ServiceTool>().HasQueryFilter(st => !st.IsDeleted);
            modelBuilder.Entity<Tool>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<VisitServiceSchedule>().HasQueryFilter(vss => !vss.IsDeleted);
            modelBuilder.Entity<Transaction>().HasQueryFilter(t => !t.IsDeleted);
        */

    
}