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
        List<Node> _nodeList = new List<Node>();
        List<string> usedIDs = new List<string>();
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = "")]
        public List<Node> GetCollection()
        {
            return _nodeList;
        }

        /// <summary>
        /// creating nodes with positions in 2 networks or with gps position
        /// </summary>am>
        /// <returns>ID of node in nodeList</returns>
        [WebInvoke(UriTemplate = "{id};{networkID};{secondaryNetworkID};{xPos};{yPos};{zPos};{secondaryXpos};{secondaryYpos};{secondaryZpos};{gps}", Method = "POST")]
        public int CompleteCreate(string networkID,string secondaryNetworkID, string xPos, string yPos, string zPos, string secondaryXPos, string secondaryYPos, string secondaryZPos, string gps)
        {
            int ident, networkIdent, secondaryNetworkIdent;
            double xPosition, yPosition, zPosition, secondaryXPosition, secondaryYPosition, secondaryZPosition;

            string id = GenerateID();
            Int32.TryParse(networkID, out networkIdent);
            Int32.TryParse(secondaryNetworkID, out secondaryNetworkIdent);

            Double.TryParse(xPos, out xPosition);
            Double.TryParse(yPos, out yPosition);
            Double.TryParse(zPos, out zPosition);

            Double.TryParse(secondaryXPos, out secondaryXPosition);
            Double.TryParse(secondaryYPos, out secondaryYPosition);
            Double.TryParse(secondaryZPos, out secondaryZPosition);

            Node node = new Node(id, networkIdent, xPosition, yPosition, zPosition, gps, secondaryXPosition, secondaryYPosition, secondaryZPosition,secondaryNetworkIdent);

            _nodeList.Add(node);

           
           
            // TODO: Add the new instance of SampleItem to the collection))))
            throw new NotImplementedException();
        }

        /// <summary>
        /// creating nodes with position in only one network
        /// </summary>
        /// <param name="networkID"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="zPos"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "{networkID};{xPos};{yPos};{zPos}", Method = "POST")]
        public string SimpleCreate(string networkID, string xPos, string yPos, string zPos)
        {
            string id = GenerateID();
            int ident, networkIdent;
            double xPosition, yPosition, zPosition;
            Int32.TryParse(networkID, out networkIdent);

            Double.TryParse(xPos, out xPosition);
            Double.TryParse(yPos, out yPosition);
            Double.TryParse(zPos, out zPosition);


            Node node = new Node(id, networkIdent, xPosition, yPosition, zPosition);

            _nodeList.Add(node);
            return id;
        }

        [WebGet(UriTemplate = "{id};{test}")]
        public string Get(string id)
        {
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
            // TODO: Remove the instance of SampleItem with the given id from the collection
            throw new NotImplementedException();
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
                if (usedIDs.IndexOf(id) != -1) id = null;  
            }
            return id;
        }



    }
}
