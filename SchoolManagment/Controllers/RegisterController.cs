using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Register.Commands.Model;

namespace SchoolManagment.Api.Controllers
{
    public class RegisterController : AppControllerBase
    {

        [HttpPost(Router.User.Add)]
        public async Task<IActionResult> Create([FromForm] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
