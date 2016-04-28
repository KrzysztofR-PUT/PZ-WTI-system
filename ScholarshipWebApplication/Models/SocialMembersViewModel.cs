using ScholarshipWebApplication.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipWebApplication.Models
{
    public class SocialMembersViewModel
    {
        public SocialScholarshipProps props { get; set; }
        public FamilyMembersIncome income { get; set; }
        public IList<FamilyMembersIncome> incomes { get; set; }
    }
}