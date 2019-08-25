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

        public string StartValidation(List<Fighter> fighters, List<int> checkedFighters)
        {
            fighters.Where(i => checkedFighters.Contains(i.Id)).Select(i => { i.Selected = true; return i; }).ToList();

            if (fighters.Where(i => checkedFighters.Contains(i.Id)).Count() != checkedFighters.Count())
            {
                return "Por favor, selecione 20 lutadores validos para o torneio ser iniciado.";
            }

            if (checkedFighters.Count() != NUMBEROFFIGHTERS)
            {
                return "Por favor, selecione 20 lutadores para o torneio ser iniciado.";
            }

            return string.Empty;
        }

        public List<Fighter> Contest(List<Fighter> fighters, List<int> checkedFighters)
        {
            IEnumerable<List<Fighter>> groups = Groups(fighters, checkedFighters);

            foreach (List<Fighter> group in groups)
            {
                IEnumerable<Ranking> raking = GroupRanking(group);
            }

            return new List<Fighter>();
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

        public IEnumerable<List<Fighter>> Groups(List<Fighter> fighters, List<int> checkedFighters)
        {
            List<Fighter> filtredFighters = fighters.Where(i => checkedFighters.Contains(i.Id)).OrderBy(i => i.Age).ToList();

            IEnumerable<List<Fighter>> groups = new List<List<Fighter>>()
            {
                filtredFighters.Take(5).ToList(),
                filtredFighters.Skip(5).Take(5).ToList(),
                filtredFighters.Skip(10).Take(5).ToList(),
                filtredFighters.Skip(15).Take(5).ToList()
            };

            return groups;
        }

        public IEnumerable<Ranking> GroupRanking(List<Fighter> fighters)
        {
            IEnumerable<Ranking> ranking = fighters.Select(i => new Ranking() { Id = i.Id, Name = i.Name, Fights = 0, Wins = 0, Loses = 0 });

            foreach (Fighter fighter in fighters)
            {
                foreach (Fighter challenger in fighters)
                {
                    if (fighter.Id != challenger.Id)
                    {
                        Fight fight = Winner(fighter, challenger);
                        ranking.Where(i => i.Id == fight.Winner).Select(i => { i.Wins = i.Wins++; i.Fights++; return i; });
                        ranking.Where(i => i.Id == fight.Loser).Select(i => { i.Wins = i.Loses++; i.Fights++; return i; });
                    }
                }
            }

            return ranking;
        }

        private int WinRate(Fighter fighter)
        {
            decimal rate = (fighter.Wins / fighter.Fights);
            return Convert.ToInt32((rate * 100));
        }
    }
}
