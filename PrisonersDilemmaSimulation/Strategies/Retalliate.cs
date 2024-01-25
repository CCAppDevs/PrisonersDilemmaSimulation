using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Retalliate : IStrategy
    {
        // Always defect if opponent has defected at least once.

        public bool hasOpponentDefected = false;

        public string GetName()
        {
            return "Retaliate";
        }

        public void Notify(Match match)
        {
            match.Results
        }

        public Result Play(IStrategy opponent)
        {
            if (hasOpponentDefected)
            {
                return Result.Defect;
            } 
            else
            {
                return Result.Cooperate;
            }
        }
    }
}
