
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagment.Core.Feature.Register.Commands.Model;

namespace SchoolManagment.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {


        public void AddUserCommandMap()
        {
            CreateMap<User, AddUserCommand>()
                              .ForMember(dest => dest.Role, opt => opt.Ignore()).ReverseMap();


        }

    }
}
