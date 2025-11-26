using SchoolManagment.Core.Feature.Teacher.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void UpdateClassMap()
        {
            CreateMap<SchoolManagement.Data.Entities.Class, UpdateClassModel>().ReverseMap();
        }
    }
}
