using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Student.Command.Model;
using SchoolManagment.Core.Feature.Student.Query.Model;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = "Student")]

    public class StudentController : AppControllerBase
    {
        [HttpGet(Router.Student.Attendence)]
        public async Task<IActionResult> GetAllAttandence()
        {
            var response = await Mediator.Send(new GetAttendenceModel());
            return NewResult(response);
        }

        [HttpGet(Router.Student.GetGrade)]
        public async Task<IActionResult> GetGrades()
        {
            var response = await Mediator.Send(new VeiwGradesModel());
            return NewResult(response);
        }


        [HttpGet(Router.Student.VeiwAssigment)]
        public async Task<IActionResult> GetAssigment()
        {
            var response = await Mediator.Send(new GetAssigmentQueryModel());
            return NewResult(response);
        }

        [HttpPost(Router.Student.SumbitAssigment)]
        public async Task<IActionResult> Sumbit([FromForm] AddSumbitCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(Router.Student.GetClasses)]
        public async Task<IActionResult> Classes()
        {
            var response = await Mediator.Send(new GetStudentClassQueryModel());
            return NewResult(response);
        }
    }
}


