using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Department : IUpdatedBase, ICreatedBase, ICommon
    {

        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(HeadOfDepartmentId))]
        public User HeadOfDepartment { get; set; }

        public int HeadOfDepartmentId { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}
