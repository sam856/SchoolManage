using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Course.Commands.Models;
using SchoolManagment.Core.Feature.Course.Queries.Models;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CourseController : AppControllerBase
    {
        [HttpGet(Router.Course.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllCourseQuery());
            return Ok(response);
        }

        [HttpGet(Router.Course.GetById)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var response = await Mediator.Send(new GetCourseByIdQuery(id));
            return Ok(response);
        }


        [HttpPut(Router.Course.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteCourseCommand(Id));
            return NewResult(response);
        }

        [HttpPut(Router.Course.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
        {
            var response = await Mediator.Send(updateCourseCommand);
            return NewResult(response);
        }


        [HttpPost(Router.Course.Add)]
        public async Task<IActionResult> Add([FromBody] AddCourseCommand add)
        {
            var response = await Mediator.Send(add);
            return NewResult(response);
        }
    }
}