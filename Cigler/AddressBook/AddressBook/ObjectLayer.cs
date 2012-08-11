﻿using System;
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
    public class ObjectLayer
    {
        private BindingList<Person> _persons = new BindingList<Person>();
        DataLayer data = new DataLayer();

        public BindingList<Person> Persons
        {
            get { return _persons; }
        }


        public ObjectLayer()
        {
           
            _persons = data.SelectAllPersons(_persons);
            foreach (var person in _persons)
            {
                data.SelectAdresses(person);
                data.SelectIc(person);
            }
        }

        public string AddPerson(string name, string surname, string ic, string dic)
        {
            int tempIc, tempDic;
            string result = CheckPersonParameters(name, surname, ic, dic);

            if (result != "") return result;

            Int32.TryParse(ic, out tempIc);
            Int32.TryParse(dic, out tempDic);


            Person tempPerson = new Person(name, surname, tempIc, tempDic);
            tempPerson = loadIcInfo(tempPerson);

            try
            {
                int id = data.InsertPerson(tempPerson.Name, tempPerson.Surname, tempPerson.IC, tempPerson.DIC);
                int icId = data.InsertIco(tempPerson.ICInfo.CompanyName, tempPerson.ICInfo.DateCreated,
                                          tempPerson.ICInfo.DateValid,tempPerson.PersonID);
                if (id == 0) Log("Unable to Insert Person into database");
                if(icId == 0 )Log("Unable to Insert IC into database");
                else
                {
                    tempPerson.PersonID = id;
                    tempPerson.ICInfo.icID = icId;
                    _persons.Add(tempPerson);
                }

            }
            catch (Exception except)
            {
                Log(except.ToString());
            }

            return "";
        }

        public string UpdatePerson(string ID, string name, string surname, string ic, string dic)
        {
            int tempIc, tempDic, PersonID;
            string result = CheckPersonParameters(name, surname, ic, dic);

            if (result != "") return result;

            Int32.TryParse(ic, out tempIc);
            Int32.TryParse(dic, out tempDic);
            Int32.TryParse(ID, out PersonID);


            try
            {
                data.UpdatePerson(PersonID, name, surname, tempIc, tempDic);
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == ID);
                tempPerson.Name = name;
                tempPerson.Surname = surname;
                tempPerson.IC = tempIc;
                tempPerson.DIC = tempDic;
            }
            catch (Exception except)
            {
                Log(except.ToString());
            }
            return "";
        }

        public void DeletePerson(string ID)
        {
            int personID;
            Int32.TryParse(ID, out personID);
            try
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == ID.ToString());
                data.DeletePerson(personID);
                _persons.Remove(tempPerson);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public string AddAdress(string street, string city, string psc, string personID)
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
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == tempPersonID.ToString());
                Adress tempAdress = new Adress(street, city, tempPsc, tempPersonID);
                int id = data.InsertAddres(street, city, tempPsc, tempPerson.PersonID);


                if (id == 0) Log("Unable to Insert Adress into database");
                else
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

        public string UpdateAdress(string adressID, string street, string city, string psc, string personID)
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
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == tempPersonID.ToString());
                Adress tempAdress = tempPerson.Adresses.Single(a => a.AdressID.ToString() == adressID);
                data.UpdateAdress(tempAdress.AdressID, street, city, tempPsc);
                tempAdress.Street = street;
                tempAdress.City = city;
                tempAdress.PSC = tempPsc;
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
            return "";
        }

        public void DeleteAdress(string adressID, string personID)
        {
            try
            {
                Person tempPerson = Persons.Single(p => p.PersonID.ToString() == personID);
                Adress tempAdress = tempPerson.Adresses.Single(a => a.AdressID.ToString() == adressID);
                data.DeleteAdress(tempAdress.AdressID);
                tempPerson.Adresses.Remove(tempAdress);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public bool CheckIC(int ic)
        {
            try
            {
                string uri = "http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + ic;
                XmlTextReader reader = new XmlTextReader(uri);
                reader.MoveToContent();
                int isValid = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "are:Pocet_zaznamu")
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

        public Person loadIcInfo(Person tempPerson)
        {
            if (tempPerson.IC != 0)
            {
                string uri = "http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + tempPerson.IC;
                XmlTextReader reader = new XmlTextReader(uri);
                reader.MoveToContent();

                string companyName = "";
                string dateCreated = "";
                string dateValid = "";

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {

                        if (reader.Name == "are:Datum_vzniku")
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            dateCreated = el.Value;
                        }
                        if (reader.Name == "are:Datum_platnosti")
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            dateValid = el.Value;
                        }
                        if (reader.Name == "are:Obchodni_firma")
                        {
                            XElement el = XNode.ReadFrom(reader) as XElement;
                            companyName = el.Value;
                            break;
                        }
                    }
                }
                ICO tempIco = new ICO(dateCreated,dateValid,companyName);
                tempPerson.ICInfo = tempIco;
            }
            else
            {
                ICO tempIco = new ICO("","","");
                tempPerson.ICInfo = tempIco;
            }

            return tempPerson;

        }
    }
}
