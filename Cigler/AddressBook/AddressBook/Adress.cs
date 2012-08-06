using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Adress
    {
        public int AdressID { get; private set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PSC { get; set; }
        public int PersonID { get; private set; }


        public Adress(int adressid, string street, string city, int psc, int personid)
        {
            AdressID = adressid;
            Street = street;
            City = city;
            PSC = psc;
            PersonID = personid;
        }
    }

}
