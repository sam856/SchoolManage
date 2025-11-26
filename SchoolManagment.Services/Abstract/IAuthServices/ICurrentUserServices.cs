using SchoolManagement.Data.Entities.Identiy;

namespace SchoolManagment.Services.Abstract.AuthServices
{
    public interface ICurrentUserServices
    {
        public int GetUserId();
        public Task<User> GetUser();
    }
}
