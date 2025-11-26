using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Course.Queries.Models
{
    public class GetAllCourseQuery : IRequest<Response<List<CourseDto>>>
    {
    }
}
