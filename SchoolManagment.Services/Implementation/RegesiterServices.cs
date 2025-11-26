using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Services.Implementation
{
    public class RegesiterServices : IRegesiterServices
    {

        #region Fields
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<Role> _roleManager;
        #endregion

        #region Constractor
        public RegesiterServices(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        #endregion


        #region Handle Function 

        public async Task<string> Register(User user, string password, string role)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
                return "This email is Exsist";

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return $"Failed: {errors}";
            }
            var roleResult = await _userManager.AddToRoleAsync(user, role);
            return "Success";

        }


        #endregion

    }
}
