using AutoMapper;
using MedCare.BLL.Exceptions;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Interfaces.Auth;
using MedCare.BLL.Models.Auth;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MedCare.BLL.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly AuthSettings _authSettings;
    
    public AuthService(
        IUserRepository userRepository, 
        IPasswordHashService passwordHashService,
        IMapper mapper, 
        ILogger<AuthService> logger,
        IOptions<AuthSettings> authSettings)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _passwordHashService = passwordHashService;
        _authSettings = authSettings.Value;
    }

    public async Task<AuthAccessTokenModel> SignIn(SignInModel signInModel)
    {
        var userSignInDetails = _mapper.Map<UserModel>(await _userRepository
            .GetByLoginAsync(signInModel.Login));

        if (userSignInDetails is null)
        {
            throw new NotFoundException($"Пользователь с логином {signInModel.Login} не найден");
        }
        if (!_passwordHashService.VerifyPassword(signInModel.Password, userSignInDetails.PasswordHash))
        {
            throw new InvalidOperationException("Неверный пароль");
        }

        _logger.LogInformation("Пользователь с логином {login} аутентифицирован успешно", userSignInDetails.Login);
        return AuthTokenGenerator.GenerateAccessToken(new GenerateTokenPayload
        {
            UserId = userSignInDetails.Id,
            UserRole = userSignInDetails.UserRole
        }, _authSettings);
    }
}