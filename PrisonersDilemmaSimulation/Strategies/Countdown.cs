using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Countdown : AbstractStrategy // Danny
    {
        // Cooperates every third round

        public int roundCount = 1;

        public override string GetName()
        {
            return "Countdown";
        }

        public override void Notify(Match match)
        {
            roundCount++;
        }

        public override Result Play(IStrategy opponent)
        {
            if (roundCount % 3 == 0)
            {
                return Result.Cooperate;
            }
            else
            {
                return Result.Defect;
            }
        }

        public override void ResetStrategy()
        {
            roundCount = 1;
        }
    }
}
