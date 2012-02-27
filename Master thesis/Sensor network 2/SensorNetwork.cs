using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Sensor_network_2
{
    // Deploying the service: Publish it to the inetput/wwwroot directory. in IIS admin set it as application and set it as .net 4 app.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class SensorNetwork
    {
        List<Node> _nodeList = new List<Node>();
        
        public SensorNetwork()
        {
            Node a = new Node(0);
            _nodeList.Add(a);
        }

        /// <summary>
        /// Getting list of all nodes within sensor network
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "")]
        public List<Node> GetCollection()
        {
            Exception zeroSize = new Exception("There are no nodes in network");

            if (_nodeList.Count > 0)
            {
                return _nodeList;
            }
            else throw zeroSize;
            
        }

        /// <summary>
        /// adding node to the sensor network
        /// </summary>
        /// <returns></returns>
        [WebInvoke(Method = "POST")]
        public int AddNode()
        {
            Exception nodeCount = new Exception("Too many nodes in network");

            if (_nodeList.Count < NetworkVariables.MaxNodeCount)
            {
                Node sensorNode = new Node(_nodeList.Count + 1);
                _nodeList.Add(sensorNode);
                return sensorNode.Id;
            }
            else throw nodeCount;

        }

        /// <summary>
        /// adding number of nodes to the sensor network specified in addNumber variable
        /// </summary>
        /// <returns></returns>
        [WebInvoke(Method = "POST",UriTemplate = "{addNumber}")]
        public int[] AddNodes(string addNumber)
        {
            try
            {
                int count = Int32.Parse(addNumber);
                int[] array = new int[count];
                Exception nodeCount = new Exception("Too many nodes in network");
                for (int i = 0; i < count; i++)
                {
                    if (_nodeList.Count < NetworkVariables.MaxNodeCount)
                    {
                        Node sensorNode = new Node(_nodeList.Count + 1);
                        _nodeList.Add(sensorNode);
                        array[i] = sensorNode.Id;
                    }
                    else throw nodeCount;
                }
                return array;
            }
            catch(Exception excp)
            {
                //add exception handling
            }

            return null;
        }

        
        /// <summary>
        /// retreiving node position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "{id}")]
        public string GetNode(string id)
        {
            try
            {
                int identification = Int32.Parse(id) - 1;
                
                _nodeList[identification].ChangePosition();
                string tempString = Math.Round(_nodeList[identification].XPos,2) + ";" + Math.Round(_nodeList[identification].YPos,2);

                return tempString;
            }
            catch (Exception except)
            {
                return except.ToString();
                //throw except;
            }
           // return "aa";

        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public Node Update(string id, Node instance)
        {
            // TODO: Update the given instance of Node in the collection
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "DELETE")]
        public void Delete()
        {
            Exception zeroSize = new Exception( "There are no nodes in network to remove");
            try
            {
                _nodeList.RemoveAt(_nodeList.Count - 1);

            }
            catch(Exception)
            {
                throw zeroSize;
            }
        }

    }
}
