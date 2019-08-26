using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Service.Contest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace FightsContest.Test
{
    [TestClass]
    public class Group
    {
        private readonly IRulesContest _ruleContest;





        public Group()
        {
            _ruleContest = new RulesContest();

        }

        [TestMethod]
        public void Create()
        {
            var json = Resources.Get("fighters.json");

            List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(json);

            List<int> selected = fighters.Select(i => i.Id).ToList();

            List<List<Fighter>> groups = _ruleContest.Groups(fighters, selected);

            Assert.AreEqual(groups.Count(), 4);

            foreach (List<Fighter> group in groups)
            {
                Assert.AreEqual(group.Count(), 5);
            }

        }

        [TestMethod]
        public void Ranking()
        {
            var json = Resources.Get("group.json");

            List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(json);

            List<Ranking> rankings = _ruleContest.GroupRanking(fighters);

            Assert.AreEqual(rankings.Count(), 5);

            Assert.AreEqual(rankings[0].Id, 33);
            Assert.AreEqual(rankings[1].Id, 37);
            Assert.AreEqual(rankings[2].Id, 35);
            Assert.AreEqual(rankings[3].Id, 34);
            Assert.AreEqual(rankings[4].Id, 36);
        }
    }
}
