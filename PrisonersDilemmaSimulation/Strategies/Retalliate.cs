﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public class Retalliate : AbstractStrategy
    {
        // Always defect if opponent has defected at least once.

        public bool hasOpponentDefected = false;

        public override string GetName()
        {
            return "Retaliate";
        }

        public override void Notify(Match match)
        {
            hasOpponentDefected = match.Results.Any(r => r.Guid != Guid && r.TossResult == Result.Defect);
        }

        public override Result Play(IStrategy opponent)
        {
            if (hasOpponentDefected)
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
            hasOpponentDefected = false;
        }
    }
}
