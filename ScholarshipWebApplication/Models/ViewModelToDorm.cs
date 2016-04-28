using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScholarshipWebApplication.Models.Database;


namespace ScholarshipWebApplication.Models
{
    public class ViewModelToDorm
    {
        public DormDocumentProps DormDocProps { get; set; }
        public Rooms Rooms { get; set; }

    }
}