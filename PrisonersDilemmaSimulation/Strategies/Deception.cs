using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    //Jordan's Strategy
    public class Deception : AbstractStrategy
    {
        private bool[] DoNotBeFooled = new bool[2];
        private int MatchCount;

        public override string GetName()
        {
            return "Deception";
        }

        public override void Notify(Match match)
        {
            MatchCount = match.Results.Count;

            if (match.Results.Count > 1)
            {
                DoNotBeFooled[0] = match.Results[match.Results.Count - 2].Guid != Guid && (match.Results[match.Results.Count - 2].TossResult == Result.Defect);
                DoNotBeFooled[1] = match.Results[match.Results.Count - 1].Guid != Guid && (match.Results[match.Results.Count - 1].TossResult == Result.Defect);
            }
            else
            {
                DoNotBeFooled[0] = match.Results[0].Guid != Guid && (match.Results[0].TossResult == Result.Defect);
            }

        }


        public override Result Play(IStrategy opponent)
        {
            bool bothMovesAreTrue = DoNotBeFooled[0] && DoNotBeFooled[1];

            if(MatchCount == 0)
            {
                return Result.Defect;
            }

            if (bothMovesAreTrue)
            {
                return Result.Defect;
            }
            else
            {
                if(MatchCount % 3 == 0)
                {
                    return Result.Defect;
                }
                else
                {
                    return Result.Cooperate;
                }
            }
        }


        public override void ResetStrategy()
        {
            //Doesn't Care
        }
    }
}
