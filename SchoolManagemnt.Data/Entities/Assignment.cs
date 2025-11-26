using SchoolManagement.Data.CustomArttibute;
using SchoolManagement.Data.Entities.Bases;
using SchoolManagement.Data.Entities.Identiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Assignment : ICommon
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedByTeacherId { get; set; }
        [ForeignKey("CreatedByTeacherId")]
        public User CreatedByTeacher { get; set; }

        public string Description { get; set; }
        [FutureDate(ErrorMessage = "date cannot be in the past.")]
        public DateTime DueDate { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }

    }
}
