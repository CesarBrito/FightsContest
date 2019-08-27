using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Interfaces.Repository;
using FightsContest.Domain.Interfaces.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FightsContest.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Fighter> _fighters;
        private readonly IRulesContest _rules;
        private readonly IValidation _validation;

        public HomeController(IFightersRepository fightersRepository, IRulesContest rules, IValidation validation)
        {
            _fighters = fightersRepository.Get();
            _validation = validation;
            _rules = rules;
            
        }

        public IActionResult Index()
        {
            Contest contest = new Contest()
            {
                Fighters = _fighters
            };

            return View(contest);
        }

        [HttpPost]
        public IActionResult Contest(Contest contest)
        {
            contest.Fighters = _fighters;

            string startValidation = _validation.StartValidation(contest.Fighters, contest.CheckBoxFighters);

            if (!string.IsNullOrEmpty(startValidation))
            {
                contest.ErrorMessage = startValidation;
            }
            else
            {
                Result winners = _rules.Contest(contest.Fighters, contest.CheckBoxFighters);
                return View("Contest", winners);
            }

            return View("Index", contest);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
