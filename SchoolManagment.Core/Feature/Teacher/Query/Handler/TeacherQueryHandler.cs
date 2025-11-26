using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Teacher.Query.Models;
using SchoolManagment.Core.Result;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Teacher.Query.Handler
{
    public class TeacherQueryHandler : ResponseHandler, IRequestHandler<GetAssigmentTeacherQueryModel, Response<AssigmentTeacherDto>>
        , IRequestHandler<GetAttendeceQueryModel, Response<List<TeacherAttendenceDto>>>
    {
        #region Feilds
        private readonly ITeacherSevice TeacherServices;
        private readonly IMapper mapper;
        #endregion
        #region Constractor
        public TeacherQueryHandler(ITeacherSevice teacherServices, IMapper mapper)
        {
            TeacherServices = teacherServices;
            this.mapper = mapper;
        }
        #endregion

        public async Task<Response<AssigmentTeacherDto>> Handle(GetAssigmentTeacherQueryModel request, CancellationToken cancellationToken)
        {
            var result = await TeacherServices.GetAssigmentByClassId(request.Id);
            if (result == null)
            {
                return Unauthorized<AssigmentTeacherDto>("You do not have permission to update this class.");
            }
            return Success(mapper.Map<AssigmentTeacherDto>(result));
        }

        public async Task<Response<List<TeacherAttendenceDto>>> Handle(GetAttendeceQueryModel request, CancellationToken cancellationToken)
        {

            var result = TeacherServices.GetAttendenceByClassId(request.Id);
            if (result == null)
            {
                return (Unauthorized<List<TeacherAttendenceDto>>("You do not have permission to view this attendance."));
            }
            return (Success(mapper.Map<List<TeacherAttendenceDto>>(result)));
        }
    }
}
