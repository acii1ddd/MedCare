namespace MedCare.Common.Models.Appointments;

public enum AppointmentStatus
{
    /// <summary>
    /// Начальный статус - требуется подтверждение звонком из регистратуры
    /// </summary>
    NotConfirmed = 0,
    
    /// <summary>
    /// Подтвержденный статус - пациент подтвердил свою явку на прием
    /// </summary>
    Confirmed = 1,
    
    /// <summary>
    /// Пациент пришел на прием
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