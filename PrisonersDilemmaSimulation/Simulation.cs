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

        public Simulation()
        {
        
        }

        public void RunSimulation(IStrategy player1, IStrategy player2, int numberOfRounds)
        {
            //int player1Score = 0;
            //int player2Score = 0;
            List<Round> rounds = new List<Round>();

            for (int i = 0; i < numberOfRounds; i++)
            {
                // get choices for each player
                // record the round in the round array
                rounds.Add(new Round(i, player1, player2));
            }

        }
    }
}
