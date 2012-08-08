using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Person : INotifyPropertyChanged
    {
        private int _personid;
        private string _name;
        private string _surname;
        private int _ic;
        private int _dic;
        private bool _isicvalid;

        public BindingList<Adress> Adresses = new BindingList<Adress>();

        public int PersonID 
        {
            get { return _personid; }
            private set { _personid = value; }
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

        public bool isIcValid
        {
            get { return _isicvalid; }
            set
            {
                _isicvalid = value;
                NotifyPropertyChanged("IsIcValid");
            }
        }

        
        

        public Person(int personid, string name, string surname, int ic, int dic)
        {
            PersonID = personid;
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
