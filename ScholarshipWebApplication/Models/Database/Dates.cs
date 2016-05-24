using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarshipWebApplication.Models.Database
{
    public enum Document
    {
        kwaterunkowy, rektorski, socjalny, niepelnosprawny
    }

    public class Dates
    {
        [Key]
        public int DateID { get; set; }
        [DisplayName("Nazwa")]
        public string name { get; set; }
        [DisplayName("Typ dokumentu")]
        public Document what { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateTime? startdate { get; set; }
        [DisplayName("Data zakończenia")]
        public DateTime? enddate { get; set; }
        [DisplayName("Czy okres składania dokumentu")]
        public bool? importantdate { get; set; }
        
        [NotMapped]
        public List<Dates> ListDates { get; set; }
    }
}