using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

public class AddressEntity : BaseEntity
{
    public string Street { get; set; } = string.Empty;
    public int BuildingNumber { get; set; }
    
    /// <summary>
    /// Город, в котором находится этот адрес
    /// </summary>
    public CityEntity City { get; set; } = null!;
    public Guid CityId { get; set; }
    
    /// <summary>
    /// Филиал по этому адресу
    /// </summary>
    public BranchEntity Branch { get; set; } = null!;
}

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    private const int MaxLength = 256; 
        
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("addresses");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Street).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.BuildingNumber).IsRequired().HasMaxLength(MaxLength);
        
        // связи
        builder.HasOne(x => x.City)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.CityId);

        builder.HasOne(x => x.Branch)
            .WithOne(x => x.Address)
            .HasForeignKey<BranchEntity>(x => x.AddressId);
    }
}