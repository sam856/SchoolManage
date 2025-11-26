using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Department.Command.Model;
using SchoolManagment.Core.Feature.Department.Queries.Model;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.Departmwent.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllDepartmentQuery());
            return NewResult(response);
        }

        [HttpGet(Router.Departmwent.GetById)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(response);
        }


        [HttpPut(Router.Departmwent.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteDepartmentCommand(Id));
            return NewResult(response);
        }

        [HttpPut(Router.Departmwent.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand UpdateDepartmentCommand)
        {
            var response = await Mediator.Send(UpdateDepartmentCommand);
            return NewResult(response);
        }


        [HttpPost(Router.Departmwent.Add)]
        public async Task<IActionResult> Add([FromBody] AddDepartmentCommand add)
        {
            var response = await Mediator.Send(add);
            return NewResult(response);
        }
    }
}
