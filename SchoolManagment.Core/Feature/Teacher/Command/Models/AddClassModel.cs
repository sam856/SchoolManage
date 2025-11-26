using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class AddClassModel : IRequest<Response<string>>
    {
        public string Name { get; set; }

        public int CourseId { get; set; }
        public string Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
