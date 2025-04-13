using System.ComponentModel.DataAnnotations.Schema;
using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities.Appointments;

/// <summary>
/// Записи на прием (запись в регистратуре)
/// </summary>
public class AppointmentEntity : BaseEntity
{
    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Пациент
    /// </summary>
    public UserEntity Patient { get; set; } = null!;
    public Guid PatientId { get; set; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public UserEntity? Doctor { get; set; }
    public Guid? DoctorId { get; set; }
    
    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public ServiceEntity Service { get; set; } = null!;
    public Guid ServiceId { get; set; }
    
    /// <summary>
    /// Медицинские записи, связанные с этим приемом (добавляет врач)
    /// </summary>
    public List<MedicalRecordEntity> MedicalRecords { get; set; } = null!;
}

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    private const int MaxLength = 512;
    
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.ToTable("appointments");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.VisitDate).IsRequired();
        builder.Property(x => x.AppointmentStatus).IsRequired();
        builder.Property(x => x.PaymentStatus).IsRequired();
        
        builder.Property(x => x.Note)
            .IsRequired(false)
            .HasMaxLength(MaxLength);
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("current_timestamp");
        
        // связи
        builder.HasOne(x => x.Patient)
            .WithMany(x => x.PatientAppointments)
            .HasForeignKey(x => x.PatientId);
        
        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.DoctorAppointments)
            .HasForeignKey(x => x.DoctorId)
            .IsRequired(false); // анализы?
        
        builder.HasOne(x => x.Service)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.ServiceId);
        
        builder.HasMany(x => x.MedicalRecords)
            .WithOne(x => x.Appointment)
            .HasForeignKey(x => x.AppointmentId);
    }
}
