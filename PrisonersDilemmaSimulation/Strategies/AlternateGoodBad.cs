using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class AlternateGoodBad : IStrategy
    {
        public bool isCooperating { get; set; }

        public AlternateGoodBad()
        {
            isCooperating = false;
        }

        public string GetName()
        {
            return "AlternateGoodBad";
        }

        public void Notify(Match match)
        {
            throw new NotImplementedException();
        }

        public Result Play(IStrategy opponent)
        {
            isCooperating = !isCooperating;

            if (isCooperating)
            {
                return Result.Cooperate;
            }
            else
            {
                return Result.Defect;
            }
        }
    }
}
