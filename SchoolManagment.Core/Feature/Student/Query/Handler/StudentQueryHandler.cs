using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Student.Query.Model;
using SchoolManagment.Core.Result;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Student.Query.Handler
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<VeiwGradesModel, Response<List<GradeDto>>>,
         IRequestHandler<GetAttendenceModel, Response<List<GetAttendeceDto>>>,
        IRequestHandler<GetAssigmentQueryModel, Response<List<GetAssigmentDto>>>,
        IRequestHandler<GetStudentClassQueryModel, Response<List<StudentClassesDto>>>



    {

        #region Fields

        private readonly IMapper _mapper;

        private readonly IStudentServices studentServices;

        #endregion

        #region Constractor
        public StudentQueryHandler(IMapper _mapper, IStudentServices studentServices)
        {
            this._mapper = _mapper;
            this.studentServices = studentServices;
        }
        #endregion

        #region Handle Function

        public async Task<Response<List<GradeDto>>> Handle(VeiwGradesModel request, CancellationToken cancellationToken)
        {
            var grades = await studentServices.GetGradesByStudentId();
            var gradesDto = _mapper.Map<List<GradeDto>>(grades);
            return Success(gradesDto);
        }

        public async Task<Response<List<GetAttendeceDto>>> Handle(GetAttendenceModel request, CancellationToken cancellationToken)
        {
            var attendaence = await studentServices.GetAttendenceByStudentId();
            var attendenceDto = _mapper.Map<List<GetAttendeceDto>>(attendaence);
            return Success(attendenceDto);


        }

        public async Task<Response<List<GetAssigmentDto>>> Handle(GetAssigmentQueryModel request, CancellationToken cancellationToken)
        {
            var assigment = await studentServices.GetStudentAssignmentsByStudentId();
            var assigmentDo = _mapper.Map<List<GetAssigmentDto>>(assigment);
            return Success(assigmentDo);

        }

        public async Task<Response<List<StudentClassesDto>>> Handle(GetStudentClassQueryModel request, CancellationToken cancellationToken)
        {
            var stuentClasses = await studentServices.GetClassBystudentId();
            var studentClassDto = _mapper.Map<List<StudentClassesDto>>(stuentClasses);
            return (Success(studentClassDto));

        }
        #endregion
    }
}
