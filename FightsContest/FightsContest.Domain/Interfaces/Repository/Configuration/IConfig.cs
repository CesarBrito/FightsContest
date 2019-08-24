using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Repository
{
    public interface IConfig
    {
        string UrlBase { get; set; }
        int TimeOut { get; set; }
        int TimeOutCancellation { get; set; }
        object Headers { get; set; }

        string Get(string config);
    }
}
