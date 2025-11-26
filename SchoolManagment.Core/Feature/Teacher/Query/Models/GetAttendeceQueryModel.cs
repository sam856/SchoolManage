using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Teacher.Query.Models
{
    public class GetAttendeceQueryModel : IRequest<Response<List<TeacherAttendenceDto>>>
    {
        public int Id { get; set; }
        public GetAttendeceQueryModel(int Id)
        {
            this.Id = Id;
        }
    }
}
