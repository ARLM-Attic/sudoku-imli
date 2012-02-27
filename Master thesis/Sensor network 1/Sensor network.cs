﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Sensor_network_1
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class gpsNetwork
    {
        // TODO: Implement the collection resource that will contain the SampleItem instances
        private List<gpsNode> nodeList = new List<gpsNode>();

        [WebGet(UriTemplate = "")]
        public List<gpsNode> GetCollection()
        {
            // TODO: Replace the current implementation to return a collection of SampleItem instances
            return nodeList;
        }

        [WebInvoke(UriTemplate = "", Method = "POST")]
        public void Create()
        {
            Random rand = new Random(2);
            gpsNode newNode = new gpsNode(nodeList.Count);//starting with default gps coordinates
            newNode.changeCoordinates(rand.NextDouble() * 10, rand.NextDouble() * 10); //initially moving nodes around
            nodeList.Add(newNode);
        }

        [WebGet(UriTemplate = "{id}")]
        public string[] Get(string id)
        {
            try
            {
                int identification = Int32.Parse(id);

                return nodeList[identification].returnCoordinates();
            }
            catch (Exception except)
            {

                throw except;
            }
        }
        /*
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public node Update(string id, node instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            throw new NotImplementedException();
        }*/

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            Exception zeroSize = new Exception("There are no nodes in network to remove");
            try
            {
                nodeList.RemoveAt(nodeList.Count);

            }
            catch (Exception)
            {
                throw zeroSize;
            }
        }
    }

}

