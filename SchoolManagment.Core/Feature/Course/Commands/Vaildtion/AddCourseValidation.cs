using FluentValidation;
using SchoolManagment.Core.Feature.Course.Commands.Models;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Course.Commands.Vaildtion
{
    public class AddCourseValidation : AbstractValidator<AddCourseCommand>
    {




        #region Constractor

        public AddCourseValidation(ICourseServices courseServices)
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");


            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.")
                   .MustAsync(async (code, _) => !await courseServices.ISCodeExist(code)).WithMessage("Code must be unique.");


            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
        }
        #endregion









    }

}
