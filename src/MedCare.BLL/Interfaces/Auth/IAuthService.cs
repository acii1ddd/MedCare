using MedCare.BLL.Models.Auth;

namespace MedCare.BLL.Interfaces.Auth;

public interface IAuthService
{
    public Task<AuthAccessTokenModel> SignIn(SignInModel signInModel);
}