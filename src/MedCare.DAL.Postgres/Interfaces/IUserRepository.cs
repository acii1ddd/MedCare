using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;

public interface IUserRepository
{
    public Task<UserEntity?> GetByLoginAsync(string login);
}