using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightsContest.Domain.Service.Contest
{
    public class RulesContest : IRulesContest
    {
        public Result Contest(List<Fighter> fighters, List<int> checkedFighters)
        {
            List<List<Fighter>> groups = Groups(fighters, checkedFighters);

            List<List<Ranking>> rankings = new List<List<Ranking>>();

            foreach (List<Fighter> group in groups)
            {
                List<Ranking> raking = GroupRanking(group);
                rankings.Add(raking);
            }

            List<List<Fighter>> quarters = QuarterFinals(fighters, rankings);

            List<Fighter> semifinalists = QuarterFinalsMatches(quarters, fighters);

            List<List<Fighter>> finalits = Semifinals(semifinalists, fighters);

            Result result = Finals(finalits, fighters);

            return result;
        }

        public List<List<Fighter>> QuarterFinals(List<Fighter> fighters, List<List<Ranking>> rankings)
        {
            List<List<Fighter>> quarter = new List<List<Fighter>>();
            foreach (List<Ranking> ranking in rankings)
            {
                quarter.Add(new List<Fighter>()
                {
                    fighters.FirstOrDefault(i => i.Id == ranking[0].Id),
                    fighters.FirstOrDefault(i => i.Id == ranking[1].Id),
                });

            }
            return quarter;
        }

        public List<Fighter> QuarterFinalsMatches(List<List<Fighter>> quartes, List<Fighter> fighters)
        {
            List<Fighter> result = new List<Fighter>();

            Fight A1B2 = Winner(quartes[0][0], quartes[1][1]);
            Fight A2B1 = Winner(quartes[0][1], quartes[1][0]);
            Fight C1D2 = Winner(quartes[2][0], quartes[3][1]);
            Fight C2D1 = Winner(quartes[2][1], quartes[0][0]);

            result.Add(fighters.FirstOrDefault(i => i.Id == A1B2.Winner));
            result.Add(fighters.FirstOrDefault(i => i.Id == A2B1.Winner));
            result.Add(fighters.FirstOrDefault(i => i.Id == C1D2.Winner));
            result.Add(fighters.FirstOrDefault(i => i.Id == C2D1.Winner));

            return result;

        }

        public List<List<Fighter>> Semifinals(List<Fighter> semifinals, List<Fighter> fighters)
        {
            Fight SemifinalOne = Winner(semifinals[0], semifinals[1]);
            Fight SemifinalTwo = Winner(semifinals[2], semifinals[3]);

            List<List<Fighter>> finals = new List<List<Fighter>>();

            List<Fighter> final = new List<Fighter>()
            {
                fighters.FirstOrDefault(i => i.Id == SemifinalOne.Winner),
                fighters.FirstOrDefault(i => i.Id == SemifinalTwo.Winner)
            };

            List<Fighter> thirdPlace = new List<Fighter>()
            {
                fighters.FirstOrDefault(i => i.Id == SemifinalOne.Loser),
                fighters.FirstOrDefault(i => i.Id == SemifinalTwo.Loser)
            };

            finals.Add(final);
            finals.Add(thirdPlace);

            return finals;

        }

        public Result Finals(List<List<Fighter>> finals, List<Fighter> fighters)
        {
            Fight final = Winner(finals[0][0], finals[0][1]);
            Fight third = Winner(finals[1][0], finals[1][1]);

            Result result = new Result()
            {
                Winner = fighters.FirstOrDefault(i => i.Id == final.Winner),
                Second = fighters.FirstOrDefault(i => i.Id == final.Loser),
                Third = fighters.FirstOrDefault(i => i.Id == third.Winner)
            };

            return result;
        }

        public Fight Winner(Fighter fighter, Fighter challenger)
        {
            Fight fight = new Fight()
            {
                Loser = challenger.Id,
                Winner = fighter.Id
            };
            decimal winRateFighter = WinRate(fighter);
            decimal winRateChanllenger = WinRate(challenger);

            if (winRateFighter < winRateChanllenger)
            {
                fight.Loser = fighter.Id;
                fight.Winner = challenger.Id;
            }
            else if (winRateFighter == winRateChanllenger)
            {
                if (fighter.MartialArts.Count() < challenger.MartialArts.Count())
                {
                    fight.Loser = fighter.Id;
                    fight.Winner = challenger.Id;
                }
                else if (fighter.MartialArts.Count() == challenger.MartialArts.Count())
                {
                    if (fighter.Fights < challenger.Fights)
                    {
                        fight.Loser = fighter.Id;
                        fight.Winner = challenger.Id;
                    }
                }
            }

            return fight;
        }

        public List<List<Fighter>> Groups(List<Fighter> fighters, List<int> checkedFighters)
        {
            List<Fighter> filtredFighters = fighters.Where(i => checkedFighters.Contains(i.Id)).OrderBy(i => i.Age).ToList();

            List<List<Fighter>> groups = new List<List<Fighter>>()
            {
                filtredFighters.Take(5).ToList(),
                filtredFighters.Skip(5).Take(5).ToList(),
                filtredFighters.Skip(10).Take(5).ToList(),
                filtredFighters.Skip(15).Take(5).ToList()
            };

            return groups;
        }

        public List<Ranking> GroupRanking(List<Fighter> fighters)
        {
            List<Ranking> ranking = fighters.Select(i => new Ranking() { Id = i.Id, Name = i.Name, Fights = 0, Wins = 0, Loses = 0 }).ToList();
            int indexChallenger = 1;
            int indexOut = 1;
            foreach (Fighter fighter in fighters)
            {
                indexChallenger = indexOut;
                while (indexChallenger <= 4)
                {
                    Fighter challenger = fighters[indexChallenger];
                    Fight fight = Winner(fighter, challenger);
                    ranking.Where(i => i.Id == fight.Winner).Select(i => { i.Wins += 1; i.Fights += 1; return i; }).ToList();
                    ranking.Where(i => i.Id == fight.Loser).Select(i => { i.Loses += 1; i.Fights += 1; return i; }).ToList();
                    indexChallenger++;
                }
                indexOut++;
            }

            return ranking.OrderByDescending(i => i.Wins).ToList();
        }

        private int WinRate(Fighter fighter)
        {
            decimal rate = (fighter.Wins / fighter.Fights);
            return Convert.ToInt32((rate * 100));
        }
    }
}
