using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Course.Queries.Models
{
    public class GetCourseByIdQuery : IRequest<Response<CourseDto>>
    {

        public int Id { get; set; }
        public GetCourseByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
