using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace SensorNetwork
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of SensorNetwork by replacing the "SensorNetwork" string below
            RouteTable.Routes.Add(new ServiceRoute("SensorNetwork", new WebServiceHostFactory(), typeof(SensorNetwork)));
        }
    }
}
