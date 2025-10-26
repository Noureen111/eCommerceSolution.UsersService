using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(request => request.PersonName).NotEmpty().WithMessage("Name is required")
            .Length(1, 50).WithMessage("Name may contain upto 50 characters");
        RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        RuleFor(request => request.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain atleast 8 charaters");
        RuleFor(request => request.Gender).IsInEnum().WithMessage("Gender must be a valid gender option");
    }
}
