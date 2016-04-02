using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string RegistryNumber { get; set; } //nr albumu

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public virtual Address address { get; set; }
    }
}