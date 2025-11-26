using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Department.Queries.Model
{
    public class GetAllDepartmentQuery : IRequest<Response<List<DepartmentDto>>>
    {
    }
}
