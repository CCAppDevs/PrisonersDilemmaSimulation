using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class RandomStrategy : AbstractStrategy
    {
        Random rnd = new Random();

        public override string GetName()
        {
            return "Random";
        }

        public override void Notify(Match match)
        {
            // does not care
        }

        public override Result Play(IStrategy opponent)
        {
            // choose a random result to return
            int choice = rnd.Next(0, 100);

            if (choice <= 50)
            {
                return Result.Cooperate;
            } else
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
