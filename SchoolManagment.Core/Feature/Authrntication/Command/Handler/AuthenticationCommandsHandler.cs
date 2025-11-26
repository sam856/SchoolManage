using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Entities.Helper;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Authrntication.Command.Models;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Authrntication.Command.Handler
{
    public class AuthenticationCommandsHandler : ResponseHandler,
        IRequestHandler<SigInCommand, Response<JWTAuthResult>>, IRequestHandler<RefreshTokenCommand, Response<JWTAuthResult>>

    {
        #region Fields
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IAuthenticationServices authenticationServices;



        #endregion

        #region Constractor
        public AuthenticationCommandsHandler(

        UserManager<User> userManager,
        IAuthenticationServices authenticationServices,
             SignInManager<User> signInManager
            )

        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authenticationServices = authenticationServices;
        }


        #endregion

        #region Handler Function
        public async Task<Response<JWTAuthResult>> Handle(SigInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound<JWTAuthResult>();

            }
            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);



            if (!result.Succeeded)
            {
                return BadRequest<JWTAuthResult>("Password or Email is wrong");

            }

            var JwtResult = await authenticationServices.GetJWTToken(user);

            return Success(JwtResult);

        }

        public async Task<Response<JWTAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = authenticationServices.ReadJwtToken(request.AccessToken);
            var validated = await authenticationServices.ValidationDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (validated)
            {
                case ("Invalid Token", null): return Unauthorized<JWTAuthResult>("AlgorithmIsWrong");
                case (" Token not expire ", null): return Unauthorized<JWTAuthResult>("TokenIsNotExpired");
                case ("Refresh Token is Not Valid", null): return Unauthorized<JWTAuthResult>("RefreshTokenIsNotFound");
                case ("Refresh Token is Expire", null): return Unauthorized<JWTAuthResult>("RefreshTokenIsExpired");
            }
            var (userId, expiredate) = validated;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound<JWTAuthResult>();
            var result = await authenticationServices.GetRefreshToken(jwtToken, user, expiredate, request.AccessToken, request.RefreshToken);
            return Success(result);
        }



        #endregion
    }
}