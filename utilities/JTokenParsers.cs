using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JTokenParsers
{
    public static class JTokenParsers
    {
        /// <summary>
        /// Parses a JArray of wildfires into a list of dictionaries containing location and coordinate information.
        /// </summary>
        /// <param name="allWildFires">The JArray containing wildfire data.</param>
        /// <returns>A list of dictionaries with location and coordinate information.</returns>
        public static List<Dictionary<string, object>> ToListOfDictionaries(JArray allWildFires)
        {
            var fireGeoLocations = new List<Dictionary<string, object>>();

            foreach (JObject wildfire in allWildFires)
            {
                string location = wildfire["title"].ToString();
                JToken coordinatesToken = wildfire["geometry"][0]["coordinates"];
                float[] coordinates = coordinatesToken.ToObject<float[]>();

                var info = new Dictionary<string, object>()
                {
                    ["location"] = location,
                    ["coordinates"] = coordinates
                };

                fireGeoLocations.Add(info);
            }

            return fireGeoLocations;
        }
    }
}
