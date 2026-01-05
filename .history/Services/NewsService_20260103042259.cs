using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infeubackend.Interfaces;

namespace infeubackend.Services
{
    public class NewsService: INewsService
    {
        private readonly HttpClient httpClient;

        public NewsService(HttpClient _httpclient)
        {
            _httpclient = httpClient;
        }

        public Task<byte[]>GetAllNews()
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