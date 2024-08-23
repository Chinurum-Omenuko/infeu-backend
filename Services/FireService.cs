using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infeubackend.Interfaces;
using infeubackend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace infeubackend.Services
{
    public class FireService: IFireService
    {
        private readonly HttpClient _httpClient;

        public FireService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.Timeout = TimeSpan.FromSeconds(120);
            
        }

        public async Task<byte[]> GetAllFires()
        {
           
            try
            {
                var url = "https://eonet.gsfc.nasa.gov/api/v3/events?category=wildfires";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
                string responseContent = await reader.ReadToEndAsync();
               
                // Parsing the body to extract JSON String
                // string responseContent = await response.Content.ReadAsStringAsync();

                // Decoding string to JSON object for manipulation
                JObject EONETEVENTS;
                try
                {
                    EONETEVENTS = JObject.Parse(responseContent);
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine($"Failed to parse JSON: {ex.Message}");
                    return new byte[0];
                }               

                // Get the events array by extracting
                JArray allWildFires = (JArray)EONETEVENTS["events"];

                

                List<Dictionary<string, object>> fireGeoLocations = new List<Dictionary<string, object>>(); 

                foreach (JObject wildfire in allWildFires)
                {
                    string location = wildfire["title"].ToString();
                    JToken coordinatesToken = wildfire["geometry"][0]["coordinates"];
                    float[] coordinates = coordinatesToken.ToObject<float[]>();

                    Dictionary<string, object> info = new Dictionary<string, object>()
                    {
                        ["location"] = location,
                        ["coordinates"] = coordinates
                    };

                    fireGeoLocations.Add(info);
                }

                string jsonPayload = JsonConvert.SerializeObject(fireGeoLocations);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);

                return jsonBytes;
            }
            catch(HttpRequestException exception)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ",exception.Message);
                return null;
            }

        }
    }
}