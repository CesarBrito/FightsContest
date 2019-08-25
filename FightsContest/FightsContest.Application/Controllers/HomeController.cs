using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FightsContest.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Fighter> _fighters;
        private readonly IRulesContest _rules;

        public HomeController(IFightersRepository fightersRepository, IRulesContest rules)
        {
            _fighters = fightersRepository.Get();
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

            string startValidation = _rules.StartValidation(contest.Fighters, contest.CheckBoxFighters);

            if (!string.IsNullOrEmpty(startValidation))
            {
                contest.ErrorMessage = startValidation;
            }

            return View("Index", contest);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
