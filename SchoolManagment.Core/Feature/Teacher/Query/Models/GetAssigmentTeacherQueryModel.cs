using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Feature.Teacher.Query.Models
{
    public class GetAssigmentTeacherQueryModel : IRequest<Response<AssigmentTeacherDto>>
    {
        public int Id { get; set; }
        public GetAssigmentTeacherQueryModel(int Id)
        {
            this.Id = Id;
        }
    }
}
