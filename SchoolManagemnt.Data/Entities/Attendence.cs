using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Attendence : ICommon, ICreatedBase
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public AttendenceStatus Status { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        public int MarkedbyTeacherId { get; set; }
        [ForeignKey("MarkedbyTeacherId")]
        public User teacher { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }

    }

    public enum AttendenceStatus
    {
        Present,
        Absent,
        Late
    }
}
