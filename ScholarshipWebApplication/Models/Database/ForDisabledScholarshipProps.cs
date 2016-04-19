using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public enum DisabilityLevel
    {
        lekki, umiarkowany, znaczny
    }
    public class ForDisabledScholarshipProps
    {
        [Key]
        public int DocID { get; set; }
        [DisplayName("Stopień Niepełnosprawności")]
        public DisabilityLevel disabilityLevel { get; set; }
        [DisplayName("Ważne od")]
        public DateTime decisionStartDate { get; set; }
        [DisplayName("do")]
        public DateTime decisionEndDate { get; set; }
        [DisplayName("Czy decyzja jest stała")]
        public bool isDecisionPermanent { get; set; }
        public DocState docState { get; set; }
        public virtual Student student { get; set; }
    }
}
