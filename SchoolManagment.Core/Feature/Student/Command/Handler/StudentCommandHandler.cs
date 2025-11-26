using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Student.Command.Model;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Student.Command.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddSumbitCommandModel, Response<string>>
    {


        #region Fields
        private readonly IMapper _mapper;
        private readonly IStudentServices _IStudentServices;
        #endregion



        #region Constractor
        public StudentCommandHandler(IMapper mapper, IStudentServices studentServices)
        {
            _IStudentServices = studentServices;
            _mapper = mapper;
        }
        #endregion



        #region Handle Function 
        public async Task<Response<string>> Handle(AddSumbitCommandModel request, CancellationToken cancellationToken)
        {
            var submission = _mapper.Map<SchoolManagement.Data.Entities.Submission>(request);
            var result = await _IStudentServices.SubmitAssignment(submission, request.FilePath);
            switch (result)
            {
                case "Submission Successful":
                    return Success("Submitted Successfully");
                case "Canot  Upload File":
                    return BadRequest<string>("There was an error with the file submission.");
                case "no file uploaded":
                    return BadRequest<string>("The specified assignment was not found.");
                default:
                    return BadRequest<string>("An unexpected error occurred during submission.");
            }
        }
        #endregion

    }
}
