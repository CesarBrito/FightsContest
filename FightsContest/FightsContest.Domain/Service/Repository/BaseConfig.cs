using FightsContest.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;

namespace FightsContest.Domain.Service.Repository
{
    public abstract class BaseConfig : IConfig
    {
        private readonly IConfiguration _configuration;
        public string UrlBase { get; set; }
        public int TimeOut { get; set; }
        public int TimeOutCancellation { get; set; }
        public object Headers { get; set; }

        public BaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            TimeOut = Convert.ToInt32(Get("TimeOut"));
            TimeOutCancellation = Convert.ToInt32(Get("TimeOutCancellationToken"));
        }

        public string Get(string configuration)
        {
            return _configuration[configuration];            
        }
    }
}
