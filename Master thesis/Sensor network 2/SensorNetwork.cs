﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace SensorNetwork
{
    // Deploying the service: Publish it to the inetput/wwwroot directory. in IIS admin set it as application and set it as .net 4 app.
    // Also do not forget to create an user rights for IIS
    // Last step is to install net 4. http://stackoverflow.com/questions/4890245/how-to-add-asp-net-4-0-as-application-pool-on-iis-7-windows-7
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class SensorNetwork
    {
        List<Node> _nodeList = new List<Node>();
        Settings values = new Settings();
        
        //default constructor
        //constructing sensor network with 10 nodes and if set, we add nodes which are in both networks
        public SensorNetwork()
        {
            int NodeCount = values.GetInitialNodeCount();
            int crossNetworkNodeCount = values.GetCrossNetworkNodeCount();
            
            string temp = values.getAnything("secondaryNetworkID");
            int secondaryNetworkID;
            Int32.TryParse(temp, out secondaryNetworkID);

            temp = values.getAnything("GlobalPosNodeCount");
            int globalNodeCount;
            Int32.TryParse(temp, out globalNodeCount);

            string globalString = "Global Position - 0";
            string localString = "Local Position - 0";
            string globalPos;
            string localPosString;
            string globalPosType = values.getAnything("Global Position type");
            int networkID = values.GetNetworkID();

            for (int i = 0; i < globalNodeCount; i++)
            {
                globalPos = values.getAnything(globalString);
                localPosString = values.getAnything(localString);
                double[] localPos = returnLocalPos(localPosString);

                globalString = globalString.Replace((i).ToString(), (i + 1).ToString());
                localString = localString.Replace((i).ToString(), (i + 1).ToString());
                Node crossNode = new Node(i + NodeCount, networkID, localPos[0], localPos[1], 0, globalPos, globalPosType);
                _nodeList.Add(crossNode);
            }


            for (int i = 0; i < NodeCount ; i++)
            {
                
                Node initialNode = new Node(i,networkID);
                System.Threading.Thread.Sleep(10);//generating random numbers in same milisecond returns same numbers
                _nodeList.Insert(0,initialNode);
            }
            for (int i = 0; i < crossNetworkNodeCount;i++ )
            {
                Node crossNode = new Node(i + NodeCount, networkID, secondaryNetworkID, i, i, i,i + 2, i + 3, i + 4); //
                _nodeList.Add(crossNode);
            }


            int test = 0;

                
        }

        public double[] returnLocalPos(string value)
        {
            double[] localPos = new double[2];

            string temp = value.Substring(0, value.IndexOf(";"));

            Double.TryParse(temp, out localPos[0]);

            temp = value.Substring(value.IndexOf(";") + 1, value.Length - value.IndexOf(";") - 1);

            Double.TryParse(temp, out localPos[1]);
            return localPos;
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
                var log = new Log(zeroSize.ToString(),values.GetLogPath()); //writing exception to log file
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

            if (_nodeList.Count < values.GetMaxNodeCount())
            {
                Node sensorNode = new Node(_nodeList.Count + 1, 0);
                _nodeList.Add(sensorNode);
                return sensorNode.ID;
            }
            else
            {
                Log log = new Log(nodeCount.ToString(),values.GetLogPath()); //writing exception to log file
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

            try
            {
                int count = Int32.Parse(addNumber);
                int[] array = new int[count];
                Exception nodeCount = new Exception("Too many nodes in network");
                for (int i = 0; i < count; i++)
                {
                    if (_nodeList.Count < values.GetMaxNodeCount())
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
                var log = new Log(except.ToString(),values.GetLogPath()); //writing exception to log file
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
                var log = new Log(except.ToString(),values.GetLogPath()); //writing exception to log file
                return null;
            }

        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public Node UpdateNode(string id, Node instance)
        {
            // TODO: Update the given instance of Node in the collection
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "DELETE")]
        public void DeleteNode()
        {
            Exception zeroSize = new Exception( "There are no nodes in network to remove");
            try
            {
                _nodeList.RemoveAt(_nodeList.Count - 1);

            }
            catch(Exception except)
            {
                var log = new Log(except.ToString(),values.GetLogPath()); //writing exception to log file
            }
        }


    }

   
}
