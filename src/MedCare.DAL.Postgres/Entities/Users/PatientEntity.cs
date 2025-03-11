using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities.Users;

public class PatientEntity : BaseEntity
{
    /// <summary>
    /// Профиль с информацией пациента
    /// </summary>
    public UserProfileEntity UserProfile { get; set; } = null!;   
    public Guid UserProfileId { get; set; }

    /// <summary>
    /// Записи этого пациента на прием
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}

public class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
{
    public void Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.ToTable("patients");
        
        builder.HasKey(x => x.Id);
        
        // связи
        builder.HasOne(x => x.UserProfile)
            .WithOne(x => x.Patient)
            .HasForeignKey<PatientEntity>(x => x.UserProfileId);
        
        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Patient)
            .HasForeignKey(x => x.PatientId);
    }
}