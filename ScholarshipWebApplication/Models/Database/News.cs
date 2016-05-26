using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }


        [DisplayName("Tytuł")]
        [Required]
        public string Title { get; set; }


        [DisplayName("Treść")]
        [Required]
        public string Content { get; set; }


        [DisplayName("Data")]
        [Required]
        public DateTime PostDate { get; set; }


        [DisplayName("Autor")]
        [Required]
        public string Author { get; set; }
    }
}