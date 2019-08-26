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
        private const int NUMBEROFFIGHTERS = 20;

        public List<Fighter> Contest(List<Fighter> fighters, List<int> checkedFighters)
        {
            List<List<Fighter>> groups = Groups(fighters, checkedFighters);
            List<List<Ranking>> rankings = new List<List<Ranking>>();
            foreach (List<Fighter> group in groups)
            {
                List<Ranking> raking = GroupRanking(group);
                rankings.Add(raking);
            }

            var teste =  QuarterFinals(fighters, rankings);

            return new List<Fighter>();
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
                    ranking.Where(i => i.Id == fight.Winner).Select(i => { i.Wins += +1; i.Fights += 1; return i; }).ToList();
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
