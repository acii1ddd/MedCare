using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities.Users;

/// <summary>
/// Информация о пользователях
/// </summary>
public class UserProfileEntity : BaseEntity
{
    public byte[]? Image { get; set; } = [];
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PassportSeries { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Соответствующий этому профилю пользователь
    /// </summary>
    public UserEntity User { get; set; } = null!;
}

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfileEntity>
{
    private const int MaxLength = 256;
    
    public void Configure(EntityTypeBuilder<UserProfileEntity> builder)
    {
        builder.ToTable("user_profiles");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Image).IsRequired(false);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.Patronymic).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.Email).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.PassportSeries).IsRequired().HasMaxLength(MaxLength);
        builder.Property(x => x.PassportNumber).IsRequired().HasMaxLength(MaxLength);
    }
}