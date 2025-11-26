using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GradeMapping()
        {
            CreateMap<GradeDto, Submission>().ForPath(dest => dest.GradeByTeacher.FullName, opt => opt.MapFrom(src => src.GradeByTeacher)).ReverseMap();
            CreateMap<GradeDto, Submission>().ForPath(dest => dest.Assignment.Description, opt => opt.MapFrom(src => src.Assignment)).ReverseMap();


        }
    }
}
