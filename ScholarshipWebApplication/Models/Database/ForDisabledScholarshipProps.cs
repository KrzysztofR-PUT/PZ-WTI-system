using System;
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
        public DisabilityLevel disabilityLevel { get; set; }
        public DateTime decisionStartDate { get; set; }
        public DateTime decisionEndDate { get; set; }
        public bool isDecisionPermanent { get; set; }
    }
}