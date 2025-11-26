using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class UpdateClassModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Semester { get; set; }
        public int CourseId { get; set; }
    }
}
