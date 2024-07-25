using FisSst.BlazorMaps;

namespace LocationRisk.Model
{
    public class Home
    {
        private static Home _instance;
        private static readonly object _lock = new object();

        public string? NewAddress { get; set; }
        public string? Address { get; set; }
        public string? SelectedLocation { get; set; }
        public List<Location> Locations { get; set; } = new();
        public List<Location> PossibleLocations { get; set; } = new();
        public List<Route> Routes { get; set; } = new();
        public int Risk {  get; set; }
        public string? ErrorMessage { get; set; }
        public Map MapRef { get; set; }
        public List<Marker> Markers { get; set; } = new List<Marker>();
        public Dictionary<Polygon, List<Coordinates>> Polygons { get; set; } = new();
        public Marker MarkerWithOptions { get; set; }
        public LatLng MarkerWithOptionsLatLng { get; set; }
        public Object Chosen { get; set; }


        private Home()
        {
            NewAddress = null;
            Address = null;
            Locations = new List<Location>();
            ErrorMessage = null;
            MapRef = null;
            Markers = new List<Marker>();
            Polygons = new Dictionary<Polygon, List<Coordinates>>();
            MarkerWithOptions = null;
            MarkerWithOptionsLatLng = null;
            Chosen = null;
        }

        public static Home Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Home();
                        }
                    }
                }
                return _instance;
            }
        }

    }

}
