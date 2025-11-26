using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Class : ICreatedBase, ICommon
    {
        public DateTime? CreatedAt { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        [ForeignKey(nameof(CourseId))]

        public Course Course { get; set; }
        public int CourseId { get; set; }

        public bool IsActive { get; set; } = true;
        public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User Teacher { get; set; }
        public string Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
