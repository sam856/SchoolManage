using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Feature.Student.Command.Model;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddSummssionCommandMap()
        {
            CreateMap<Submission, AddSumbitCommandModel>().ForMember(dest => dest.FilePath, opt => opt.Ignore()).ReverseMap();

        }
    }
}
