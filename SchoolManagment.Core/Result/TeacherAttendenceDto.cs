namespace SchoolManagment.Core.Result
{
    public class TeacherAttendenceDto
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public string Status { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public DateTime Date { get; set; }
    }
}
