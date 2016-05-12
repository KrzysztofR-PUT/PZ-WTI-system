using System.ComponentModel;
using System.Data.Entity;

namespace ScholarshipWebApplication.Models.Database
{
    public enum DocState
    {
        [Description("Zwrócony")]
        returned,
        [Description("Wysłany")]
        sended,
        [Description("Zaakceptowany")]
        accepted,
        [Description("Odrzucony")]
        rejected
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
        public DbSet<PresidentSchProp> PresidentSchProp { get; set; }
        public DbSet<ForPresidentSchProp> ForPresidentSchProp { get; set; }
        public DbSet<Dates> Dates { get; set; }

    }
}