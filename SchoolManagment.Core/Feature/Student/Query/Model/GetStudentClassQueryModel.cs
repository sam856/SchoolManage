using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Student.Query.Model
{
    public class GetStudentClassQueryModel : IRequest<Response<List<StudentClassesDto>>>
    {
    }


}
