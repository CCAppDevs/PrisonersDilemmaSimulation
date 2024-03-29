﻿using PrisonersDilemmaSimulation.Models;
using PrisonersDilemmaSimulation.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation
{
    public class Simulation
    {
        // TODO: Add code to run a simulation

        // 100 simulations per pair of players (should be variable for maximum effect)

        // scoring: Lowest Score Wins
            // Two Players, each can either snitch or remain silent
            // if both remain silent = both gain 1
            // if one party snitches = 5 for the silent, 0 for the snitch
            // if both snitch        = 3 for each

        private List<IStrategy> Players = new List<IStrategy>();
        private List<Match> Matches = new List<Match>();
        private int numMatchesInRound = 1000;

        public Simulation()
        {
            // Add Strategies to simulate
            Players.Add(new Good());
            Players.Add(new Evil());
            Players.Add(new AlternateGoodBad());
            Players.Add(new Retalliate());
            Players.Add(new RandomStrategy());
            Players.Add(new HitchhikerStrategy());  // AP
            Players.Add(new DaysOfCreation());  //AP
            Players.Add(new PartyAnimal());   // AP
            Players.Add(new OurJewishFriend()); // AP
            Players.Add(new DailyGrind()); // AP
            Players.Add(new TitForTat()); // TE
            Players.Add(new ForgivingTitForTat()); // TE
            Players.Add(new SuspiciousTitForTat()); // TE
            Players.Add(new Deception());
            Players.Add(new CoinToss());
            Players.Add(new FirmButFair()); // DG
            Players.Add(new Countdown());   // DG

            List<IStrategy> Players2 = new List<IStrategy>();
            Players2.Add(new Good());
            Players2.Add(new Evil());
            Players2.Add(new AlternateGoodBad());
            Players2.Add(new Retalliate());
            Players2.Add(new RandomStrategy());
            Players2.Add(new HitchhikerStrategy());  // AP
            Players2.Add(new DaysOfCreation());  //AP
            Players2.Add(new PartyAnimal());   // AP
            Players2.Add(new OurJewishFriend()); // AP
            Players2.Add(new DailyGrind()); // AP
            Players2.Add(new TitForTat()); // TE
            Players2.Add(new SuspiciousTitForTat()); // TE
            Players2.Add(new ForgivingTitForTat());
            Players2.Add(new Deception());
            Players2.Add(new CoinToss());
            Players2.Add(new FirmButFair()); // DG
            Players2.Add(new Countdown());   // DG

            foreach (var player in Players)
            {
                SaveStrategy(player);
            }

            foreach (var player in Players2)
            {
                SaveStrategy(player);
            }

            var matches = from p1 in Players
                          from p2 in Players2
                          select new Match(p1, p2);

            Matches.AddRange(matches);

        }

        public void RunSimulation()
        {
            foreach (Match match in Matches)
            {
                // this is a round
                Console.WriteLine("=================== Begining Match ==================");
                Console.WriteLine("{0}-{1} vs {2}-{3}", match.Player1.GetGuid(), match.Player1.GetName(), match.Player2.GetGuid(), match.Player2.GetName());

                for (int i = 0; i < numMatchesInRound; i++)
                {
                    // this is a single match
                    match.Simulate();
                }

                Console.Write("Player1: {0} - Score: {1} - Plays: ", match.Player1.GetGuid(), match.Points["Player1"]);

                //foreach (Toss toss in match.Results.Where(t => t.Name == "Player1")) {
                //    if (toss.TossResult.ToString() == "Cooperate")
                //    {
                //        Console.Write('0');
                //    } else
                //    {
                //        Console.Write('#');
                //    }
                //}

                Console.WriteLine();
                Console.Write("Player2: {0} - Score: {1} - Plays: ", match.Player2.GetGuid(), match.Points["Player2"]);
                //foreach (Toss toss in match.Results.Where(t => t.Name == "Player2"))
                //{
                //    if (toss.TossResult.ToString() == "Cooperate")
                //    {
                //        Console.Write('0');
                //    }
                //    else
                //    {
                //        Console.Write('#');
                //    }
                //}

                Console.WriteLine();
                Console.WriteLine();

                try
                {
                    RecordMatch(match);
                } catch (Exception ex) { 
                    Console.WriteLine(ex.ToString()); 
                }

                match.Player1.ResetStrategy();
                match.Player2.ResetStrategy();
            }

        }

        public void SaveStrategy(IStrategy strategy)
        {
            using (var ctx = new PDContext())
            {
                ctx.Strategies.Add(new Strategy
                {
                    StrategyID = 0,
                    StrategyName = strategy.GetName(),
                    StrategyDescription = "", // TODO: Either add a field for this to IStrategy or remove this from the model.
                    Guid = strategy.GetGuid().ToString(),
                });

                ctx.SaveChanges();
            }
        }

        public void RecordMatch(Match match)
        {
            
            // using the context, record the match
            using (var ctx = new PDContext())
            {
                Strategy player1 = ctx.Strategies.Where(s => s.Guid == match.Player1.GetGuid().ToString()).SingleOrDefault();
                Strategy player2 = ctx.Strategies.Where(s => s.Guid == match.Player2.GetGuid().ToString()).SingleOrDefault();

                if (player1 == null)
                {
                    throw new Exception("Player 1 was not found.");
                }

                if (player2 == null)
                {
                    throw new Exception("Player 2 was not found.");
                }

                MatchRecord theMatch = new MatchRecord
                {
                    Player1Id = player1.StrategyID,
                    Player2Id = player2.StrategyID,
                    Tosses = new List<TossRecord>()
                };

                foreach (Toss toss in match.Results)
                {
                    theMatch.Tosses.Add(new TossRecord
                    {
                        PlayerName = toss.Name,
                        PlayerGuid = toss.Guid.ToString(),
                        TossNumber = toss.TossNumber,
                        TossResult = GetResult(toss.TossResult),
                        OpponentName = toss.OpponentName,
                        PointsTotal = toss.PointsTotal,
                        PointsEarnedThisToss = toss.PointsEarnedThisToss
                    });
                }

                ctx.Matches.Add(theMatch);

                ctx.SaveChanges();
            }
        }

        private int GetResult(Result tossResult)
        {
            if (tossResult == Result.Cooperate)
            {
                return 0;
            } 
            else
            {
                return 1;
            }
        }
    }
}
