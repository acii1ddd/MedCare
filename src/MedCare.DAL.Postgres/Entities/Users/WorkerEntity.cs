using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities.Users;

public class WorkerEntity : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    /// <summary>
    /// Профиль с информацией работника
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
    public BranchEntity Branch { get; set; } = null!;
    public Guid BranchId { get; set; }
    
    
    // график работы
    
    
    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentEntity>? Appointments { get; set; }
}

public class WorkerConfiguration : IEntityTypeConfiguration<WorkerEntity>
{
    private const int MaxLength = 512;
    public void Configure(EntityTypeBuilder<WorkerEntity> builder)
    {
        builder.ToTable("workers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Login).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(MaxLength);
        
        // связи
        builder.HasOne(x => x.UserProfile)
            .WithOne(x => x.Worker)
            .HasForeignKey<WorkerEntity>(x => x.UserProfileId);
        
        builder.HasOne(x => x.Specialization)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.SpecializationId)
            .IsRequired(false); // если worker не доктор

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.BranchId);
        
        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.DoctorId)
            .IsRequired(false); // анализы ?
    }
}