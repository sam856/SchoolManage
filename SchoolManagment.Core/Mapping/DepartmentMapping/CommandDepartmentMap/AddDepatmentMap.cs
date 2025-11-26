using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Feature.Department.Command.Model;
using SchoolManagment.Core.Result;


namespace SchoolManagment.Core.DepartmentMapping
{
    public partial class DepartmentProfile
    {

        public void AddDepatmentMap()
        {
            CreateMap<DepartmentDto, Department>().ForPath(dest => dest.HeadOfDepartment.FullName, opt => opt.MapFrom(src => src.HeadOfDepartmentBName)).ReverseMap();



            CreateMap<AddDepartmentCommand, Department>().ReverseMap();
        }
    }
}
