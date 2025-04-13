namespace MedCare.DAL.Entities.Appointments;

public enum AppointmentStatus
{
    /// <summary>
    /// Подтвержденный статус - пациент подтвердил свою явку на прием
    /// </summary>
    Confirmed = 1,
    
    /// <summary>
    /// Пациент прошел прием
    /// </summary>
    Completed = 2,
    
    /// <summary>
    /// Пациент подтвердил свою явку, но не явился на прием
    /// </summary>
    NoShow = 3,
    
    /// <summary>
    /// Запись на прием отменена
    /// </summary>
    Canceled = 4
}