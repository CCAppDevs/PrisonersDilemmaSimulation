using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    //Jordan's Second Strategy
    public class CoinToss : AbstractStrategy
    {
        private decimal CountDefects;
        private decimal CountMatches = 0;
        private decimal Probability;
        public override string GetName()
        {
            return "CoinToss";
        }

        public override void Notify(Match match)
        {
            CountDefects = match.Results.Count(T => T.Guid != Guid && T.TossResult == Result.Defect);
        }

        public override Result Play(IStrategy opponent)
        {
            if (CountMatches > 0)
            {
                Probability = CountDefects / CountMatches;

                if(Probability < 0.50M)
                {
                    CountMatches++;
                    return Result.Cooperate;
                }
                else
                {

                    CountMatches++;
                    return Result.Defect;
                }
            }
            else
            {
                CountMatches++;
                return Result.Cooperate;
            }
        }

        public override void ResetStrategy()
        {
            CountDefects = 0;
            CountMatches = 0;
            Probability = 0;
        }
    }
}
