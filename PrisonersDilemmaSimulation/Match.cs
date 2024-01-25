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

        public List<Toss> Results { get; set; }
        public Dictionary<string, int> Points { get; set; }

        public int TossNumber { get; set; }

        public Match()
        {
            Results = new List<Toss>();
            Points = new Dictionary<string, int>();
            TossNumber = 1;
        }

        public Match(IStrategy p1, IStrategy p2)
        {
            Player1 = p1;
            Player2 = p2;
            Results = new List<Toss>();
            Points = new Dictionary<string, int>();
            TossNumber = 1;

            Points.Add("Player1", 0);
            Points.Add("Player2", 0);
        }

        public void Simulate()
        {
            int p1Score = 0;
            int p2Score = 0;

            Result p1Result = Player1.Play(Player2);
            Results.Add(new Toss("Player1", p1Result, TossNumber));
            Result p2Result = Player2.Play(Player1);
            Results.Add(new Toss("Player2", p2Result, TossNumber));

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

            Points["Player1"] += p1Score;
            Points["Player2"] += p2Score;

            TossNumber++;
        }
    }
}
