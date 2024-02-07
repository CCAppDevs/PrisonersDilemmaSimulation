using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Models
{
    public class MatchRecord
    {
        [Key]
        public int MatchID { get; set; }
        [ForeignKey("Player1")]
        public int Player1Id { get; set; }
        [ForeignKey("Player2")]
        public int Player2Id { get; set; }

        public Strategy Player1 { get; set; }
        public Strategy Player2 { get; set; }

        public List<TossRecord> Tosses { get; set; }

    }
}
