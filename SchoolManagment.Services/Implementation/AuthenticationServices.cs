using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Data.Entities.Helper;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagment.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagment.Services.Implementation
{
    public class AuthenticationServices : IAuthenticationServices
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private IRefreshTokenRepositiry RefreshTokenRepositiry;
        private UserManager<User> _userManager;
        private ApplicationDbContext dbContext;

        #endregion

        #region Cobnstractor
        public AuthenticationServices(JwtSettings _jwtSettings,
            IRefreshTokenRepositiry RefreshTokenRepositiry,
            UserManager<User> _userManager, ApplicationDbContext dbContext)
        {
            this._jwtSettings = _jwtSettings;
            this.RefreshTokenRepositiry = RefreshTokenRepositiry;
            this._userManager = _userManager;
            this.dbContext = dbContext;
        }
        #endregion

        #region Handel Function

        public async Task<JWTAuthResult> GetJWTToken(User user)
        {
            var (jwtToken, accessToken) = await GetJwtToken(user);
            var refreshtoken = GetRefreshToken(user.UserName);
            var userRefreshToken = new UserRefreshToken
            {
                JWTId = jwtToken.Id,
                UserId = user.Id,
                ExpiredTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                AddedTime = DateTime.Now,
                IsExpired = false,
                IsRevoked = true,
                IsUsed = true,
                RefreshToken = refreshtoken.TokenString,
                Token = accessToken




            };
            await RefreshTokenRepositiry.AddAsync(userRefreshToken);
            var response = new JWTAuthResult();
            response.AccessToken = accessToken;
            response.refreshtoken = refreshtoken;
            return response;

        }
        private async Task<(JwtSecurityToken, string)> GetJwtToken(User user)
        {

            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (jwtToken, accessToken);
        }


        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };
            return refreshToken;
        }
        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
            {

                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
              new Claim(nameof(UserClaimModel.Id), user.Id.ToString())



            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var UserCliams = await _userManager.GetClaimsAsync(user);
            claims.AddRange(UserCliams);
            return claims;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<JWTAuthResult> GetRefreshToken(JwtSecurityToken JWTToken, User user, DateTime? ExpiredTime, string accesstoken, string refreshToken)
        {


            var (jwttoken, newtoken) = await GetJwtToken(user);
            var response = new JWTAuthResult();
            var refreshtokenresult = new RefreshToken();
            refreshtokenresult.UserName = JWTToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshtokenresult.TokenString = refreshToken;
            refreshtokenresult.ExpireAt = (DateTime)ExpiredTime;
            response.AccessToken = accesstoken;
            response.refreshtoken = refreshtokenresult;
            return response;




        }
        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var respose = handler.ReadJwtToken(accessToken);
            return respose;
        }

        public string ValidateToken(string accesstoken)
        {
            var handler = new JwtSecurityTokenHandler();
            var respose = handler.ReadJwtToken(accesstoken);
            var paramenter = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validate = handler.ValidateToken(accesstoken, paramenter, out SecurityToken validatedToken);

                if (validate == null)
                    throw new SecurityTokenArgumentException("Invalid Token");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidationDetails(JwtSecurityToken JWTToken, string accesstoken, string refreshToken)
        {
            if (JWTToken == null || !JWTToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                return ("Invalid Token", null);
            if (JWTToken.ValidTo > DateTime.UtcNow)
                return (" Token not expire ", null);
            var userId = JWTToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            var userrefreshToken = await RefreshTokenRepositiry.GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken
                && x.Token == accesstoken
                && x.UserId == int.Parse(userId));

            if (userrefreshToken == null)
            {
                userrefreshToken.IsRevoked = true;
                userrefreshToken.IsUsed = false;
                await RefreshTokenRepositiry.UpdateAsync(userrefreshToken);
                return ("Refresh Token is Not Valid", null);
            }
            if (userrefreshToken.ExpiredTime < DateTime.UtcNow)

                return ("Refresh Token is Expire", null);


            var expiredate = userrefreshToken.ExpiredTime;

            return (userId, expiredate);
        }

      









        #endregion

    }
}
