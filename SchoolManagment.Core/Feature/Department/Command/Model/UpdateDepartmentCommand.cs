using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Department.Command.Model
{
    public class UpdateDepartmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadOfDepartmentId { get; set; }
    }
}
