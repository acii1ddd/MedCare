using MedCare.BLL.Interfaces;
using MedCare.BLL.Services;
using MedCare.BLL.Services.Auth;

namespace MedCare.BLL.Tests;

public class Tests
{
    private readonly IPasswordHashService _passwordHashService;

    public Tests()
    {
        _passwordHashService = new PasswordHashService();
    }

    [Test]
    public void PasswordHashServiceTests()
    {
        var hash = _passwordHashService.HashPassword("123");
        Console.WriteLine(hash);
    }
}