using MediatR;
using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Teacher.Command.Models
{
    public class MarkAttendenceModel : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public AttendenceStatus Status { get; set; }
    }
}
