using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ScholarshipWebApplication.Models.Database
{
    public enum Level
    {
        pierwszy, drugi
    }

    public enum Form
    {
        stacjonarne, niestacjonarne
    }

    public class Studies
    {
        public int StudiesID { get; set; }
        [DisplayName("Stopień")]
        public Level Level { get; set; }
        [DisplayName("Rok")]
        public string Year { get; set; }
        [DisplayName("Forma Studiów")]
        public Form Form { get; set; }
        public virtual Course course { get; set; }
        public virtual Student student { get; set; }
    }
}

