using System;
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
        public DisabilityLevel disabilityLevel { get; set; }
        public DateTime decisionStartDate { get; set; }
        public DateTime decisionEndDate { get; set; }
        public bool isDecisionPermanent { get; set; }
        public DocState docState { get; set; }
        public virtual Student student { get; set; }
    }
}