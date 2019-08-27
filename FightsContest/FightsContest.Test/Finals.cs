using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Contest;
using FightsContest.Domain.Service.Contest;
using FightsContest.Test.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace FightsContest.Test
{
    [TestClass]
    public class Finals
    {
        private readonly IRulesContest _ruleContest;

        public Finals()
        {
            _ruleContest = new RulesContest();
        }

        [TestMethod]
        public void Semifinals()
        {
            var json = Resources.Get("simifinals.json");
            var json2 = Resources.Get("fighters.json");

            List<Fighter> seminialists = JsonConvert.DeserializeObject<List<Fighter>>(json);
            List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(json2);

            List<List<Fighter>> finals = _ruleContest.Semifinals(seminialists, fighters);

            Assert.AreEqual(finals.Count(), 2);
            foreach (List<Fighter> final in finals)
            {
                Assert.AreEqual(final.Count(), 2);
            }

            Assert.AreEqual(finals[0][0].Id, 37);
            Assert.AreEqual(finals[0][1].Id, 35);
            Assert.AreEqual(finals[1][0].Id, 36);
            Assert.AreEqual(finals[1][1].Id, 34);
        }

        [TestMethod]
        public void Final()
        {
            var json = Resources.Get("finals.json");
            var json2 = Resources.Get("fighters.json");

            List<List<Fighter>> finals = JsonConvert.DeserializeObject<List<List<Fighter>>>(json);
            List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(json2);

            Result result = _ruleContest.Finals(finals, fighters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Winner.Id, 37);
            Assert.AreEqual(result.Second.Id, 36);
            Assert.AreEqual(result.Third.Id, 35);
        }
        
    }
}
