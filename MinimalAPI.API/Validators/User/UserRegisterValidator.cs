using FluentValidation;
using MinimalAPI.Shared.Communication.Request;

namespace MinimalAPI.API.Validators.User;

public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
