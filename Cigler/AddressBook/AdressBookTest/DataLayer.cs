using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;

namespace AdressBookTest
{
    [TestClass]
    public class DataLayer
    {
        [TestMethod]
        public void TestMethod1()
        {
            AddressBook.DataLayer data = new AddressBook.DataLayer();
            data.InsertPerson("michal","Imlauf",12,13);
            data.InsertAddres("A","B",53701,29);
            
            
           // data.UpdateAdress(22,"C","E",000);
            //data.UpdatePerson(28,"A","C",17,18);
            BindingList<Person> persons = new BindingList<Person>();

            persons = data.SelectAllPersons(persons);
           persons[0] = data.SelectAdresses(persons[0]);
           // data.DeleteAdress(1);
           // data.DeletePerson(1);
        }
    }
}
