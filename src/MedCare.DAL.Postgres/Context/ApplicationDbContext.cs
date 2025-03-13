using MedCare.DAL.Entities;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Context;

public class ApplicationDbContext : DbContext
{
    // Users
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    
    // 
    public DbSet<AppointmentEntity> Appointments { get; set; }
    
    public DbSet<BranchEntity> Branches { get; set; }
    
    public DbSet<AddressEntity> Addresses { get; set; }
    
    public DbSet<CityEntity> Cities { get; set; }
    
    public DbSet<MedicalRecordEntity> MedicalRecords { get; set; }
    
    public DbSet<ServiceEntity> Services { get; set; }
    
    public DbSet<SpecializationEntity> Specializations { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentConfiguration).Assembly);
    }
}