using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightsContest.Domain.Service.Utils
{
    public class Validation : IValidation
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
    }
}
