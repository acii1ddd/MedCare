using MedCare.DAL.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities.Users;

public class UserEntity : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }

    /// <summary>
    /// Профиль с информацией пользователя
    /// </summary>
    public UserProfileEntity UserProfile { get; set; } = null!;
    public Guid UserProfileId { get; set; }
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public SpecializationEntity? Specialization { get; set; }
    public Guid? SpecializationId { get; set; }
    
    /// <summary>
    /// Филиал, в котором работает работник
    /// </summary>
    public BranchEntity? Branch { get; set; }
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentEntity>? DoctorAppointments { get; set; }
    
    /// <summary>
    /// Записи на прием, где этот user - пациент
    /// </summary>
    public List<AppointmentEntity>? PatientAppointments { get; set; }
    
    /// <summary>
    /// График работы сотрудника (набор записей в shedules для определенных дней недели)
    /// </summary>
    public List<ScheduleEntity>? Schedules { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    private const int MaxLength = 512;
    
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Login).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.UserRole).IsRequired();
        
        // связи
        builder.HasOne(x => x.UserProfile)
            .WithOne(x => x.User)
            .HasForeignKey<UserEntity>(x => x.UserProfileId);
        
        builder.HasOne(x => x.Specialization)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.SpecializationId)
            .IsRequired(false); // если worker не доктор

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.BranchId);
        
        builder.HasMany(x => x.DoctorAppointments)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.DoctorId)
            .IsRequired(false); // анализы ?
        
        builder.HasMany(x => x.PatientAppointments)
            .WithOne(x => x.Patient)
            .HasForeignKey(x => x.PatientId);

        builder.HasMany(x => x.Schedules)
            .WithMany(x => x.Users);
    }
}