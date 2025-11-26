using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void GetAssigmentQueryMap()
        {
            CreateMap<AssigmentTeacherDto, SchoolManagement.Data.Entities.Assignment>()


                .ReverseMap();
        }
    }
}
