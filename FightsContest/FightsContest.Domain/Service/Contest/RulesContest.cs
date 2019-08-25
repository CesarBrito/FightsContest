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

        public Fighter Winner(Fighter fighter, Fighter challenger)
        {
            Fighter winner = fighter;

            decimal winRateFighter = WinRate(fighter);
            decimal winRateChanllenger = WinRate(challenger);

            if (winRateFighter < winRateChanllenger)
            {
                fighter = challenger;
            }
            else if (winRateFighter == winRateChanllenger)
            {
                if (fighter.MartialArts.Count() < challenger.MartialArts.Count())
                {
                    fighter = challenger;
                }
                else if (fighter.MartialArts.Count() == challenger.MartialArts.Count())
                {
                    if (fighter.Fights < challenger.Fights)
                    {
                        fighter = challenger;
                    }
                }
            }

            return fighter;
        }

        private int WinRate(Fighter fighter)
        {
            decimal rate = (fighter.Wins / fighter.Fights);
            return Convert.ToInt32((rate * 100));
        }
    }
}
