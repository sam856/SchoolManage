using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class RefreshTokenRepositiry : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepositiry
    {
        #region Fields
        private DbSet<UserRefreshToken> refreshTokens;
        #endregion

        #region Costractor
        public RefreshTokenRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            refreshTokens = dbContext.Set<UserRefreshToken>();
        }
        #endregion
        #region Handle Function

        #endregion
    }
}