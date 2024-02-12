using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class FirmButFair : AbstractStrategy // Danny
    {
        // Defect if the opponent defected in the previous round,
        // always defects if opponent defects more often than not

        public bool opponentDefected = false;
        public int roundCount = 0;
        public int timesOpponentDefected = 0;

        public override string GetName()
        {
            return "FirmButFair";
        }

        public override void Notify(Match match)
        {
            if (match.Results.Where(r => r.Guid != Guid).Last().TossResult == Result.Defect)
            {
                timesOpponentDefected++;
                opponentDefected = true;
            }
            roundCount++;
        }

        public override Result Play(IStrategy opponent)
        {
            if (timesOpponentDefected > roundCount / 2)
            {
                opponentDefected = false;
                return Result.Defect;
            }
            else if (opponentDefected)
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
            roundCount = 0;
            timesOpponentDefected = 0;
        }
    }
}
