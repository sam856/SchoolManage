using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Course.Commands.Models
{
    public class UpdateCourseCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
