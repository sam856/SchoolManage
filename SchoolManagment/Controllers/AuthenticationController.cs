using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Authrntication.Command.Models;

namespace SchoolManagment.Api.Controllers
{

    public class AuthenticationController : AppControllerBase
    {

        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SigInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
