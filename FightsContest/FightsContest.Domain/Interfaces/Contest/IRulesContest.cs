using FightsContest.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Contest
{
    public interface IRulesContest
    {
        string StartValidation(List<Fighter> fighters, List<int> checkedFighters);
        Fighter Winner(Fighter fighter, Fighter challenger);

    }
}
