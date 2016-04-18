using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public enum SocialScholarshipKind
    {
        normalne,
        zwiększone_akademik,
        zwiększone_inne
    }
    public class SocialScholarshipProps
    {
        [Key]
        public int DocID { get; set; }
        public SocialScholarshipKind kind { get; set; }
        public string incomeYear { get; set; } //rok kalendarzowy dochodow
        public float netIncome { get; set; } //dochód netto
        public float lostIncome { get; set; }
        public float gainedIncome { get; set; }
        public float incomePerPersonPerMonth { get; set; }
        public float alimonyCuts { get; set; } //odliczenia z tytułu płacenia alimentów
        public string bankAccountNmb { get; set; }
        public DocState docState { get; set; }
        public virtual Student student { get; set; }
        public virtual ICollection<FamilyMembersIncome> familyMembersIncome { get; set; }
    }
}