using FisSst.BlazorMaps;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LocationRisk.Model
{
    public class Route 
    { 
        public double Distance { get; set; }
        public Polygon Polygon { get; set; }

        public string Text { get; set; }
        public string Title {  get; set; }
        
    }


    public class Coordinates
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
    public class Location
    {
        public string Address { get; set; }
        public Coordinates Coordinates { get; set; }
        public Marker Marker { get; set; }
    }

    public class GeoJsonFeatureCollection
    {
        public string type { get; set; }
        public string name { get; set; }
        public Crs crs { get; set; }
        public Feature[] features { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public CrsProperties properties { get; set; }
    }

    public class CrsProperties
    {
        public string name { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public FeatureProperties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class FeatureProperties
    {
        public int id { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double[]> coordinatesList { get; set; }

        public double[] coordinates { get; set; }
    }
}
