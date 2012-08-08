using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;

namespace AdressBookTest
{
    [TestClass]
    public class objectLayer
    {
        [TestMethod]
        public void ObjectTest()
        {
            AddressBook.ObjectLayer obLayer = new ObjectLayer();
            Person person = new Person(0, "A", "B", 27074358, 27074358);
            obLayer.CheckIC(person);
        }
    }
}
