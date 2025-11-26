

using AutoMapper;
using MediatR;
using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Teacher.Command.Models;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Teacher.Command.Handler

{

    public class TeacherHandlerCommand : ResponseHandler, IRequestHandler<AddClassModel, Response<string>>,
        IRequestHandler<UpdateClassModel, Response<string>>,
         IRequestHandler<DeActiveClass, Response<string>>,
            IRequestHandler<PostGradeModel, Response<string>>,
            IRequestHandler<MarkAttendenceModel, Response<string>>,
            IRequestHandler<AssignStudentToClsCommandModel, Response<string>>,
             IRequestHandler<CreateNewAssigmentModel, Response<string>>



    {
        #region Feilds
        private readonly ITeacherSevice TeacherServices;

        private readonly IMapper mapper;
        #endregion




        #region Constractor
        public TeacherHandlerCommand(ITeacherSevice teacherServices, IMapper mapper)
        {
            TeacherServices = teacherServices;
            this.mapper = mapper;
        }


        #endregion



        public async Task<Response<string>> Handle(AddClassModel request, CancellationToken cancellationToken)
        {
            var Class = mapper.Map<SchoolManagement.Data.Entities.Class>(request);
            var result = await TeacherServices.CreateClass(Class);
            if (result != "Class created successfully.")
            {
                return BadRequest<string>();
            }
            else
            {
                return Created("");
            }
        }

        public async Task<Response<string>> Handle(UpdateClassModel request, CancellationToken cancellationToken)
        {
            var Class = mapper.Map<SchoolManagement.Data.Entities.Class>(request);

            var result = await TeacherServices.UpdateCls(Class);

            switch (result)
            {

                case "Unauthorized":
                    return Unauthorized<string>("You do not have permission to update this class.");
                case "Class updated successfully.":
                    return Success("Class updated successfully.");
                default:
                    return BadRequest<string>("Failed to update class.");
            }

        }

        public async Task<Response<string>> Handle(DeActiveClass request, CancellationToken cancellationToken)
        {
            var result = await TeacherServices.DeActiveCls(request.Id);
            switch (result)
            {
                case "Unauthorized":
                    return Unauthorized<string>("You do not have permission to update this class.");
                case "Class deactivated successfully.":
                    return Success("Class deactivated successfully.");
                case "Class not found.":
                    return NotFound<string>("Class not found.");
                default:
                    return BadRequest<string>("Failed to deactivate class.");

            }
        }

        public async Task<Response<string>> Handle(PostGradeModel request, CancellationToken cancellationToken)
        {
            var grade = mapper.Map<Submission>(request);
            var result = await TeacherServices.PosTGrade(grade);
            switch (result)
            {
                case "Unauthorized":
                    return Unauthorized<string>("You do not have permission to update this class.");
                case "Submission not found.":
                    return NotFound<string>("Submission not found.");
                case "Grade posted successfully.":
                    return Success("Grade posted successfully.");
                default:
                    return BadRequest<string>("Failed to post grade.");


            }
        }

        public async Task<Response<string>> Handle(MarkAttendenceModel request, CancellationToken cancellationToken)
        {
            var attendence = mapper.Map<Attendence>(request);
            var result = await TeacherServices.AddAttendence(attendence);
            switch (result)
            {
                case "Unauthorized":
                    return Unauthorized<string>("You do not have permission to update this class.");

                case "Failed to add attendence.":
                    return BadRequest<string>("Failed to add attendence.");
                case "Attendence added successfully.":
                    return Created("");
                default:
                    return BadRequest<string>("SomeThing wrong");

            }



        }

        public async Task<Response<string>> Handle(AssignStudentToClsCommandModel request, CancellationToken cancellationToken)
        {
            var assigment = mapper.Map<StudentClass>(request);
            var result = await TeacherServices.AssignStudentTocls(assigment);
            switch (result)
            {

                case "Unauthorized":
                    return Unauthorized<string>("You do not have permission to update this class.");
                case "Student is already assigned to this class.":
                    return BadRequest<string>("Student is already assigned to this class.");
                case "Student assigned to class successfully.":
                    return Created("");
                default:
                    return BadRequest<string>("SomeThing wrong");
            }
        }

        public async Task<Response<string>> Handle(CreateNewAssigmentModel request, CancellationToken cancellationToken)
        {
            var assigment = mapper.Map<Assignment>(request);
            var result = await TeacherServices.AddAssigment(assigment);
            switch (result)
            {
                case "Unauthorized":
                    return (Unauthorized<string>("You do not have permission to update this class."));
                case "Failed to add assignment.":
                    return (BadRequest<string>("Failed to add assignment."));
                case "Assignment added successfully.":
                    return (Created(""));
                default:
                    return (BadRequest<string>("SomeThing wrong"));
            }


        }
    }
}

