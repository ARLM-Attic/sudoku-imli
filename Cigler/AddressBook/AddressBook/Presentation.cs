using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Presentation : Form
    {
        ObjectLayer objects = new ObjectLayer();
        BindingList<Person> _persons = new BindingList<Person>();
        public Presentation()
        {
            InitializeComponent();
            _persons = objects.LoadAdressBook();
            PopulateNameList();
            PopulateAdressList();
            

            
        }

        private void NameList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = NameList.SelectedRows[0].Cells[0].Value.ToString();
            Person tempPerson = _persons.Single(p => p.PersonID.ToString() == ID);
            AdressList.DataSource = tempPerson.Adresses;
        }

        private void PopulateNameList()
        {
            
            NameList.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.DataPropertyName = "PersonID";
            ID.HeaderText = "PersonID";
     

            DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn();
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Jmeno";

            DataGridViewTextBoxColumn Surname = new DataGridViewTextBoxColumn();
            Surname.DataPropertyName = "Surname";
            Surname.HeaderText = "Příjmení";

            DataGridViewTextBoxColumn IC = new DataGridViewTextBoxColumn();
            IC.DataPropertyName = "IC";
            IC.HeaderText = "IČO";

            DataGridViewTextBoxColumn DIC = new DataGridViewTextBoxColumn();
            DIC.DataPropertyName = "DIC";
            DIC.HeaderText = "DIČ";

            NameList.Columns.Add(ID);
            NameList.Columns.Add(Name);
            NameList.Columns.Add(Surname);
            NameList.Columns.Add(IC);
            NameList.Columns.Add(DIC);

            
            NameList.DataSource = _persons;
            try
            {

                NameList.Columns["PersonID"].Visible = false;
            }
            catch(Exception exp)
            {
                objects.Log(exp.ToString());
            }
        }

        private void PopulateAdressList()
        {
            AdressList.DataSource = _persons[0].Adresses;

            AdressList.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.DataPropertyName = "AdressID";
            ID.HeaderText = "AdressID";


            DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn();
            Name.DataPropertyName = "Street";
            Name.HeaderText = "Ulice";

            DataGridViewTextBoxColumn Surname = new DataGridViewTextBoxColumn();
            Surname.DataPropertyName = "City";
            Surname.HeaderText = "Město";

            DataGridViewTextBoxColumn IC = new DataGridViewTextBoxColumn();
            IC.DataPropertyName = "PSC";
            IC.HeaderText = "PSČ";

            DataGridViewTextBoxColumn DIC = new DataGridViewTextBoxColumn();
            DIC.DataPropertyName = "PersonID";
            DIC.HeaderText = "PersonID";

            try
            {
                AdressList.Columns["AdressID"].Visible = false;
                AdressList.Columns["PersonID"].Visible = false;
            }
            catch( Exception exp)
            {
                objects.Log(exp.ToString());
            }
        }
    }
}
