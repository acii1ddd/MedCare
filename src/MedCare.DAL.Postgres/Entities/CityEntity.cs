using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

public class CityEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Адреса этого города
    /// </summary>
    public List<AddressEntity> Addresses { get; set; } = [];
}

public class CityConfiguration : IEntityTypeConfiguration<CityEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<CityEntity> builder)
    {
        builder.ToTable("cities");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(MaxLength);
        
        // связи
        builder.HasMany(x => x.Addresses)
            .WithOne(x => x.City)
            .HasForeignKey(x => x.CityId);
    }
}