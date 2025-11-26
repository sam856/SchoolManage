using FluentValidation;
using SchoolManagment.Core.Feature.Course.Commands.Models;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Course.Commands.Vaildtion
{
    public class UPdateCourseValidation : AbstractValidator<UpdateCourseCommand>
    {
        public UPdateCourseValidation(ICourseServices courseServices)
        {


            RuleFor(x => x.Code)
                   .MustAsync(async (code, _) => !await courseServices.ISCodeExist(code)).WithMessage("Code must be unique.");


            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
        }
    }
}
