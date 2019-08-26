using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Service.Contest;
using FightsContest.Test.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FightsContest.Test
{
    [TestClass]
    public class QuarterFinals
    {
        private readonly IRulesContest _ruleContest;

        public QuarterFinals()
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
            
            List<List<Ranking>> rankings = new List<List<Ranking>>();

            foreach (List<Fighter> group in groups)
            {
                List<Ranking> raking = _ruleContest.GroupRanking(group);
                rankings.Add(raking);
            }

            List<List<Fighter>> quarters = _ruleContest.QuarterFinals(fighters, rankings);

            Assert.AreEqual(quarters.Count(), 4);

            foreach(List<Fighter> quarter in quarters)
            {
                Assert.AreEqual(quarter.Count(), 2);
            }
            

        }

    }
}
