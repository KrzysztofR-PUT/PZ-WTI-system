using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class StatefulDoc
    {
        [Key]
        public int DocID { get; set; }
        [DisplayName("Status dokumentu")]
        public DocState docState { get; set; }
    }
}