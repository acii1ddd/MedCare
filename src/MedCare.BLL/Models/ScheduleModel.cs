using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Models;

public class ScheduleModel : BaseModel
{
    public DayOfWeek DayOfWeek { get; set; }
    
    // только время
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Сотрудники, работающие по этому расписанию
    /// </summary>
    public List<UserModel> Users { get; set; } = [];
}