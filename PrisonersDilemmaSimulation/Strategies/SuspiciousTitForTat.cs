using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class SuspiciousTitForTat : AbstractStrategy // Trevor
    {
        // Defect the first round and thereafter if and only if the opponent defected in the previous round; with 10% forgiveness.

        public bool opponentDefected = false;
        public bool firstRound { get; set; }
        Random rnd = new Random();
        
        public SuspiciousTitForTat() 
        {
            firstRound = true;
        }

        public override string GetName()
        {
            return "SuspiciousTitForTat";
        }

        public override void Notify(Match match)
        {
            if (match.Results.Last().TossResult == Result.Defect)
            {
                opponentDefected = true;
            }
        }

        public override Result Play(IStrategy opponent)
        {
            int choice = rnd.Next(1, 100);

            if(firstRound)
            {
                firstRound = false;
                return Result.Defect;
            }
            else if (opponentDefected && choice > 10)
            {
                opponentDefected = false;
                return Result.Defect;
            }
            else
            {
                return Result.Cooperate;
            }
        }

        public override void ResetStrategy()
        {
            firstRound = true;
            opponentDefected = false;
        }
    }
}
