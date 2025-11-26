using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.AppMetaDate;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Feature.Teacher.Command.Models;
using SchoolManagment.Core.Feature.Teacher.Query.Models;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = "Teacher")]

    public class TeacherController : AppControllerBase
    {
        [HttpPost(Router.Teacher.AddAssigment)]
        public async Task<IActionResult> Add([FromBody] CreateNewAssigmentModel model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }

        [HttpPost(Router.Teacher.PostGrade)]
        public async Task<IActionResult> GetGrades([FromBody] PostGradeModel model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }


        [HttpGet(Router.Teacher.GetAssigmentById)]
        public async Task<IActionResult> GetAssigment([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetAssigmentTeacherQueryModel(Id));
            return NewResult(response);
        }

        [HttpPost(Router.Teacher.MarkAttendence)]
        public async Task<IActionResult> MarkAttendence([FromBody] MarkAttendenceModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(Router.Teacher.GetAttendenceByClassId)]
        public async Task<IActionResult> Classes([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAttendeceQueryModel(id));
            return NewResult(response);
        }





        [HttpPost(Router.Teacher.AddClass)]
        public async Task<IActionResult> AddClass([FromBody] AddClassModel id)
        {
            var response = await Mediator.Send((id));
            return NewResult(response);
        }




        [HttpPut(Router.Teacher.UpdateClass)]
        public async Task<IActionResult> Classes([FromBody] UpdateClassModel model)
        {
            var response = await Mediator.Send((model));
            return NewResult(response);
        }




        [HttpPost(Router.Teacher.AssignStudent)]
        public async Task<IActionResult> AssignStudent([FromBody] AssignStudentToClsCommandModel model)
        {
            var response = await Mediator.Send((model));
            return NewResult(response);
        }



        [HttpPost(Router.Teacher.DeActiveClass)]
        public async Task<IActionResult> AssignStudent([FromRoute] int Id)
        {
            var response = await Mediator.Send((new DeActiveClass(Id)));
            return NewResult(response);
        }
    }
}

