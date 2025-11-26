namespace SchoolManagment.Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {

        public void UpdateCourseCommandMap()
        {
            CreateMap<SchoolManagment.Core.Feature.Course.Commands.Models.UpdateCourseCommand, SchoolManagement.Data.Entities.Course>()
                .ReverseMap();
        }
    }
}
