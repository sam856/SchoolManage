using AutoMapper;

namespace SchoolManagment.Core.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            AddDepatmentMap();
            UpdateDepartmentMap();
        }

    }
}
