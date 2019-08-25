using FightsContest.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Contest
{
    public interface IRulesContest
    {
        string StartValidation(List<Fighter> fighters, List<int> checkedFighters);

        List<Fighter> Contest(List<Fighter> fighters, List<int> checkedFighters);

        Fight Winner(Fighter fighter, Fighter challenger);

        List<List<Fighter>> Groups(List<Fighter> fighters, List<int> checkedFighters);

        List<Ranking> GroupRanking(List<Fighter> fighters);
    }
}
