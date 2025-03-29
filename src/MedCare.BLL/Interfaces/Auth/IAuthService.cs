using MedCare.BLL.Models.Auth;
using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Interfaces.Auth;

public interface IAuthService
{
    public Task<AuthAccessTokenModel> SignIn(SignInModel signInModel);

    public Task<UserModel> GetCurrentUserAsync(Guid userId);
}