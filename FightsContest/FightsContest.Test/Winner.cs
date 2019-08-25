using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Service.Contest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FightsContest.Test
{
    [TestClass]
    public class Winner
    {
        private readonly IRulesContest _ruleContest;

        public Winner()
        {
            _ruleContest  = new RulesContest();
        }

        [TestMethod]
        public void WinnerByFights()
        {
            Fighter fighter = new Fighter() {
                Age = 20,
                Fights = 2,
                Loses = 1,
                MartialArts = new List<string>() {
                    "Wrestling",
                    "Kempo"
                },
                Id = 1,
                Name = "Lutador 1",
                Wins = 1,
            };

            Fighter challenger = new Fighter()
            {
                Age = 22,
                Fights = 4,
                Loses = 2,
                MartialArts = new List<string>() {
                    "Wrestling",
                    "Kempo"
                },
                Id = 2,
                Name = "Lutador 2",
                Wins = 2,
            };

            Fighter winner = _ruleContest.Winner(fighter, challenger);

            Assert.AreEqual(winner, challenger);
            Assert.AreEqual(winner.Name, "Lutador 2");

        }

        [TestMethod]
        public void WinnerByMartialArts()
        {
            Fighter fighter = new Fighter()
            {
                Age = 20,
                Fights = 2,
                Loses = 1,
                MartialArts = new List<string>() {
                    "Wrestling",
                    "Kempo"
                },
                Id = 1,
                Name = "Lutador 1",
                Wins = 1,
            };

            Fighter challenger = new Fighter()
            {
                Age = 22,
                Fights = 2,
                Loses = 1,
                MartialArts = new List<string>() {
                    "Wrestling"
                },
                Id = 2,
                Name = "Lutador 2",
                Wins = 1,
            };

            Fighter winner = _ruleContest.Winner(fighter, challenger);

            Assert.AreEqual(winner, fighter);
            Assert.AreEqual(winner.Name, "Lutador 1");
        }

        [TestMethod]
        public void WinnerByWinRate()
        {
            Fighter fighter = new Fighter()
            {
                Age = 20,
                Fights = 2,
                Loses = 0,
                MartialArts = new List<string>() {
                    "Wrestling",
                    "Kempo"
                },
                Id = 1,
                Name = "Lutador 1",
                Wins = 2,
            };

            Fighter challenger = new Fighter()
            {
                Age = 22,
                Fights = 3,
                Loses = 2,
                MartialArts = new List<string>() {
                    "Wrestling",
                    "Kempo"
                },
                Id = 2,
                Name = "Lutador 2",
                Wins = 1,
            };

            Fighter winner = _ruleContest.Winner(fighter, challenger);

            Assert.AreEqual(winner, fighter);
            Assert.AreEqual(winner.Name, "Lutador 1");
        }
    }
}
