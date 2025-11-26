using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Register.Commands.Model
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
