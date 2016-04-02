using System;
using System.Collections.Generic;
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
        public Level Level { get; set; }
        public string Year { get; set; }
        public Form Form { get; set; }
        public virtual Course course { get; set; }
        public virtual Student student { get; set; }
    }
}