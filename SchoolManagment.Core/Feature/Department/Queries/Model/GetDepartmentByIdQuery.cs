using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Department.Queries.Model
{
    public class GetDepartmentByIdQuery : IRequest<Response<DepartmentDto>>
    {

        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
