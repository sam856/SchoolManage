using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Feature.Department.Command.Model;
using SchoolManagment.Core.Result;
namespace SchoolManagment.Core.DepartmentMapping
{
    public partial class DepartmentProfile
    {

        public void UpdateDepartmentMap()
        {



            CreateMap<UpdateDepartmentCommand, Department>().ReverseMap();


            CreateMap<UpdateDepartmentCommand, DepartmentDto>().ReverseMap();

        }
    }
}