using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator: AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        //Email
        RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required")
                                        .EmailAddress().WithMessage("Invalid email format");

        //Password
        RuleFor(request => request.Password).NotEmpty().WithMessage("Password is required");
    }
}
