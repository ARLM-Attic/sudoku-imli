using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AddressBook
{
    /// <summary>
    /// Class used to store Performation Information, It implements InotifyPropertyChange
    /// Interface, meaning that every time a propery is changed a datagridview(a client)
    ///  is notified about change
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        #region Private fields
        private int _personid;
        private string _name;
        private string _surname;
        private int _ic;
        private int _dic;
        private bool _isicvalid;
        #endregion

        #region Properities
        public int PersonID
        {
            get { return _personid; }
            set { _personid = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        public int IC
        {
            get { return _ic; }
            set
            {
                _ic = value;
                NotifyPropertyChanged("IC");
            }
        }


        public int DIC
        {
            get { return _dic; }
            set
            {
                _dic = value;
                NotifyPropertyChanged("DIC");
            }
        }
        #endregion

        public BindingList<Adress> Adresses = new BindingList<Adress>(); //List of adresses
        public ICO ICInfo;


        /// <summary>
        /// Constructor for Person class used when we are loading Informations from database
        /// </summary>
        /// <param name="personid">ID of Person in Database</param>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="ic">identification number of company</param>
        /// <param name="dic">identification number of company for tax purposes</param>
        public Person(int personid,string name, string surname, int ic, int dic)
        {
            PersonID = personid;
            Name = name;
            Surname = surname;
            IC = ic;
            DIC = dic;
        }

        /// <summary>
        /// constructor for Person class used when adding new person to List/Database, meaning we do not have its ID yet
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="ic">identification number of company</param>
        /// <param name="dic">identification number of company for tax purposes</param>
        public Person(string name, string surname, int ic, int dic)
        {
            Name = name;
            Surname = surname;
            IC = ic;
            DIC = dic;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
