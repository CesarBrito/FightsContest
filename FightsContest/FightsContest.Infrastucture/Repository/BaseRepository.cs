using FightsContest.Domain.Interfaces.Repository;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace FightsContest.Infrastucture.Repository
{
    public abstract class BaseRepository
    {
        private readonly IFlurlClient _flurlClient;

        private readonly int _timeOut;

        private readonly object _headers;

        private string AllowHttpStatus;

        public BaseRepository(IFlurlClientFactory flurlFac, IConfig configuration)
        {
            _flurlClient = flurlFac.Get(configuration.UrlBase);

            _timeOut = configuration.TimeOut;

            _headers = configuration.Headers;
        }

        public void SetAllowHttpStatus(string HttpStatus)
        {
            AllowHttpStatus = HttpStatus;
        }
        
        public Task<T> GetAsync<T>(CancellationToken token, string uri)
        {
            IFlurlRequest request = _flurlClient.Request(uri)
                                                .WithTimeout(_timeOut)
                                                .WithHeaders(_headers);

            if (!string.IsNullOrEmpty(AllowHttpStatus))
            {
                request.AllowHttpStatus(AllowHttpStatus);
            }

            return request.GetAsync().ReceiveJson<T>();
        }

    }
}
