using FightsContest.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Contest
{
    public interface IRulesContest
    {
        Result Contest(List<Fighter> fighters, List<int> checkedFighters);

        List<List<Fighter>> QuarterFinals(List<Fighter> fighters, List<List<Ranking>> rankings);

        List<Fighter> QuarterFinalsMatches(List<List<Fighter>> quartes, List<Fighter> fighters);

        List<List<Fighter>> Semifinals(List<Fighter> semifinals, List<Fighter> fighters);

        Result Finals(List<List<Fighter>> finals, List<Fighter> fighters);

        Fight Winner(Fighter fighter, Fighter challenger);

        List<List<Fighter>> Groups(List<Fighter> fighters, List<int> checkedFighters);

        List<Ranking> GroupRanking(List<Fighter> fighters);
    }
}
