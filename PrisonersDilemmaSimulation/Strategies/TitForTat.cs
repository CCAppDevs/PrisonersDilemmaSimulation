using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class TitForTat : AbstractStrategy // Trevor
    {
        // Defect if the opponent defected in the previous round;

        public bool opponentDefected = false;

        public override string GetName()
        {
            return "TitForTat";
        }

        public override void Notify(Match match)
        {
            if (match.Results.Where(r => r.Guid != Guid).Last().TossResult == Result.Defect)
            {
                opponentDefected = true;
            }
        }

        public override Result Play(IStrategy opponent)
        {
            if (opponentDefected)
            {
                opponentDefected = false;
                return Result.Defect;
            }
            else
            {
                opponentDefected = false;
                return Result.Cooperate;
            }

        }

        public override void ResetStrategy()
        {
            opponentDefected = false;
        }
    }
}
