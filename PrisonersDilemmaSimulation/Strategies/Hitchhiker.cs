using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class HitchhikerStrategy : AbstractStrategy
    {
        int toss;
        Random random42 = new Random(42);

        public override string GetName()
        {
            // Andrea
            return "Hitchhiker";
        }

        public override void Notify(Match match)
        {
            toss = match.TossNumber;
        }

        public override Result Play(IStrategy opponent)
        {

            if ((toss * random42.Next())%42 >= 5)
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
            // does not care
        }
    }
}
