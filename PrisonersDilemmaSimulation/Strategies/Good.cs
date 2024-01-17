using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Good : IStrategy
    {
        public Good() { }

        public string GetName()
        {
            return "Good";
        }

        public void Notify(Match match)
        {
        }

        public Result Play(IStrategy opponent)
        {
            return Result.Cooperate;
        }
    }
}
