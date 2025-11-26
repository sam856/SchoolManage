using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Entities.Helper;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagment.Services.Abstract.AuthServices;

namespace SchoolManagment.Services.Implementation.AuthServices
{
    public class CurrentUserServices : ICurrentUserServices
    {
        #region Fields
        private IHttpContextAccessor _contextAccessor;
        private UserManager<User> _userManager;
        #endregion


        #region Constractor
        public CurrentUserServices(IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;

        }


        #endregion

        #region Function 
        public int GetUserId()
        {
            var UserId = _contextAccessor.HttpContext.User.Claims.SingleOrDefault(cliam => cliam.Type == (nameof(UserClaimModel.Id))).Value;
            if (UserId == null)
                throw new UnauthorizedAccessException();
            return int.Parse(UserId);
        }
        public async Task<User> GetUser()
        {

            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UnauthorizedAccessException();
            return user;
        }




        #endregion
    }
}