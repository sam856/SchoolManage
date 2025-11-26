using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class DeActiveClass : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeActiveClass(int Id)
        {
            this.Id = Id;
        }
    }
}
