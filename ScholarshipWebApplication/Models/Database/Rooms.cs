using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class Rooms
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        [Required]
        public int roomSpace { get; set; }
        [Required]
        public int currentLodgersNumber { get; set; }
        [Required]
        public int floorNumber { get; set; }
        [Required]
        public int isAvailable { get; set; }
    }
}