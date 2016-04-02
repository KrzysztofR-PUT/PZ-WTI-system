using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class Address
    {
        public int AddressID { get; set; }

        public string Street { get; set; }

        [Required]
        public int FlatNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public string Voivodeship { get; set; }
    }
}