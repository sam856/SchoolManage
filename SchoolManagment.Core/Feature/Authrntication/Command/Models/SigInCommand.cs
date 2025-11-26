using MediatR;
using SchoolManagement.Data.Entities.Helper;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Authrntication.Command.Models
{
    public class SigInCommand : IRequest<Response<JWTAuthResult>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}