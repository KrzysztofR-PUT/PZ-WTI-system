using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class SocialScholarshipProps
    {
        public enum SocialScholarshipKind
        {
            normalne,
            zwiększone_akademik,
            zwiększone_inne
        }

        [Key]
        public int DocID { get; set; }
        [DisplayName("Rodzaj")]
        public SocialScholarshipKind kind { get; set; }
        [DisplayName("Przychód roczny")]
        public string incomeYear { get; set; } //rok kalendarzowy dochodow
        [DisplayName("Przychód Netto")]
        public float netIncome { get; set; } //dochód netto
        [DisplayName("Dochód utracony")]
        public float lostIncome { get; set; }
        [DisplayName("Dochód uzyskany")]
        public float gainedIncome { get; set; }
        [DisplayName("Dochód rodzinny netto na osobę")]
        public float incomePerPersonPerMonth { get; set; }
        [DisplayName("Odliczenie z tytułu alimentów")]
        public float alimonyCuts { get; set; } //odliczenia z tytułu płacenia alimentów
        public virtual ICollection<FamilyMembersIncome> familyMembersIncome { get; set; }
    }
}
