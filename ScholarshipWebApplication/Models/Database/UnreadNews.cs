using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class UnreadNews
    {
        [Key]
        public int UnreadID { get; set; }
        public virtual Student StudentId { get; set; }
        public virtual News NewsId { get; set; }
    }
}