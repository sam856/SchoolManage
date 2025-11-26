using SchoolManagement.Data.Entities.Identiy;

namespace SchoolManagment.Services.Abstract
{
    public interface IRegesiterServices
    {
        public Task<string> Register(User user, string password, string role);


    }
}
