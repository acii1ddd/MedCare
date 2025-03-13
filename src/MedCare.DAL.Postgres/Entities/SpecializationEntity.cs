using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

/// <summary>
/// Направление
/// </summary>
public class SpecializationEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Услуги этой специализации
    /// </summary>
    public List<ServiceEntity> Services { get; set; } = null!;
    
    /// <summary>
    /// Сотрудники этой специализации
    /// </summary>
    public List<UserEntity> Workers { get; set; } = null!;
}

public class SpecializationConfiguration : IEntityTypeConfiguration<SpecializationEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<SpecializationEntity> builder)
    {
        builder.ToTable("specializations");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(MaxLength);
        
        // связи
        builder.HasMany(x => x.Services)
            .WithOne(x => x.Specialization)
            .HasForeignKey(x => x.SpecializationId);
        
        builder.HasMany(x => x.Workers)
            .WithOne(x => x.Specialization)
            .HasForeignKey(x => x.SpecializationId)
            .IsRequired(false); // если worker не доктор
    }
}