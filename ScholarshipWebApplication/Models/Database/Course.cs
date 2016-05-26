using System.ComponentModel;

namespace ScholarshipWebApplication.Models.Database
{
    public class Course
    {
        public int CourseID { get; set; }
        [DisplayName("Kierunek")]
        public string CourseName { get; set; }
        [DisplayName("Wydział")]
        public string Section { get; set; }
    }
}