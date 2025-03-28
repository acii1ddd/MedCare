using FluentValidation;
using MedCare.API.Contracts.Requests;

namespace MedCare.API.Validators;

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(x => x.Login).NotEmpty().WithMessage("Логин не может быть пустым");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Пароль не может быть пустым");
    }
}