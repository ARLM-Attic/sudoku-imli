using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AddressBook
{
    public class ObjectLayer
    {
        private BindingList<Person> _persons = new BindingList<Person>();
        DataLayer data = new DataLayer();

        public ObjectLayer()
        {
            _persons = data.SelectAllPersons(_persons);
            foreach (var person in _persons)
            {
                data.SelectAdresses(person);
            }
        }

        public void NewPerson(Person person)
        {
            try
            {
                CheckIC(person);
                _persons.Add(person);
                data.InsertPerson(person.Name, person.Surname, person.IC, person.DIC);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void UpdatePerson(Person person)
        {
            try
            {
                CheckIC(person);
                data.UpdatePerson(person.PersonID, person.Name, person.Surname, person.IC, person.DIC);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void DeletePerson(Person person)
        {
            try
            {
                data.DeletePerson(person.PersonID);
                _persons.Remove(person);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void NewAdress(Person person, Adress adress)
        {
            try
            {
                person.Adresses.Add(adress);
                data.InsertAddres(adress.Street, adress.City, adress.PSC, person.PersonID);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void UpdateAdress(Adress adress)
        {
            try
            {
                data.UpdateAdress(adress.AdressID, adress.Street, adress.City, adress.PSC);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void DeleteAdress(Person person, Adress adress)
        {
            try
            {
                person.Adresses.Remove(adress);
                data.DeleteAdress(adress.AdressID);
            }
            catch (Exception exp)
            {
                Log(exp.ToString());
            }
        }

        public void CheckIC(Person person)
        {
            try
            {
                string uri = "http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + person.IC;
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
                            if (isValid == 0) person.isIcValid = false;
                            else person.isIcValid = true;
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
        }

        public BindingList<Person> LoadAdressBook()
        {
            return _persons;
        }

        public void Log(string error)
        {
            using (StreamWriter log = File.AppendText("log.txt"))
            {
                log.Write(DateTime.Now);
                log.Write(" : ");
                log.Write(error);
                log.Write("/n");
            }
        }


    }
}
