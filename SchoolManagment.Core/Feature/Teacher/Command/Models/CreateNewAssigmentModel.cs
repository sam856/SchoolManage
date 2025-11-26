using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class CreateNewAssigmentModel : IRequest<Response<string>>
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int ClassId { get; set; }
    }
}
