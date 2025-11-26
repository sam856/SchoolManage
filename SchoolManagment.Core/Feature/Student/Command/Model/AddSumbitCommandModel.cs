using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Student.Command.Model
{
    public class AddSumbitCommandModel : IRequest<Response<string>>
    {

        public int AssignmentId { get; set; }

        public IFormFile FilePath { get; set; }

    }
}
