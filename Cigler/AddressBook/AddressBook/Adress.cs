using System.ComponentModel;

namespace AddressBook
{
    /// <summary>
    /// Class used to store Adress Information, It implements InotifyPropertyChange
    /// Interface, meaning that every time a propery is changed a datagridview(a client)
    ///  is notified about change
    /// </summary>
    public class Adress : INotifyPropertyChanged
    {
        private int _adressid;
        private string _street;
        private string _city;
        private int _psc;
        private int _personid;

        public int AdressID
        {
            get { return _adressid; }
            set
            {
                _adressid = value;
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyPropertyChanged("City");
            }
        }
        public int PSC
        {
            get { return _psc; }
            set
            {
                _psc = value;
                NotifyPropertyChanged("PSC");
            }
        }
        public int PersonID
        {
            get { return _personid; }
            private set { _personid = value; }
        }

        /// <summary>
        /// Constructor used in cases when we are loading information from Database and adress already has ID
        /// </summary>
        public Adress(int adressid, string street, string city, int psc, int personid)
        {
            AdressID = adressid;
            Street = street;
            City = city;
            PSC = psc;
            PersonID = personid;
        }

        /// <summary>
        /// Constructor used in cases when we are adding new adress to person, and we do not know yet what ID it is going to have
        /// ID is returned after inserting into database.
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="psc"></param>
        /// <param name="personid"></param>
        public Adress( string street, string city, int psc, int personid)
        {
            Street = street;
            City = city;
            PSC = psc;
            PersonID = personid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
