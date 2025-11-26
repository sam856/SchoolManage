using MediatR;
using SchoolManagement.Data.Entities.Helper;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Authrntication.Command.Models
{
    public class RefreshTokenCommand : IRequest<Response<JWTAuthResult>>
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}