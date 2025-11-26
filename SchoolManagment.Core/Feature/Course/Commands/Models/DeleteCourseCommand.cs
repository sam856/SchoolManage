using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Course.Commands.Models
{
    public class DeleteCourseCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteCourseCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
