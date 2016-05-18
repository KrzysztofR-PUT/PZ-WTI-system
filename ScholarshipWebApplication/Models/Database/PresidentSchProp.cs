﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class PresidentSchProp : StatefulDoc
    {
        public virtual Student student { get; set; }

        public virtual ForPresidentSchProp table { get; set; }

        [DisplayName("Numer konta")]
        public string bankAccountNmb { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_statute { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_bankAccount { get; set; }

        [RegularExpression("True", ErrorMessage = "Musisz zaakceptować to pole")]
        public bool statement_dataAgreement { get; set; }

    }
}