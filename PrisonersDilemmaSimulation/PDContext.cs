using Microsoft.EntityFrameworkCore;
using PrisonersDilemmaSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaSimulation
{
    public class PDContext : DbContext
    {

        // dbsets
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<MatchRecord> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PrisonersDilemma;Trusted_Connection=True;");
        }
    }
}
