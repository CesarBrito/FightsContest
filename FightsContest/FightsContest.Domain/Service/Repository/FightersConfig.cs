using FightsContest.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Service.Repository
{
    public class FightersConfig: BaseConfig, IFightersConfig
    {
        public FightersConfig(IConfiguration configuration): base(configuration)
        {
            UrlBase = Get("FightersBase");
        }
    }
}
