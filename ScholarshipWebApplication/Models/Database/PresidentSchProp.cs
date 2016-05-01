using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScholarshipWebApplication.Models.Database
{
    public class PresidentSchProp
    {
        [Key]
        public int DocID { get; set; }

        public virtual Student student { get; set; }

        public virtual ForPresidentSchProp table { get; set; }
        [DisplayName("Status dokumentu")]
        public DocState docState { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_statute { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_bankAccount { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_dataAgreement { get; set; }

    }
}