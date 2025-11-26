using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class PostGradeModel : IRequest<Response<string>>
    {
        public string Grade { get; set; }
        public string Remarks { get; set; }

        public int StudentId { get; set; }

        public int AssignmentId { get; set; }
    }
}
