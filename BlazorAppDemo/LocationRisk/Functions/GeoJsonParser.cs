using LocationRisk.Model;
using Newtonsoft.Json;
using System.Text.Json;

namespace LocationRisk.Functions
{
    public class GeoJsonParser
    {

        public static async Task<List<Coordinates>> ParseGeoJsonStringAsync(string jsonString)
        {
            var coordinatesList = new List<Coordinates>();
            GeoJsonFeatureCollection geoJson = null;
            try
            {
                geoJson = System.Text.Json.JsonSerializer.Deserialize<GeoJsonFeatureCollection>(jsonString);
            }catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }

            if (geoJson?.features != null)
            {
                foreach (var feature in geoJson.features)
                {
                    var geometry = feature.geometry;
                    if (geometry != null && geometry.type == "Point")
                    {
                        coordinatesList.Add(new Coordinates { Latitude = geometry.coordinates[1],Longitude = geometry.coordinates[0] });
                    }
                }
            }

            return coordinatesList;
        }
    }
}
