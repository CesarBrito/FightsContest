using FightsContest.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Utils
{
    public interface IValidation
    {
        string StartValidation(List<Fighter> fighters, List<int> checkedFighters);
    }
}
