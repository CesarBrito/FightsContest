using FightsContest.Domain.Entities;
using FightsContest.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FightsContest.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFightersRepository _fightersRepository;

        public HomeController(IFightersRepository fightersRepository)
        {
            _fightersRepository = fightersRepository;
        }

        public IActionResult Index()
        {
            Contest contest = new Contest()
            {
                Fighters = _fightersRepository.Get()
            };
            
            return View(contest);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
