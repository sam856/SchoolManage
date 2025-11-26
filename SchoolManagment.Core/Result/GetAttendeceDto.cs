namespace SchoolManagment.Core.Result
{
    public class GetAttendeceDto
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public string Status { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public DateTime Date { get; set; }
    }
}
