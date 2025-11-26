namespace SchoolManagement.Data.Entities.Bases
{
    public interface ICommon
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
