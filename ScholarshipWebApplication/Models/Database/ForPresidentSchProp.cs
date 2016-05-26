using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarshipWebApplication.Models.Database
{
    public class ForPresidentSchProp
    {
        [Key]
        public int DocID { get; set; }
        [DisplayName("Średnia")]
        public int average { get; set; }   //Średnia ważona ocen uzyskanych w poprzednim roku studiów (dwa ostatnie semestry studiów), niemniejsza niż 4,0 pomnożona przez 10

        public int? activity_researchCircle { get; set; }    //aktywność w kole naukowym

        public int? superventions { get; set; }  //wystapienia seminaryjne

        public int? polishMagazines_publ { get; set; }  //publikacje w polskich czasowpismach

        public int? externalMagazines_publ { get; set; }  //publikacje w zagranicznych czasopismach
        public int? LFMagazines_publ { get; set; }  //publikacje prac w czasopismach z listy filadelfijskiej

        public int? polishSportCompetition { get; set; }  //a)	Indywidualne/ drużynowe mistrzostwa Polski/ akademickie mistrzostwa Polski (0-15) pkt.

        public int? europeanSportCompetition { get; set; }  //b)	Indywidualne/ drużynowe mistrzostwa Europy/  akademickie mistrzostwa Europy (11-30) pkt

        public int? worldcup { get; set; }  //c)	Indywidualne/ drużynowe mistrzostwa świata/ Uniwersjada (25-50) pkt.

        public int? artAchievements { get; set; }  //Osiągnięcia na polu artystycznym (0-15) pkt.

        public int? anotherAchievements { get; set; }  //Inne potwierdzone osiągnięcia (0-5) pkt.

    }
}