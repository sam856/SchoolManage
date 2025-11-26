using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Department.Command.Model
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {

        public int Id { get; set; }
        public DeleteDepartmentCommand(int Id)
        {
            this.Id = Id;
        }

    }
}
