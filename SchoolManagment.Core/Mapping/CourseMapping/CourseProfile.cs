using AutoMapper;

namespace SchoolManagment.Core.Mapping.CourseMapping
{
    public partial class CourseProfile : Profile
    {

        public CourseProfile()
        {
            AddCourseMapping();
            UpdateCourseCommandMap();
        }
    }
}
