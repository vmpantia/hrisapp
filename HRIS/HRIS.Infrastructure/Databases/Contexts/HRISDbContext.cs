using HRIS.Infrastructure.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Contexts;

public class HRISDbContext : DbContext
{
    public HRISDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Contacts)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();
            builder.HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .IsRequired();
        });

        modelBuilder.Entity<Contact>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(c => c.Employee)
                .WithMany(e => e.Contacts)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();
        });
        
        modelBuilder.Entity<Address>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Addresses)
                .HasForeignKey(a => a.EmployeeId)
                .IsRequired();
        });
    }
}