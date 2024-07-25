namespace LocationRisk.Model
{
    public class Analysis
    {
        //instancia
        private static Analysis _instance;
        private static readonly object _lock = new object();

        public List<AnalysedResult> Results { get; set; } = new();
        public int distance { get; set; } = -1;

        private Analysis()
        {
            var data = LocationRisk.Functions.Database.LoadResults(10);
            foreach (var item in data)
            {
                Results.Add(new AnalysedResult { Image = "Images/Dom.svg", Status = item.Status ?? 1, Text = item.Text, Title = item.Title, Distance = item.Distance ?? 0});
            }
        }

        public static Analysis Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Analysis();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
