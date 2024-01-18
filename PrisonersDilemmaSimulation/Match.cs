using PrisonersDilemmaSimulation.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation
{
    public class Match
    {
        public IStrategy Player1 { get; set; }
        public IStrategy Player2 { get; set; }

        public Hashtable Results { get; set; }
        public Hashtable Points { get; set; }

        public Match()
        {
            Results = new Hashtable();
            Points = new Hashtable();
        }

        public Match(IStrategy p1, IStrategy p2)
        {
            Player1 = p1;
            Player2 = p2;
            Results = new Hashtable();
            Points = new Hashtable();
        }

        public void Simulate()
        {
            // TODO simulate two players competing
            Console.WriteLine("---------------- Begin Match ----------------");
            Console.WriteLine("{0} vs {1}", Player1.GetName(), Player2.GetName());

            int p1Score = 0;
            int p2Score = 0;

            Result p1Result = Player1.Play(Player2);
            Result p2Result = Player2.Play(Player1);

            // tally scores
            if (p1Result == Result.Cooperate)
            {
                if (p2Result == Result.Cooperate)
                {
                    // both cooperated
                    p1Score++;
                    p2Score++;
                }
                else
                {
                    // p1 cooperated, p2 defected
                    p1Score += 5;
                }
            }
            else
            {
                if (p2Result == Result.Cooperate)
                {
                    // p1 defected, p2 cooperated
                    p2Score += 5;
                }
                else
                {
                    // both defected
                    p1Score += 3;
                    p2Score += 3;
                }
            }

            Console.WriteLine("{0} - {1} - {2}", Player1.GetName(), p1Result.ToString(), p1Score);
            Console.WriteLine("{0} - {1} - {2}", Player2.GetName(), p2Result.ToString(), p2Score);
        }
    }
}
