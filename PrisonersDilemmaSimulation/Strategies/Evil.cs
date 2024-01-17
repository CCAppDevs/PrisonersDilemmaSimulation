using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Evil : IStrategy
    {
        public Evil()
        {
             
        }

        public string GetName()
        {
            return "Evil";
        }

        public void Notify(Match match)
        {
            throw new NotImplementedException();
        }

        public Result Play(IStrategy opponent)
        {
            return Result.Defect;
        }
    }
}
