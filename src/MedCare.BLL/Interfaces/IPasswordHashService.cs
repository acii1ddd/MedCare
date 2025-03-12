namespace MedCare.BLL.Interfaces;

public interface IPasswordHashService
{
    public string HashPassword(string password);
    
    public bool VerifyPassword(string password, string passwordHash);
}