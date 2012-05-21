using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using PlaceHolder;

namespace Agregation
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file


    //Class that 
    public class Agregate
    {
        private static List<Node> _nodeList = new List<Node>(); //list of normal nodes
        private static List<Node> _crossNodeList = new List<Node>(); //list of nodes that have location specified in two networks

        private Settings _settings = new Settings();


        private static List<List<Node>> _nodeListCollection = new List<List<Node>>();

        private ModularIO IO; //class for handling plugin methods

        public Agregate()
        {
            //populate nodelistcollection with 3 basic nodelists
            _nodeListCollection.Add(_nodeList);
            _nodeListCollection.Add(_crossNodeList);

            IO = new ModularIO();

            _nodeListCollection = IO.GetNodesCollection.ReturnNodes(_nodeListCollection);
            
        }

        /// <summary>
        /// basic get template
        ///  </summary>
        /// <returns>First Collection of nodes in XML</returns>
        [WebGet(UriTemplate = "xml/")]
        public List<Node> GetCollection()
        {
            return _nodeListCollection[0]; //returning resultNodes
        }

        /// <summary>
        /// basic get template
        /// </summary>
        /// <returns>First Collection of nodes in JSON</returns>
        [WebGet(UriTemplate = "json/")]
        public List<Node> GetJsonCollection()
        {
            WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            return _nodeListCollection[0];
        }

        /// <summary>
        /// Get template for returning specific node
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NetworkID"></param>
        /// <returns>Node in json syntax</returns>
        [WebGet(UriTemplate = "json/{ID};{NetworkID}")]
        public Node GetJsonNode(string ID, string NetworkID)
        {
            int nodeID;
            int nodeNetworkID;

            Int32.TryParse(ID, out nodeID);
            Int32.TryParse(NetworkID, out nodeNetworkID);
            WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;

            

            foreach (var list in _nodeListCollection)
            {
                foreach (var node in list)
                {
                    if (node.ID == nodeID)
                        if (node.SensorNetworkID == nodeNetworkID)
                        {
                            return node;// IO.GetNode.ReturnNode(node, node.ID, node.SensorNetworkID);
                            
                        }
                }
            }

            return null;
        }

        /// <summary>
        ///Get template for returning specific node
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NetworkID"></param>
        /// <returns>Node in XML syntax</returns>
        [WebGet(UriTemplate = "xml/{ID};{NetworkID}")]
        public Node GetXMLNode(string ID, string NetworkID)
        {
            int nodeID;
            int nodeNetworkID;

            Int32.TryParse(ID, out nodeID);
            Int32.TryParse(NetworkID, out nodeNetworkID);

            foreach (var list in _nodeListCollection) //searching for node in collection
            {
                foreach (var node in list)
                {
                    if (node.ID == nodeID)
                        if (node.SensorNetworkID == nodeNetworkID)
                        {   //when found, we actualize node posisition
                            return  IO.GetNode.ReturnNode(node, node.ID, node.SensorNetworkID);
                        }
                }
            }

            return null;
        }



         /// <summary>
        /// creating nodes with positions in 2 networks or with gps position
        /// </summary>am>
        /// <returns>ID of node in nodeList</returns>
        [WebInvoke(UriTemplate = "{id};{networkID};{secondaryNetworkID};{xPos};{yPos};{zPos};{secondaryXpos};{secondaryYpos};{secondaryZpos};{gps};{gpsType}", Method = "POST")]
        public void CompleteCreate(string id, string networkID, string secondaryNetworkID, string xPos, string yPos, string zPos, string secondaryXPos, string secondaryYPos, string secondaryZPos, string gps, string gpsType)
        {
            int ident, networkIdent, secondaryNetworkIdent;
            double xPosition, yPosition, zPosition, secondaryXPosition, secondaryYPosition, secondaryZPosition;

            Int32.TryParse(id, out ident);
            Int32.TryParse(networkID, out networkIdent);
            Int32.TryParse(secondaryNetworkID, out secondaryNetworkIdent);

            Double.TryParse(xPos, out xPosition);
            Double.TryParse(yPos, out yPosition);
            Double.TryParse(zPos, out zPosition);

            Double.TryParse(secondaryXPos, out secondaryXPosition);
            Double.TryParse(secondaryYPos, out secondaryYPosition);
            Double.TryParse(secondaryZPos, out secondaryZPosition);

            Node node = new Node(ident, networkIdent, xPosition, yPosition, zPosition, gps,gpsType ,secondaryXPosition, secondaryYPosition, secondaryZPosition,secondaryNetworkIdent);
            _crossNodeList.Add(node);
            _nodeList.Add(node);
        }

        /// <summary>
        /// creating nodes with position in only one network
        /// </summary>
        /// <param name="networkID"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="zPos"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "{id};{networkID};{xPos};{yPos};{zPos}", Method = "POST")]
        public string SimpleCreate(string id,string networkID, string xPos, string yPos, string zPos)
        {
           
            int ident, networkIdent;
            double xPosition, yPosition, zPosition;
            Int32.TryParse(networkID, out networkIdent);
            Int32.TryParse(id, out ident);

            Double.TryParse(xPos, out xPosition);
            Double.TryParse(yPos, out yPosition);
            Double.TryParse(zPos, out zPosition);


            Node node = new Node(ident, networkIdent, xPosition, yPosition, zPosition);

            _nodeList.Add(node);
            return id;
        }


        /// <summary>
        /// Updating node
        /// </summary>
        /// <param name="id"></param>
        /// <param name="networkID"></param>
        /// <param name="secondaryNetworkID"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="zPos"></param>
        /// <param name="secondaryXPos"></param>
        /// <param name="secondaryYPos"></param>
        /// <param name="secondaryZPos"></param>
        /// <param name="gps"></param>
        /// <param name="gpsType"></param>
        /// <returns> OK in case of success, NOT FOUND in case node is not found</returns>
        [WebInvoke(UriTemplate = "{id};{networkID};{secondaryNetworkID};{xPos};{yPos};{zPos};{secondaryXpos};{secondaryYpos};{secondaryZpos};{gps};{gpsType}", Method = "PUT")]
        public string updateNode(string id, string networkID, string secondaryNetworkID, string xPos, string yPos, string zPos, string secondaryXPos, string secondaryYPos, string secondaryZPos, string gps, string gpsType)
        {

            int ident, networkIdent, secondaryNetworkIdent;
            double xPosition, yPosition, zPosition, secondaryXPosition, secondaryYPosition, secondaryZPosition;

            Int32.TryParse(id, out ident);
            Int32.TryParse(networkID, out networkIdent);
            Int32.TryParse(secondaryNetworkID, out secondaryNetworkIdent);

            Double.TryParse(xPos, out xPosition);
            Double.TryParse(yPos, out yPosition);
            Double.TryParse(zPos, out zPosition);

            Double.TryParse(secondaryXPos, out secondaryXPosition);
            Double.TryParse(secondaryYPos, out secondaryYPosition);
            Double.TryParse(secondaryZPos, out secondaryZPosition);

            foreach (var list in _nodeListCollection) //searching for node in collection
            {
                foreach (var node in list)
                {
                    if (node.ID == ident)
                        if (node.SensorNetworkID == networkIdent)
                        {   //when found, we actualize node posisition
                            node.XPos = xPosition;
                            node.YPos = yPosition;
                            node.ZPos = zPosition;
                            node.XPosSecondary = secondaryXPosition;
                            node.YPosSecondary = secondaryYPosition;
                            node.ZPosSecondary = secondaryZPosition;
                            node.GlobalPositionValue = gps;
                            node.GLobalPositionType = gpsType;

                            return "OK";
                        }
                }
            }
            return "NOT FOUND";
        }

        /// <summary>
        /// Deleting Node
        /// </summary>
        /// <param name="id"></param>
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            int identification;
            Int32.TryParse(id, out identification);
            _nodeList.RemoveAt(_nodeList.FindIndex((m => m.ID.Equals(identification)))); //removing entry from list     
        }

        /// <summary>
        /// generating new id for each node, checking if it doesnt exist within list yet
        /// </summary>
        /// <returns>new ID</returns>
        public string GenerateID()
        {
            string id = null;
            while(id == null)
            {
                id = System.Web.Security.Membership.GeneratePassword(6, 0);
            }
            return id;
        }
    }
}
