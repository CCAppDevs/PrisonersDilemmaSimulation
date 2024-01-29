using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation.Strategies
{
    public abstract class AbstractStrategy : IStrategy
    {
        public Guid Guid { get; set; }

        public AbstractStrategy()
        {
            Guid = Guid.NewGuid();        
        }

        public Guid GetGuid()
        {
            return this.Guid;
        }

        public abstract string GetName();
        public abstract void Notify(Match match);
        public abstract Result Play(IStrategy opponent);
    }
}
