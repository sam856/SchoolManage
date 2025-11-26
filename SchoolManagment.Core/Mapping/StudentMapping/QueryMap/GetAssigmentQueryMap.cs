using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {

        public void GetAssigment()
        {

            CreateMap<GetAssigmentDto, Assignment>()

            .ForPath(src => src.CreatedByTeacher.FullName, opt => opt.MapFrom(dest => dest.CreatedByTeacher))

            .ForPath(src => src.Class.Name, opt => opt.MapFrom(dest => dest.Class)).ReverseMap();
        }
    }
}
