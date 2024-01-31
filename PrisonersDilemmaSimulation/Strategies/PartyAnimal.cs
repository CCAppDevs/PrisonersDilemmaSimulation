using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class PartyAnimal : AbstractStrategy
    {
        int toss;
        DateOnly day;

        public override string GetName()
        {
            // Andrea
            return "PartyAnimal";
        }

        public override void Notify(Match match)
        {
            day = new(2024, 01, 01);
            toss = match.TossNumber;
        }

        public override Result Play(IStrategy opponent)
        {
            day = day.AddDays(toss);
            if (day.DayOfWeek == DayOfWeek.Friday) { return Result.Cooperate; }
            if (day.DayOfWeek == DayOfWeek.Saturday) { return Result.Cooperate; }
            if (day.DayOfWeek == DayOfWeek.Sunday) { return Result.Cooperate; }
            else { return Result.Defect ; }
        }

        public override void ResetStrategy()
        {
            // does not care
        }
    }
}
