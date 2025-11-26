using FluentValidation;
using SchoolManagment.Core.Feature.Authrntication.Command.Models;

namespace SchoolManagment.Core.Feature.Authrntication.Command.Validation
{
    public class SiginValidatiorCommand : AbstractValidator<SigInCommand>
    {
        #region Field
        #endregion

        #region Constractor
        public SiginValidatiorCommand()
        {
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Not Emty ")
                .NotNull().WithMessage("Email Must not be Null").
            EmailAddress().WithMessage("Email format is invalid");

            RuleFor(x => x.Password).NotEmpty().WithMessage("NOt Empty")
              .NotNull().WithMessage(" password Not Null ");



        }
        #endregion
    }
}
