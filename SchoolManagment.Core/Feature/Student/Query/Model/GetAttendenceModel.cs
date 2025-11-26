using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Student.Query.Model
{
    public class GetAttendenceModel : IRequest<Response<List<GetAttendeceDto>>>
    {
    }
}
