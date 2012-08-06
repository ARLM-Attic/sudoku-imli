using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Person
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        public int IC { get; set; }
        public int DIC { get; set; }

        public List<Adress> Adresses = new List<Adress>();
        

        public Person(int id, string name, string surname, int ic, int dic)
        {
            ID = id;
            Name = name;
            Surname = surname;
            IC = ic;
            DIC = dic;
        }
    }
}
