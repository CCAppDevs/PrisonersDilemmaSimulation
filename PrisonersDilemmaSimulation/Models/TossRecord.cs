using System.ComponentModel.DataAnnotations;

namespace PrisonersDilemmaSimulation.Models
{
    public class TossRecord
    {
        [Key]
        public int TossID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerGuid { get; set; }
        public int TossNumber { get; set; }
        public int TossResult { get; set; } // todo: how to convert this to a database appropriate type
        public string OpponentName { get; set; }
        public int PointsTotal { get; set; }
        public int PointsEarnedThisToss { get; set; }
        public MatchRecord Match { get; set; }
    }
}