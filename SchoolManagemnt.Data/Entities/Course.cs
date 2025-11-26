using SchoolManagement.Data.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Course : ICommon, ICreatedBase
    {
        public DateTime? CreatedAt { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
        public string Code { get; set; }

        public int DepartmentId { get; set; }
        public virtual ICollection<Class> Class { get; set; } = new List<Class>();


    }
}
