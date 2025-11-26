using AutoMapper;

namespace SchoolManagment.Core.Mapping.UserMapping
{
    public partial class UserProfile
    : Profile
    {
        public UserProfile()
        {
            AddUserCommandMap();

        }
    }
}