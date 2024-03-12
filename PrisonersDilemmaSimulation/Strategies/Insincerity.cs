using PrisonersDilemmaSimulation.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Insincerity : AbstractStrategy  //Keri
    {
        public int _count = 1;
        public override string GetName()
        {
            return "insincerity";
        }
        public override void Notify(Match match)
        {
            _count++;
        }
        public override Result Play(IStrategy opponent)
        {
            if (_count % 5 == 0)
            {
                return Result.Defect;
            }
            if (_count % 13 == 0)
            {
                return Result.Defect;
            }
            else
            {
                return Result.Cooperate;
            }
        }

        public override void ResetStrategy()
        {
            _count = 1;
        }
    }
}

       

