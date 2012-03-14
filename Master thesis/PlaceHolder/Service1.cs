using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace PlaceHolder
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class Combine
    {
        private readonly List<Node> _nodeList = new List<Node>(); //list of normal nodes
        private List<Node> _crossNodeList = new List<Node>(); //list of nodes that have location specified in two networks

        //private readonly List<string> _usedIDs = new List<string>(); obsolete
        private Settings _settings = new Settings();


        private List<Node> _resultNodes = new List<Node>();
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = "")]
        public string GetCollection()
        {
           // CombineNetworks();
           // return _resultNodes;
            return "a";
        }

        [WebGet(UriTemplate = "{x},{y}")]
        public string A(string x, string y)
        {
            double a, b;
            int a1 = 0;
            int b1 = 0;
            Double.TryParse(x, out a);
            Double.TryParse(y, out b);


            double x1, x2;
            double inputAngle = (Math.PI/180)*90;
            x1 = Math.Cos(inputAngle) * a + Math.Sin(inputAngle) * b + a1;
            x2 = -Math.Sin(inputAngle) * a + Math.Cos(inputAngle) * b + b1;
            
            
            
           

            return x1 +" : " +x2;
        }
                /// <summary>
        /// creating nodes with positions in 2 networks or with gps position
        /// </summary>am>
        /// <returns>ID of node in nodeList</returns>
        [WebInvoke(UriTemplate = "{id};{networkID};{secondaryNetworkID};{xPos};{yPos};{zPos};{secondaryXpos};{secondaryYpos};{secondaryZpos};{gps}", Method = "POST")]
        public void CompleteCreate(string id,string networkID,string secondaryNetworkID, string xPos, string yPos, string zPos, string secondaryXPos, string secondaryYPos, string secondaryZPos, string gps)
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

            Node node = new Node(ident, networkIdent, xPosition, yPosition, zPosition, gps, secondaryXPosition, secondaryYPosition, secondaryZPosition,secondaryNetworkIdent);
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



        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public int Update(string id, Node instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            int identification;
            Int32.TryParse(id, out identification);
            _nodeList.RemoveAt(_nodeList.FindIndex((m => m.ID.Equals(identification)))); //removing entry from list     
        }

        /// <summary>
        /// generating new id for each node, checking if it doesnt exist within list yet - obsolete atm
        /// </summary>
        /// <returns>new ID</returns>
        public string GenerateID()
        {
            string id = null;
            while(id == null)
            {
                id = System.Web.Security.Membership.GeneratePassword(6, 0);
               // if (_usedIDs.IndexOf(id) != -1) id = null;  
            }
            return id;
        }

        public void CombineNetworks()
        {
            if (_crossNodeList.Count < 2)
            {
                var log = new Log("Not enough cross nodes", _settings.GetLogPath());
            }

            foreach (var node in _crossNodeList)
            {
                   
            }
            
        }

    }
}
