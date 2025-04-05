using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Models;

public class ScheduleModel : BaseModel
{
    // timestamp в Postgres
    public DateTime WorkDate { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    // interval в Postgres
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Сотрудники, работающие по этому расписанию
    /// </summary>
    public List<UserModel> Users { get; set; } = [];
}