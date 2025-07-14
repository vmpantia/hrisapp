using HRIS.Infrastructure.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Contexts;

public class HRISDbContext : DbContext
{
    public HRISDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Employment> Employments { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Salary> Salaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => e.DeletedAt == null && string.IsNullOrEmpty(e.DeletedBy));
        });

        modelBuilder.Entity<Contact>(builder =>
        {
            builder.HasKey(c => new { c.EmployeeId, c.Type, c.Value } );
            builder.HasOne(c => c.Employee)
                .WithMany(e => e.Contacts)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();
            builder.HasQueryFilter(c => c.DeletedAt == null && string.IsNullOrEmpty(c.DeletedBy));
        });
        
        modelBuilder.Entity<Address>(builder =>
        {
            builder.HasKey(a => new { a.EmployeeId } );
            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Addresses)
                .HasForeignKey(a => a.EmployeeId)
                .IsRequired();
            builder.HasQueryFilter(a => a.DeletedAt == null && string.IsNullOrEmpty(a.DeletedBy));
        });
        
        modelBuilder.Entity<Employment>(builder =>
        {
            builder.HasKey(e => new { e.EmployeeId } );
            builder.HasOne(e => e.Employee)
                .WithOne(e => e.Employment)
                .HasForeignKey<Employee>(e => e.Id)
                .IsRequired();
            builder.HasOne(e => e.Job)
                .WithMany(j => j.Employments)
                .HasForeignKey(e => e.JobId)
                .IsRequired();
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employments)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();
            builder.HasQueryFilter(e => e.DeletedAt == null && string.IsNullOrEmpty(e.DeletedBy));
        });
        
        modelBuilder.Entity<Job>(builder =>
        {
            builder.HasKey(j => new { j.Id } );
            builder.HasQueryFilter(e => e.DeletedAt == null && string.IsNullOrEmpty(e.DeletedBy));
        });
        
        modelBuilder.Entity<Department>(builder =>
        {
            builder.HasKey(d => new { d.Id } );
            builder.HasQueryFilter(e => e.DeletedAt == null && string.IsNullOrEmpty(e.DeletedBy));
        });
        
        modelBuilder.Entity<Salary>(builder =>
        {
            builder.HasKey(s => new { s.Id } );
            builder.HasOne(s => s.Employment)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeId)
                .IsRequired();
            builder.HasQueryFilter(e => e.DeletedAt == null && string.IsNullOrEmpty(e.DeletedBy));
        });
    }
}