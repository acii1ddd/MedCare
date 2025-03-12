using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

/// <summary>
/// Филиал
/// </summary>
public class BranchEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Адрес филиала
    /// </summary>
    public AddressEntity Address { get; set; } = null!;
    public Guid AddressId { get; set; }
    
    /// <summary>
    /// Сотрудники, которые работают в этом филиале
    /// </summary>
    public List<WorkerEntity> Workers { get; set; } = [];
    
    /// <summary>
    /// Услуги, которые предоставляет филиал
    /// </summary>
    public List<ServiceEntity> Services { get; set; } = [];
    
    /// <summary>
    /// Записи в регистратуре для данного филиала
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}

public class BranchConfiguration : IEntityTypeConfiguration<BranchEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<BranchEntity> builder)
    {
        builder.ToTable("branches");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(MaxLength);
        
        // связи
        builder.HasOne(x => x.Address)
            .WithOne(x => x.Branch)
            .HasForeignKey<BranchEntity>(x => x.AddressId);
        
        builder.HasMany(x => x.Workers)
            .WithOne(x => x.Branch)
            .HasForeignKey(x => x.BranchId);

        builder.HasMany(x => x.Services)
            .WithMany(x => x.Branches);
        
        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Branch)
            .HasForeignKey(x => x.BranchId);
    }
}