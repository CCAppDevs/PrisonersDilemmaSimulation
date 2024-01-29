using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Evil : AbstractStrategy
    {
        public Evil()
        {
             
        }

        public override string GetName()
        {
            return "Evil";
        }

        public override void Notify(Match match)
        {
            throw new NotImplementedException();
        }

        public override Result Play(IStrategy opponent)
        {
            return Result.Defect;
        }
    }
}
