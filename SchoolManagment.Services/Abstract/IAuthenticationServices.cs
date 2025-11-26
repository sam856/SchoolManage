using SchoolManagement.Data.Entities.Helper;
using SchoolManagement.Data.Entities.Identiy;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolManagment.Services.Abstract
{
    public interface IAuthenticationServices
    {
        public Task<JWTAuthResult> GetJWTToken(User user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> ValidationDetails(JwtSecurityToken JwtToken, string accessToken, string refreshToken);
        public Task<JWTAuthResult> GetRefreshToken(JwtSecurityToken JWTToken, User user, DateTime? ExpiredTime, string accesstoken, string refreshToken);
        public string ValidateToken(string accesstoken);
    }
}
