using FluentValidation;
using KP11WebAPI.Models;

namespace KP11WebAPI.Validation;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(x => x.Login).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(5).MaximumLength(25);
    }
}