using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Entities.Model
{
    public class Ranking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Fights { get; set; }
    }
}
