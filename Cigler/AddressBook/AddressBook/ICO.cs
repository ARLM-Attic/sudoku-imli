using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    /// <summary>
    /// Class used to store information about IC number
    /// </summary>
    public class ICO
    {
        private int _icID;
        private string _dateCreated;
        private string _dateValid;
        private string _companyName;

        public int icID
        {
            get { return _icID; }
            set { _icID = value; }
        }

        /// <summary>
        /// Date when IC record was created
        /// </summary>
        public string DateCreated
        {
            get { return _dateCreated; }
            private set { _dateCreated = value; }

        }

        /// <summary>
        /// IC information is valid to the end of this date
        /// </summary>
        public string DateValid
        {
            get { return _dateValid; }
            private set { _dateValid = value; }

        }

        /// <summary>
        /// Company Name mentioned in IC information in Ares
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            private set { _companyName = value; }
        }

        /// <summary>
        /// Constructor used in cases when we are adding new icInfo to person, and we do not know yet what ID it is going to have
        /// ID is returned after inserting into database.
        /// </summary>
        public ICO(string dateCreated, string dateValid, string name)
        {
            _dateCreated = dateCreated;
            _dateValid = dateValid;
            _companyName = name;
        }

        /// <summary>
        /// Constructor used in cases when we are loading information from Database thus we already have ID of IcInfo
        /// </summary>
        public ICO(int icId, string dateCreated, string dateValid, string name)
        {
            _icID = icId;
            _dateCreated = dateCreated;
            _dateValid = dateValid;
            _companyName = name;
        }
    }
}
