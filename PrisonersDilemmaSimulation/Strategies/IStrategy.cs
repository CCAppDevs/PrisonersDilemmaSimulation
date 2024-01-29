using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public interface IStrategy
    {
        string GetName();
        Guid GetGuid();
        Result Play(IStrategy opponent);
        void Notify(Match match);
    }
}
