using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    internal class Aimless : AbstractStrategy
    {
        public override string GetName()
        {
            return "Aimless";
        }
        public override void Notify(Match match)
        {
            throw new NotImplementedException();
        }
        public override Result Play(IStrategy opponent)
        {
            Random rnd = new Random();
            int num = rnd.Next(1,50);
            if (num <= 36)
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
            
        }
    }
}
