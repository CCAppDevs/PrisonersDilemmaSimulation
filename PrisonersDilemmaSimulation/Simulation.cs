using PrisonersDilemmaSimulation.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation
{
    public class Simulation
    {
        // TODO: Add code to run a simulation

        // 100 simulations per pair of players (should be variable for maximum effect)

        // scoring: Lowest Score Wins
            // Two Players, each can either snitch or remain silent
            // if both remain silent = both gain 1
            // if one party snitches = 5 for the silent, 0 for the snitch
            // if both snitch        = 3 for each

        private List<IStrategy> Players = new List<IStrategy>();
        private List<Match> Matches = new List<Match>();
        private int numMatchesInRound = 200;

        public Simulation()
        {
            // Add Strategies to simulate
            Players.Add(new Good());
            Players.Add(new Evil());
            Players.Add(new AlternateGoodBad());


            var matches = from p1 in Players
                          from p2 in Players
                          select new Match(p1, p2);

            Matches.AddRange(matches);

        }

        public void RunSimulation()
        {
            foreach (Match match in Matches)
            {
                // this is a round
                Console.WriteLine("=================== Begining Match ==================");
                Console.WriteLine("{0} vs {1}", match.Player1.GetName(), match.Player2.GetName());

                for (int i = 0; i < numMatchesInRound; i++)
                {
                    // this is a single match
                    match.Simulate();
                }

                Console.WriteLine("Player1: {0} - Score: {1}", match.Player1.GetName(), match.Points["Player1"]);
                Console.WriteLine("Player2: {0} - Score: {1}", match.Player2.GetName(), match.Points["Player2"]);
                // store the score
            }

        }
    }
}
