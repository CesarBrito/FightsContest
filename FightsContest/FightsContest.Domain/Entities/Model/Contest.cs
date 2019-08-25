using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Entities.Model
{
    public class Contest
    {
        public List<int> CheckBoxFighters { get; set; }
        public List<Fighter> Fighters { get; set; }
        public string ErrorMessage { get; set; }
    }
}
