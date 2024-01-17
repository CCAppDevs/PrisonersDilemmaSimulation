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

        public Simulation()
        {
            // Add Strategies to simulate
            Players.Add(new Good());
            Players.Add(new Evil());

            // TODO: cross join players to itself to create pairings
            Matches.Add(new Match(Players[0], Players[1]));
        }

        public void RunSimulation()
        {
            foreach (Match match in Matches)
            {
                match.Simulate();
            }

        }
    }
}
