using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class DormDocumentProps
    {
        [Key]
        public int DocID { get; set; }

        [DisplayName("Dystans od domu")]
        public int DistanceFromHome { get; set; }
        [DisplayName("Trudności dojazdu")]
        public string TransportDifficulties { get; set; }
        [DisplayName("Liczba członków rodziny")]
        public int FamilyCount { get; set; }
        [DisplayName("Przychód na osobę")]
        public float IncomePerPerson { get; set; }
        [DisplayName("Czy student jest niepełnosprawny?")]
        public bool IsDisabled { get; set; }
        [DisplayName("Czy student jest z rodziny niepełnej?")]
        public bool isFullFamily { get; set; }
        [DisplayName("Rok studiów")]
        public string CurrentAcademicYear { get; set; }
        [DisplayName("Numer konta")]
        public string bankAccountNmb { get; set; }
        public DocState docState { get; set; }
        public virtual Student student { get; set; }
    }
}