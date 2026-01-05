using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infeubackend.Services
{
    public class NewsService: INewsService
    {
        private readonly HttpClient httpClient;

        public NewsService(HttpClient _httpclient)
        {
            _httpclient = httpClient;
        }

        Task<byte[]>GetNews()
        {
            try
            {
                var url = "https://eonet.gsfc.nasa.gov/api/v3/events?category=wildfires";
            }
            catch
            {

            }
        }
    }
}