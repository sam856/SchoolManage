namespace SchoolManagment.Core.Result
{
    public class GetAssigmentDto
    {
        public int Id { get; set; }
        public int CreatedByTeacherId { get; set; }
        public string CreatedByTeacher { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int ClassId { get; set; }
        public string Class { get; set; }
    }
}
