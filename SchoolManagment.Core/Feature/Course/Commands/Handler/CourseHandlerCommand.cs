using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Course.Commands.Models;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Course.Commands.Handler
{
    public class CourseHandlerCommand : ResponseHandler,
        IRequestHandler<AddCourseCommand, Response<string>>,
       IRequestHandler<UpdateCourseCommand, Response<string>>,
        IRequestHandler<DeleteCourseCommand, Response<string>>


    {




        #region   Feilds
        private readonly ICourseServices courseServices;
        private readonly IMapper mapper;

        #endregion

        #region Constractor 
        public CourseHandlerCommand(ICourseServices courseServices, IMapper mapper)
        {


            this.courseServices = courseServices;
            this.mapper = mapper;
        }


        #endregion

        #region Handle Function 


        public async Task<Response<string>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = mapper.Map<SchoolManagement.Data.Entities.Course>(request);
            var result = await courseServices.AddAsync(course);
            if (result != "Added Successfully")
            {
                return BadRequest<string>();
            }
            else
            {

                return Created("");


            }
        }

        public async Task<Response<string>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = mapper.Map<SchoolManagement.Data.Entities.Course>(request);



            var result = await courseServices.UpdateAsync(course);
            if (result != "Updated Successfully")
            {
                return (BadRequest<string>());
            }
            else
            {
                return Success("Updated Successfully");
            }
        }


        public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await courseServices.DeleteAsync(request.Id);
            if (result != "Success")
            {
                return (BadRequest<string>());
            }
            else
            {
                return (Success("Deleted Successfully"));
            }
        }
        #endregion



    }
}
