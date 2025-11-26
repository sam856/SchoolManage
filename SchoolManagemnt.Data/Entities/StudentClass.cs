using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;

namespace SchoolManagement.Data.Entities
{
    public class StudentClass : ICommon
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        public User Student { get; set; }
        public Class Class { get; set; }

    }
}
