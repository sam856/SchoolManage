using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Course.Queries.Models;
using SchoolManagment.Core.Result;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Course.Queries.Handler
{
    public class CourseQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCourseQuery, Response<List<CourseDto>>>,
                IRequestHandler<GetCourseByIdQuery, Response<CourseDto>>

    {
        #region feilds
        private readonly ICourseServices courseServices;
        private readonly IMapper mapper;
        #endregion


        #region Constractor
        public CourseQueryHandler(ICourseServices courseServices, IMapper mapper)
        {
            this.courseServices = courseServices;
            this.mapper = mapper;
        }


        #endregion


        #region Handler Function


        public async Task<Response<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var Courses = await courseServices.GetAllAsync();
            var result = mapper.Map<List<CourseDto>>(Courses);
            return Success(result);
        }


        public async Task<Response<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await courseServices.GetByIdAsync(request.Id);
            if (course == null)
            {
                return NotFound<CourseDto>();
            }

            var result = mapper.Map<CourseDto>(course);
            return Success(result);


        }
        #endregion


    }

}