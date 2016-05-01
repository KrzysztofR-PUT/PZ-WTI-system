using ScholarshipWebApplication.Models.Database;
using System.Collections.Generic;

namespace ScholarshipWebApplication.Models
{
    public class SocialMembersViewModel
    {
        public SocialScholarshipProps props { get; set; }
        public FamilyMembersIncome income { get; set; }
        public IList<FamilyMembersIncome> incomes { get; set; }
    }
}