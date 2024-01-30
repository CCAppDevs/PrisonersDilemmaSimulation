using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class AlternateGoodBad : AbstractStrategy
    {
        public bool isCooperating { get; set; }

        public AlternateGoodBad()
        {
            isCooperating = false;
        }

        public override string GetName()
        {
            return "AlternateGoodBad";
        }

        public override void Notify(Match match)
        {
        }

        public override Result Play(IStrategy opponent)
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

        public override void ResetStrategy()
        {
            isCooperating = false;
        }
    }
}
