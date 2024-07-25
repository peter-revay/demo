using ServiceOpenStreetMap;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;



namespace LocationRisk.Services
{
    public class ServiceAgent
    {
        private static ServiceAgent _singleton = null;
        private static readonly object padlock = new object();

        public BasicHttpBinding Binding { get; set; }
        public System.ServiceModel.EndpointAddress EndpointAdr { get; set; }

        public ServiceAgent()
        {
            this.Binding = new System.ServiceModel.BasicHttpBinding();
           this.Binding.SendTimeout = new TimeSpan(0, 20, 0);
           this.Binding.MaxReceivedMessageSize = 2147483647;
           this.Binding.MaxBufferSize = 2147483647;
           this.Binding.MaxBufferPoolSize = 2147483647;
           this.Binding.ReaderQuotas.MaxDepth = 2147483647;
           this.Binding.ReaderQuotas.MaxStringContentLength = 2147483647;
           this.Binding.ReaderQuotas.MaxArrayLength = 2147483647;
           this.Binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
           this.Binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
           this.Binding.Security.Mode = BasicHttpSecurityMode.None;
           this.Binding.UseDefaultWebProxy = false;

            if (this.EndpointAdr == null)
                this.EndpointAdr = new System.ServiceModel.EndpointAddress(LocationRisk_Variants.Configuration.Services.SERVICE_OPENSTREETMAP);
        }

        public static ServiceAgent Singleton
        {
            get
            {
                lock (padlock)
                {
                    if (_singleton == null)
                    {
                        _singleton = new ServiceAgent();
                    }
                    return _singleton;
                }
            }
        }

        public GeocodeResponse[] GetCoordinates(string address)
             => new ServiceOpenStreetMapClient(Binding, EndpointAdr).GetCoordinatesAsync(address).Result;

        public GetClosestPointResponse GetClosestPoint(GetClosestPointRequest request)
            => new ServiceOpenStreetMapClient(Binding, EndpointAdr).GetClosestPointAsync(request).Result;

    }
}
