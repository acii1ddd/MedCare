using MedCare.DAL.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

/// <summary>
/// Медицинские записи пациентов
/// </summary>
public class MedicalRecordEntity : BaseEntity
{
    public string? Diagnosis { get; set; } = string.Empty;
    
    /// <summary>
    /// Предписания по лечению
    /// </summary>
    public string? Treatment { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    /// <summary>
    /// Соответствующий прием пациента по его записи
    /// </summary>
    public AppointmentEntity Appointment { get; set; } = null!;
    public Guid AppointmentId { get; set; }
}

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecordEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<MedicalRecordEntity> builder)
    {
        builder.ToTable("medical_records");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Diagnosis).IsRequired(false).HasMaxLength(MaxLength);
        builder.Property(x => x.Treatment).IsRequired(false).HasMaxLength(MaxLength);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(MaxLength);
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("current_timestamp");
        
        // связи
        builder.HasOne(x => x.Appointment)
            .WithMany(x => x.MedicalRecords)
            .HasForeignKey(x => x.AppointmentId);
    }
}