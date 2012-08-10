using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class ICO
    {
        private int _icID;
        private string _dateCreated;
        private string _dateValid;
        private string _companyName;

        public int icID
        {
            get { return _icID; }
            set { icID = value; }
        }

        public string DateCreated
        {
            get { return _dateCreated; }
            private set { _dateCreated = value; }

        }

        public string DateValid
        {
            get { return _dateValid; }
            private set { _dateValid = value; }

        }

        public string CompanyName
        {
            get { return _companyName; }
            private set { _companyName = value; }
        }


        public ICO(string dateCreated, string dateValid, string name)
        {
            _dateCreated = dateCreated;
            _dateValid = dateValid;
            _companyName = name;
        }
    }
}
