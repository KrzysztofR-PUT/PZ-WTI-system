using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public enum DegreeOfRelationship
    {
        ojciec, matka, siostra, brat
    }
    public class FamilyMembersIncome
    {
        [Key]
        public string IncomeID { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [DisplayName("Imię")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [DisplayName("Nazwisko")]
        public string lastName { get; set; }

        [DisplayName("Rok urodzenia")]
        public string birthdayYear { get; set; }


        [DisplayName("Stopień pokrewieństwa")]
        public DegreeOfRelationship relationship { get; set; }

        [DisplayName("Dochód opodatkowany")]
        public float taxedIncome { get; set; }


        [DisplayName("Dochód nieopodatkowany")]
        public float untaxedIncome { get; set; }


        [DisplayName("Ogółem")]
        public float total { get; set; }
    }
}

