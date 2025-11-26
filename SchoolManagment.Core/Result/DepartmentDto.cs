namespace SchoolManagment.Core.Result
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadOfDepartmentId { get; set; }
        public string HeadOfDepartmentBName { get; set; }

    }
}
