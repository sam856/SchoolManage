using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Register.Commands.Model;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Register.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>
    {


        #region   Feilds

        private readonly IMapper mapper;
        private readonly IRegesiterServices regesiterServices;

        #endregion


        #region Constractor
        public UserCommandHandler(IMapper mapper, IRegesiterServices regesiterServices)
        {
            this.mapper = mapper;
            this.regesiterServices = regesiterServices;
        }
        #endregion

        #region    Handle Function

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<SchoolManagement.Data.Entities.Identiy.User>(request);
            var result = await regesiterServices.Register(user, request.Password, request.Role);
            if (result == "This email is Exsis")
            {
                return (BadRequest<string>("This Email is Exsist"));
            }
            else if (result != "Success")
            {
                return (BadRequest<string>(result));
            }
            return Created("");


            #endregion

        }
    }
}