using FightsContest.Domain.Entities.Model;
using FightsContest.Domain.Interfaces.Repository;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FightsContest.Infrastucture.Repository
{
    public class FightersRepository : BaseRepository, IFightersRepository
    {
        private readonly IFightersConfig _config;
        public FightersRepository(IFlurlClientFactory flurlFac, IFightersConfig config) : base(flurlFac, config)
        {
            _config = config;
        }

        public List<Fighter> Get()
        {

            try
            {
                using (CancellationTokenSource cn = new CancellationTokenSource())
                {
                    cn.CancelAfter(Convert.ToInt32(_config.Get("TimeOutCancellationToken")));
                    return GetAsync<List<Fighter>>(cn.Token, _config.Get("FightersGet")).GetAwaiter().GetResult();
                }

            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
