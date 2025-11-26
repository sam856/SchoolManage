using SchoolManagement.Data.Entities.Bases;

using SchoolManagement.Data.Entities.Identiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Submission : ICommon
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? GradeByTeacherId { get; set; }
        [ForeignKey("GradeByTeacherId")]
        public User? GradeByTeacher { get; set; }
        public string? Grade { get; set; }
        public string? Remarks { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }
        public string FileUrl { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }

    }
}
