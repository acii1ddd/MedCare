using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Entities.Branches;
using MedCare.DAL.Entities.Cities;
using MedCare.DAL.Entities.MedicalRecords;
using MedCare.DAL.Entities.Services;
using MedCare.DAL.Entities.Specializations;
using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppointmentEntity> Appointments { get; set; }
    
    public DbSet<BranchEntity> Branches { get; set; }
    
    public DbSet<CityEntity> Cities { get; set; }
    
    public DbSet<MedicalRecordEntity> MedicalRecords { get; set; }
    
    public DbSet<ServiceEntity> Services { get; set; }
    
    public DbSet<SpecializationEntity> Specializations { get; set; }
    
    // Users
    public DbSet<PatientEntity> Patients { get; set; }
    
    public DbSet<DoctorEntity> Doctors { get; set; }
    
    public DbSet<ReceptionistEntity> Receptionists { get; set; }
    
    public DbSet<AdminEntity> Admins { get; set; }
    
    // User accounts and profiles
    public DbSet<UserAccountEntity> UserAccounts { get; set; }
    
    public DbSet<UserProfileEntity> UserProfiles { get; set; }
}