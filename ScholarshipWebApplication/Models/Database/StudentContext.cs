using System.Data.Entity;

namespace ScholarshipWebApplication.Models.Database
{
    public enum DocState
    {
        returned, sended, accepted, rejected
    }
    public class StudentContext : DbContext
    {
        public DbSet<DormDocumentProps> DocumentProperties { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Studies> Studies { get; set; }
        public DbSet<SocialScholarshipProps> SocialProperties { get; set; }
        public DbSet<ForDisabledScholarshipProps> ForDisabledProperties { get; set; }
        public DbSet<Rooms> Room { get; set; }
    }
}