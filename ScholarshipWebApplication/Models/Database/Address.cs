using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class Address
    {
      
        [Key]
        public int AddressID { get; set; }

        [DisplayName("Ulica")]
        [Required]
        public string Street { get; set; }

        [DisplayName("Nr mieszkania")]
        [Required]
        public int FlatNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        [Required]
        public string PostCode { get; set; }

        [DisplayName("Miejscowość")]
        [Required]
        public string Place { get; set; }

        [DisplayName("Województwo")]
        [Required]
        public string Voivodeship { get; set; }
    }
}