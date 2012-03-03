using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace SensorNetwork
{
    // Deploying the service: Publish it to the inetput/wwwroot directory. in IIS admin set it as application and set it as .net 4 app.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class SensorNetwork
    {
        List<Node> _nodeList = new List<Node>();
        
        //default constructor
        //constructing sensor network with 10 nodes
        public SensorNetwork()
        {
            var values = new NetworkVariables();

            for (int i = 0; i < values.InitialNodeCount ; i++)
            {
                Node initialNode = new Node(i,0);
                _nodeList.Add(initialNode);
            }
            Node crossNode = new Node(10, 0, 0, 0, 0, "test");
            _nodeList.Add(crossNode);
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
            else
            {
                var log = new Log(zeroSize.ToString()); //writing exception to log file
                return null;
            }
        }

        /// <summary>
        /// adding node to the sensor network
        /// </summary>
        /// <returns></returns>
        [WebInvoke(Method = "POST")]
        public int AddNode()
        {
            Exception nodeCount = new Exception("Too many nodes in network");
            var values = new NetworkVariables();

            if (_nodeList.Count < values.MaxNodeCount)
            {
                Node sensorNode = new Node(_nodeList.Count + 1, 0);
                _nodeList.Add(sensorNode);
                return sensorNode.ID;
            }
            else
            {
                Log log = new Log(nodeCount.ToString()); //writing exception to log file
                return -1;
            }
        }

        /// <summary>
        /// adding number of nodes to the sensor network specified in addNumber variable
        /// </summary>
        /// <returns></returns>
        [WebInvoke(Method = "POST",UriTemplate = "{addNumber}")]
        public int[] AddNodes(string addNumber)
        {

            var values = new NetworkVariables();
            try
            {
                int count = Int32.Parse(addNumber);
                int[] array = new int[count];
                Exception nodeCount = new Exception("Too many nodes in network");
                for (int i = 0; i < count; i++)
                {
                    if (_nodeList.Count < values.MaxNodeCount)
                    {
                        Node sensorNode = new Node(_nodeList.Count + 1,0);
                        _nodeList.Add(sensorNode);
                        array[i] = sensorNode.ID;
                    }
                    else throw nodeCount;
                }
                return array;
            }
            catch(Exception except)
            {
                var log = new Log(except.ToString()); //writing exception to log file
            }

            return null;
        }

        
        /// <summary>
        /// retreiving node position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "{id}")]
        public Node GetNode(string id)
        {
            try
            {
                int identification = Int32.Parse(id);
                _nodeList[identification].ChangePosition();
                return _nodeList[identification];
            }
            catch (Exception except)
            {
                var log = new Log(except.ToString()); //writing exception to log file
                return null;
            }

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
            catch(Exception except)
            {
                var log = new Log(except.ToString()); //writing exception to log file
            }
        }



    }
    public class NetworkVariables
    {
        //Default settings
        public int NetworkAreaSize = 64;
        public int MaxNodeCount = 64;
        public int NetworkID;
        public int InitialNodeCount = 10;

        public NetworkVariables()
        {
            try
            {
                StreamReader sr = new StreamReader("App_Data/ServiceSettings");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("NetworkAreaSize"))
                        NetworkAreaSize = Int32.Parse(line.Remove(0, line.LastIndexOf("=")));
                    if (line.Contains("NetworkMaxNodeCount"))
                        MaxNodeCount = Int32.Parse(line.Remove(0, line.LastIndexOf("=")));
                    if (line.Contains("NetworkID"))
                        NetworkID = Int32.Parse(line.Remove(0, line.LastIndexOf("=")));
                    if (line.Contains("InitialNodeCount"))
                        InitialNodeCount = Int32.Parse(line.Remove(0, line.LastIndexOf("=")));
                    var log = new Log("jsem tu");
                }
            }
            catch (Exception except)
            {
                var log = new Log(except.ToString()); //writing exception to log file
            }

        }
    }
}
