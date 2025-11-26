using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Authrntication.Queries.Model;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Authrntication.Queries.Handler
{
    public class AuthenticationQuriesHandler : ResponseHandler,
        IRequestHandler<AuroizeQuery, Response<string>>
    {

        #region Fields
        private readonly IAuthenticationServices authenticationServices;
        #endregion

        #region Constractor
        public AuthenticationQuriesHandler(
                         IAuthenticationServices authenticationServices


              )

        {
            this.authenticationServices = authenticationServices;
        }

        #endregion

        #region Handel Function
        public async Task<Response<string>> Handle(AuroizeQuery request, CancellationToken cancellationToken)
        {
            var result = authenticationServices.ValidateToken(request.AccessToken);
            if (result == "Success")

                return Success(result);
            else
                return BadRequest<string>("Expire");

        }


        #endregion
    }
}