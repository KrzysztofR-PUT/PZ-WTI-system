using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScholarshipWebApplication.Models.Database
{
    public enum Document
    {
        kwaterunkowy, rektorski, socjalny, niepelnosprawny    // :P
    }

    public class Dates
    {
        [Key]
        public int DateID { get; set; }
      
        
        public string name { get; set; }

        public Document what { get; set; }

        public DateTime? startdate { get; set; }

        public DateTime? enddate { get; set; }

        public bool? importantdate { get; set; }


        [NotMapped]
       public List<Dates> ListDates { get; set; }
    }
}