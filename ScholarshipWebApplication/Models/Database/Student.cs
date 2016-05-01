using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class Student
    {
       
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Nazwisko jest wymagane")]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Nr Albumu")]
        [StringLength(6,ErrorMessage ="Nr albumu ma 6 Cyfr !")]       
        public string RegistryNumber { get; set; }
        [DataType(DataType.PhoneNumber,ErrorMessage ="Popraw Nr Telefonu")]
        [DisplayName("Tel.")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Niepoprawny email. Poprawny: jozek@gmail.com")]
        [DisplayName("e-mail")]
        public string Email { get; set; }

        public virtual Address address { get; set; }
        public virtual IList<Studies> studies { get; set; }
    }
}