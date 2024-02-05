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

        public bool opponentDefected = false;

        Random rnd = new Random();

        public override string GetName()
        {
            return "TitForTat";
        }

        public override void Notify(Match match)
        {
            if (match.Results.Last().TossResult == Result.Defect)
            {
                opponentDefected = true;
            }
        }

        public override Result Play(IStrategy opponent)
        {
            int choice = rnd.Next(1, 100);

            if (opponentDefected && choice > 10)
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
            opponentDefected = false;
        }
    }
}
