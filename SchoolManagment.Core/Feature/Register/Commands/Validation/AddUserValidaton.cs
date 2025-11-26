using FluentValidation;
using SchoolManagment.Core.Feature.Register.Commands.Model;

namespace SchoolManagment.Core.Feature.Register.Commands.Validation
{
    public class AddUserValidaton : AbstractValidator<AddUserCommand>
    {
        public AddUserValidaton()
        {

            RuleFor(x => x.FullName)
              .NotEmpty().WithMessage("Full name is required")
              .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
             ;

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required")
                .Must(x => x == "Admin" || x == "Teacher" || x == "Student")
                .WithMessage("Role must be Admin, Teacher or Student");



        }

    }
}
