using FightsContest.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Contest
{
    public interface IRulesContest
    {
        List<Fighter> Contest(List<Fighter> fighters, List<int> checkedFighters);

        List<List<Fighter>> QuarterFinals(List<Fighter> fighters, List<List<Ranking>> rankings);

        Fight Winner(Fighter fighter, Fighter challenger);

        List<List<Fighter>> Groups(List<Fighter> fighters, List<int> checkedFighters);

        List<Ranking> GroupRanking(List<Fighter> fighters);
    }
}
