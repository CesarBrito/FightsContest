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
    public class Contest
    {
        private readonly IRulesContest _ruleContest;

        public Contest()
        {
            _ruleContest = new RulesContest();
        }

        [TestMethod]
        public void Result()
        {
            var json = Resources.Get("fighters.json");

            List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(json);

            List<int> selecteds = fighters.Select(i => i.Id).ToList();

            Result finals = _ruleContest.Contest(fighters, selecteds);

            Assert.IsNotNull(finals);
            Assert.AreEqual(finals.Winner.Id, 28);
            Assert.AreEqual(finals.Second.Id, 30);
            Assert.AreEqual(finals.Third.Id, 22);


        }
        
    }
}
