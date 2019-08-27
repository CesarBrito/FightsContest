using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Entities.Model
{
    public class Result
    {
        public Fighter Winner { get; set; }
        public Fighter Second { get; set; }
        public Fighter Third { get; set; }
    }
}
