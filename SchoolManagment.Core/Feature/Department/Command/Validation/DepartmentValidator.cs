using FluentValidation;
using SchoolManagment.Core.Feature.Department.Command.Model;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Department.Command.Validation
{
    public class DepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {

        #region  Feilds
        #endregion



        #region Constractor

        public DepartmentValidator(IDepartmentServices DepartmentServices)
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(async (name, _) => !await DepartmentServices.ISNameExist(name));


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.");

            RuleFor(x => x.HeadOfDepartmentId)
                .GreaterThan(0).WithMessage("HeadOfDepartmentId must be greater than 0.")
                .MustAsync(async (id, _) => await DepartmentServices.IsTeacherAsync(id))
                .WithMessage("Only teachers can be assigned as Head of Department.");
        }
        #endregion









    }

}

