using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedCare.DAL.Entities;

public class ScheduleEntity : BaseEntity
{
    // DATE в Postgres
    public DateTime WorkDate { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    // TIME в Postgres
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Сотрудники, работающие по этому расписанию
    /// </summary>
    public List<UserEntity> Users { get; set; } = [];
}

public class SchedulConfiguration : IEntityTypeConfiguration<ScheduleEntity>
{
    public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
    {
        builder.ToTable("schedules");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.WorkDate).IsRequired();
        builder.Property(x => x.StartTime).IsRequired();
        builder.Property(x => x.EndTime).IsRequired();
        
        // связи
        builder.HasMany(x => x.Users)
            .WithMany(x => x.Schedules);
    }
}
