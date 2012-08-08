using System.ComponentModel;

namespace AddressBook
{
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
            private set
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


        public Adress(int adressid, string street, string city, int psc, int personid)
        {
            AdressID = adressid;
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
