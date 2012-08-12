using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AddressBook
{
    /// <summary>
    /// Class which keeps information about Persons and their adresses, its responsible for adding/deleting/updating persons and 
    /// theirs adresses/ic informations. All input validation is handled here, also all exceptions from database layer are handled here
    /// </summary>
    public class ObjectLayer
    {
        private BindingList<Person> _persons = new BindingList<Person>(); //private list of persons, Binding list is used because all changes to list are
                                                                          //visible to datagridview of presentation layer immidately.
        DataLayer data = new DataLayer(); //object of datalayer, used to inserting/deleting/updating persons/adresses/ic informations

        public BindingList<Person> Persons //public property used to access Person list
        {
            get { return _persons; }
        }

        /// <summary>
        /// Constructor for this class, calls datalayer object to load all information about persons into _persons list,
        /// then proceeded and loads all informations 
        /// </summary>
        public ObjectLayer()
        {
           
            _persons = data.SelectAllPersons(_persons);
            foreach (var person in _persons)
            {
                data.SelectAdresses(person);//loading adresses from database
                data.SelectIc(person); //loading icinfo from database
            }
        }

        /// <summary>
        /// Addding a person to list and passing persons info to database
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="surname">Surname of person</param>
        /// <param name="ic">Identification number of company</param>
        /// <param name="dic">Identification number of company for tax purposes</param>
        /// <returns>Error message if input is incorrect</returns>
        public string AddPerson(string name, string surname, string ic, string dic)
        {
            int tempIc, tempDic;
            string result = CheckPersonParameters(name, surname, ic, dic); //checking if persons informations are valid

            if (result != "") return result; //if they arent valid, return error message

            //parsing dic and ic
            Int32.TryParse(ic, out tempIc); 
            Int32.TryParse(dic, out tempDic);

            //creating new instance of person with given information
            Person tempPerson = new Person(name, surname, tempIc, tempDic);

            //loading information about ic
            tempPerson = loadIcInfo(tempPerson);

            try //trying to insert person and icinfo into database
            {
                int id = data.InsertPerson(tempPerson.Name, tempPerson.Surname, tempPerson.IC, tempPerson.DIC);
                int icId = data.InsertIco(tempPerson.ICInfo.CompanyName, tempPerson.ICInfo.DateCreated,
                                          tempPerson.ICInfo.DateValid,tempPerson.PersonID);
                if (id == 0) Log("Unable to Insert Person into database");//if Insertperson returns 0, it means that person wasnt inserted so we log it
                                                                        
                else if(icId == 0 )Log("Unable to Insert IC into database");//same as above, but for IcInfo
                else //if everything went fine, we add ids of inserted person/icinfo to the person object
                {
                    tempPerson.PersonID = id;
                    tempPerson.ICInfo.icID = icId;
                    _persons.Add(tempPerson); //as last thing we insert person object into bindinglist
                }

            }
            catch (Exception except)
            {
                Log(except.ToString());
            }

            return "";
        }

        /// <summary>
        /// Updating existing person both in list and database
        /// </summary>
        /// <param name="ID">ID of Person in Database</param>
        /// <param name="name">person's new name</param>
        /// <param name="surname">person's new surname</param>
        /// <param name="ic">New identification number of company</param>
        /// <param name="dic">New identification number of company for tax purposes</param>
        /// <returns>Error message if input is incorrect</returns>
        public string UpdatePerson(string ID, string name, string surname, string ic, string dic)
        {
            int tempIc, tempDic, PersonID;
            string result = CheckPersonParameters(name, surname, ic, dic); //checking if new persons informations are valid

            if (result != "") return result;//if they arent valid, return error message

            Int32.TryParse(ic, out tempIc); 
            Int32.TryParse(dic, out tempDic);
            Int32.TryParse(ID, out PersonID);

            try //trying to update both database and object person with given id
            {
                data.UpdatePerson(PersonID, name, surname, tempIc, tempDic); //updating person's info in database
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == ID); //searching for person object within bindinglist with selected ID
                tempPerson.Name = name;
                tempPerson.Surname = surname;
                tempPerson.IC = tempIc;
                tempPerson.DIC = tempDic;
                if(tempIc != 0) tempPerson = loadIcInfo(tempPerson); 
            }
            catch (Exception except)
            {
                Log(except.ToString());
            }
            return ""; //if everything went fine, we return emtpy string instead of error message
        }

        /// <summary>
        /// Deleting person from binding list and database
        /// </summary>
        /// <param name="ID">ID of Person in Database</param>
        public void DeletePerson(string ID)
        {
            int personID;
            Int32.TryParse(ID, out personID);
            try
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == ID.ToString());//searching for person object within bindinglist with selected ID
                data.DeletePerson(personID);
                _persons.Remove(tempPerson);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        /// <summary>
        /// Adding adress to the database and to the person object
        /// </summary>
        /// <param name="street">City name</param>
        /// <param name="city">Adress name</param>
        /// <param name="psc">Area code</param>
        /// <param name="personID">ID of Person in Database</param>
        /// <returns>Error message if input is incorrect</returns>
        public string AddAdress(string street, string city, string psc, string personID)
        {
            int tempPsc = 0;
            int tempPersonID;
            if (psc != "")//validity check of PSC
            {
                if (!Int32.TryParse(psc, out tempPsc)) return "PSČ musí být číslo";
            }
            Int32.TryParse(personID, out tempPersonID);

            try//trying to add Adress to the database and person object
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == tempPersonID.ToString()); //seraching for Person object in list by its id
                Adress tempAdress = new Adress(street, city, tempPsc, tempPersonID); //creating new adress object
                int id = data.InsertAddres(street, city, tempPsc, tempPerson.PersonID); //inserting adress info into database


                if (id == 0) Log("Unable to Insert Adress into database"); //if we are unable to insert into database
                else //else we set adressId and add adress object into person's adresslist
                {
                    tempAdress.AdressID = id;
                    tempPerson.Adresses.Add(tempAdress);
                }
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
            return "";
        }

        /// <summary>
        /// Updating address in database and in person's adresslist
        /// </summary>
        /// <param name="adressID">ID of Adress in Database</param>
        /// <param name="street">Street name</param>
        /// <param name="city">City name</param>
        /// <param name="psc">Area Code</param>
        /// <param name="personID">ID of Person in Database</param>
        /// <returns>Error message if input is incorrect</returns>
        public string UpdateAddress(string adressID, string street, string city, string psc, string personID)
        {
            int tempPsc = 0;
            int tempPersonID;
            if (psc != "")
            {
                if (!Int32.TryParse(psc, out tempPsc)) return "PSČ musí být číslo";
            }
            Int32.TryParse(personID, out tempPersonID);

            try
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == tempPersonID.ToString()); //searching for person in list
                Adress tempAdress = tempPerson.Adresses.Single(a => a.AdressID.ToString() == adressID); //serching for adress in list
                data.UpdateAdress(tempAdress.AdressID, street, city, tempPsc); //updating record in database
                tempAdress.Street = street; //updating adress object
                tempAdress.City = city;
                tempAdress.PSC = tempPsc;
                
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
            return "";
        }

        /// <summary>
        /// Deleting adress from database and from person's adresslist
        /// </summary>
        /// <param name="adressID">ID of adress in Database</param>
        /// <param name="personID">ID of Person in Database</param>
        public void DeleteAdress(string adressID, string personID)
        {
            try 
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == personID); //seraching for person in list
                Adress tempAdress = tempPerson.Adresses.Single(a => a.AdressID.ToString() == adressID); //searching for adress in list
                data.DeleteAdress(tempAdress.AdressID); //deleting record from database
                tempPerson.Adresses.Remove(tempAdress); //removing 
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        /// <summary>
        /// Checking if IC is valid
        /// </summary>
        /// <param name="ic">Identification number of company</param>
        /// <returns>True if valid, false if not valid</returns>
        public bool CheckIC(int ic)
        {
            try
            {
                string uri = "http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + ic; //creating url of request
                XmlTextReader reader = new XmlTextReader(uri); //request for IC data
                reader.MoveToContent(); //moving to content of XML file
                int isValid = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "are:Pocet_zaznamu") //if Element value Pocet_Zaznamu = 0, IC is not valid
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            Int32.TryParse(el.Value, out isValid);
                            if (isValid == 0) return false;
                            else return true;
                            break;
                        }
                    }
                    string attribute = reader.GetAttribute("are:Pocet_zaznamu");
                }
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
            return false;
        }

        /// <summary>
        /// Logging events to file
        /// </summary>
        /// <param name="error">Error message</param>
        public void Log(string error)
        {
            using (StreamWriter log = File.AppendText("log.txt"))
            {
                log.Write(DateTime.Now);
                log.Write(" : ");
                log.Write(error);
                log.Write("\n");
            }
        }

        /// <summary>
        /// Validity check of person's parameters
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="surname">Surname of person</param>
        /// <param name="ic">Identification number of company</param>
        /// <param name="dic">Identification number of company for tax purposes</param>
        /// <returns></returns>
        public string CheckPersonParameters(string name, string surname, string ic, string dic)
        {
            int tempIC = 0;
            int tempDIC;
            if (name == "") return "Jméno musí být vyplněno";
            if (surname == "") return "Příjmení musí být vyplněno";
            if (ic != "")
                if (!Int32.TryParse(ic, out tempIC)) return "IČ musí být číslo";
            if (dic != "")
                if (!Int32.TryParse(dic, out tempDIC)) return "DIČ musí být číslo";
            if (ic != "")
                if (!CheckIC(tempIC)) return "Neplatné IČ";

            return "";
        }

        /// <summary>
        /// Loading info about company from identification number
        /// </summary>
        /// <param name="tempPerson"></param>
        /// <returns></returns>
        public Person loadIcInfo(Person tempPerson)
        {
            if (tempPerson.IC != 0)
            {
                string uri = "http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + tempPerson.IC; //creating request
                XmlTextReader reader = new XmlTextReader(uri); //request
                reader.MoveToContent(); //moving to content

                string companyName = "";
                string dateCreated = "";
                string dateValid = "";

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element) 
                    {

                        if (reader.Name == "are:Datum_vzniku") //Date of company creating
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            dateCreated = el.Value;
                        } 
                        if (reader.Name == "are:Datum_platnosti")//Date of IC validity
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            dateValid = el.Value;
                        }
                        if (reader.Name == "are:Obchodni_firma") //Name of Company
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            companyName = el.Value;
                            break;
                        }
                    }
                }
                ICO tempIco = new ICO(dateCreated,dateValid,companyName); //creating ico Object
                tempPerson.ICInfo = tempIco;
            }
            else
            {
                ICO tempIco = new ICO("","",""); //if we are unable to download XML file with information, everything is set to emtpy string
                tempPerson.ICInfo = tempIco; //setting icinfo object into Person object
            }

            return tempPerson;

        }
    }
}
