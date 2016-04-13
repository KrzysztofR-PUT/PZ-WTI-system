using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class ForDisabledScholarshipProps
    {
        public enum DisabilityLevel
        {
            lekki, umiarkowany, znaczny
        }
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
    }
}
