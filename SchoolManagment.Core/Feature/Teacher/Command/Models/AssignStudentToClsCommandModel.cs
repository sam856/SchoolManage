using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class AssignStudentToClsCommandModel : IRequest<Response<string>>
    {

        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
