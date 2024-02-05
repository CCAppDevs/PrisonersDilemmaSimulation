using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{

    public class TitForTat : AbstractStrategy
    {
        // Defect if the opponent defected in the previous round; with 10% forgiveness.

        public int opponentDefected = 0;

        public bool lastDefected = false;   // bool for testing

        Random rnd = new Random();
        int listPosition = 0;

        public override string GetName()
        {
            return "TitForTat";
        }

        public override void Notify(Match match)
        {
            // Grab the last result from the match
            if (match.Results.Last().TossResult == Result.Defect)
            {
                lastDefected = true;
            };    // most recent item in the results list (most recent last match)
        }

        public override Result Play(IStrategy opponent)
        {
            int choice = rnd.Next(1, 100);

            if (lastDefected && choice > 10)   // I think this should be less than 10 for 10% forgiveness
            {
                ResetStrategy();
                return Result.Defect;
            }

            else
            {
                return Result.Cooperate;
            }
        }

        public override void ResetStrategy()
        {
            lastDefected = false;
        }
    }
}
