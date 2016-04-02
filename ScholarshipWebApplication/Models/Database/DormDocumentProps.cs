using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class DormDocumentProps
    {
        [Key]
        public int DocID { get; set; }
        public int DistanceFromHome { get; set; }
        public string TransportDifficulties { get; set; }
        public int FamilyCount { get; set; }
        public float IncomePerPerson { get; set; }
        public bool IsDisabled { get; set; }
        public bool isFullFamily { get; set; }
        public string CurrentAcademicYear { get; set; }
        public virtual Student student { get; set; }
    }
}