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
        public Presentation()
        {
            InitializeComponent();
            PopulateNameList();
            PopulateAdressList();   
        }

        private void NameList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = NameList.SelectedRows[0].Cells[0].Value.ToString();
            Person tempPerson = objects.Persons.Single(p => p.PersonID.ToString() == ID);
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

            
            NameList.DataSource = objects.Persons;
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
            if(objects.Persons.Count > 0)
            AdressList.DataSource = objects.Persons[0].Adresses;

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

        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            string name = AddNameTextBox.Text;
            string surname = AddSurnameTextBox.Text;
            string ic = AddIcTextBox.Text;
            string dic = AddDicTextBox.Text;

            string result = objects.AddPerson(name, surname, ic, dic);
            if(result != "")
            {
                MessageBox.Show(result);
            }
            else
            {
                AddNameTextBox.Text = "";
                AddSurnameTextBox.Text = "";
                AddIcTextBox.Text = "";
                AddDicTextBox.Text = "";
            }
           
        }

        private void EditPersonButton_Click(object sender, EventArgs e)
        {
            string name = EditNameTextBox.Text;
            string surname = EditSurnameTextBox.Text;
            string ic = EditICTextBox.Text;
            string dic = EditDICTextBox.Text;

            if (NameList.SelectedRows.Count == 1)
            {
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString();


                string result = objects.UpdatePerson(ID, name, surname, ic, dic);
                if (result != "")
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void DeletePersonButton_Click(object sender, EventArgs e)
        {
            if (NameList.SelectedRows.Count == 1)
            {
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString();
                objects.DeletePerson(ID);
            }
        }

        private void DeleteAdressButton_Click(object sender, EventArgs e)
        {
            if (AdressList.SelectedRows.Count == 1)
            {
                string adressID = AdressList.SelectedRows[0].Cells[0].Value.ToString();
                string personID = AdressList.SelectedRows[0].Cells[0].Value.ToString();
                objects.DeleteAdress(adressID, personID);
            }
        }

        private void AddAdressButton_Click(object sender, EventArgs e)
        {
            string street = AddStreetTextBox.Text;
            string city = AddCityTextBox.Text;
            string psc = AddPSCTextBox.Text;

            if (NameList.SelectedRows.Count == 1)
            {
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString();

                string result = objects.AddAdress(street, city, psc, ID);
                if (result != "")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    AddStreetTextBox.Text = "";
                    AddCityTextBox.Text = "";
                    AddPSCTextBox.Text = "";
                }
            }
        }

        private void EditAdressButton_Click(object sender, EventArgs e)
        {
            string street = AddStreetTextBox.Text;
            string city = AddCityTextBox.Text;
            string psc = AddPSCTextBox.Text;

            if (NameList.SelectedRows.Count == 1)
            {
                string personID = NameList.SelectedRows[0].Cells[0].Value.ToString();
                if (AdressList.SelectedRows.Count == 1)
                {
                    string adressID = AdressList.SelectedRows[0].Cells[0].Value.ToString();
                    string result = objects.UpdateAdress(adressID,street, city, psc, personID);
                    if (result != "")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        AddStreetTextBox.Text = "";
                        AddCityTextBox.Text = "";
                        AddPSCTextBox.Text = "";
                    }
                }
            }
        }

        private void NameList_SelectionChanged(object sender, EventArgs e)
        {
            if (NameList.SelectedRows.Count == 1)
            {
                string personID = NameList.SelectedRows[0].Cells[0].Value.ToString();
                Person tempPerson = objects.Persons.Single(p => p.PersonID.ToString() == personID);
                InformationName.Text = tempPerson.Name;
                InformationSurname.Text = tempPerson.Surname;
                InformationIC.Text = tempPerson.IC.ToString();
                InformationDic.Text = tempPerson.DIC.ToString();

                AdressList.DataSource = tempPerson.Adresses;

                EditNameTextBox.Text = tempPerson.Name;
                EditSurnameTextBox.Text = tempPerson.Surname;
                EditICTextBox.Text = tempPerson.IC.ToString();
                EditDICTextBox.Text = tempPerson.DIC.ToString();
            }

        }

    }
}
