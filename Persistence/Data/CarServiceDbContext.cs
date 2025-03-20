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
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitService> VisitServices { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<MechanicService> MechanicServices { get; set; }
    public DbSet<ServiceTool> ServiceTools { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<VisitServiceSchedule> VisitServiceSchedules { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}