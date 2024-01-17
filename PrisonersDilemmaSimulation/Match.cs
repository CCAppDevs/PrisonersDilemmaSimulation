using PrisonersDilemmaSimulation.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation
{
    public class Match
    {
        public IStrategy Player1 { get; set; }
        public IStrategy Player2 { get; set; }

        public Hashtable Results { get; set; }
        public Hashtable Points { get; set; }

        public Match(IStrategy p1, IStrategy p2)
        {
            Player1 = p1;
            Player2 = p2;
            Results = new Hashtable();
            Points = new Hashtable();
        }

        public void Simulate()
        {
            // TODO simulate two players competing
            Console.WriteLine("Players are {0} vs {1}", Player1.GetName(), Player2.GetName());
        }
    }
}
