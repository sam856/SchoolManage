using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Course.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
