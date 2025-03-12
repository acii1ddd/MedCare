using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

/// <summary>
/// Услуга
/// </summary>
public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    /// <summary>
    /// Специализация, к которой относится данная услуга
    /// </summary>
    public SpecializationEntity Specialization { get; set; } = null!;
    public Guid SpecializationId { get; set; }
    
    /// <summary>
    /// Записи на прием, на которых оказывается эта услуга
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
    
    /// <summary>
    /// Филиалы, в которых может оказываться данная услуга
    /// </summary>
    public List<BranchEntity> Branches { get; set; } = [];
}

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.ToTable(
            "services"
            //t => t.HasCheckConstraint("CK_Service_Price", "price > 0")
        );
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.Price).IsRequired();
        
        // связи
        builder.HasOne(x => x.Specialization)
            .WithMany(x => x.Services)
            .HasForeignKey(x => x.SpecializationId);
        
        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Service)
            .HasForeignKey(x => x.ServiceId);

        builder.HasMany(x => x.Branches)
            .WithMany(x => x.Services);
    }
}