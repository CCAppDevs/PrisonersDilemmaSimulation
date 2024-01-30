using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Good : AbstractStrategy
    {
        public Good() { }

        public override string GetName()
        {
            return "Good";
        }

        public override void Notify(Match match)
        {
        }

        public override Result Play(IStrategy opponent)
        {
            return Result.Cooperate;
        }

        public override void ResetStrategy()
        {
        }
    }
}
