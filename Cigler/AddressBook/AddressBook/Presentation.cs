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
            PopulateNameList(); //Creating layout of datagridview for namelist and binding data to it
            PopulateAdressList(); //Creating layout of datagridview for adresslist
        }

        #region initialization/utility
        /// <summary>
        /// Creating layout of datagridview for namelist and binding data to it
        /// </summary>
        private void PopulateNameList()
        {
            
            NameList.AutoGenerateColumns = false; //We want to create collums with our names

            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn
                                               {
                                                   DataPropertyName = "PersonID",
                                                   HeaderText = "PersonID"
                                               };


            DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn
                                                 {
                                                     DataPropertyName = "Name",
                                                     HeaderText = "Jmeno"
                                                 };

            DataGridViewTextBoxColumn Surname = new DataGridViewTextBoxColumn
                                                    {
                                                        DataPropertyName = "Surname",
                                                        HeaderText = "Příjmení"
                                                    };

            NameList.Columns.Add(ID); //Adding created collumns to the namelist datagridview
            NameList.Columns.Add(Name);
            NameList.Columns.Add(Surname);

            
            NameList.DataSource = objects.Persons;
            try //trying to hide certain collumns
            {
                NameList.Columns[0].Visible = false; //hiding collumn 0 - PersonID
            }
            catch(Exception exp)
            {
                objects.Log(exp.ToString());
            }
        }

        /// <summary>
        /// //Creating layout of datagridview for adresslist
        /// </summary>
        private void PopulateAdressList()
        {


            AdressList.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn
                                               {
                                                   DataPropertyName = "AdressID",
                                                   HeaderText = "AdressID"
                                               };


            DataGridViewTextBoxColumn Street = new DataGridViewTextBoxColumn
                                                 {
                                                     DataPropertyName = "Street",
                                                     HeaderText = "Ulice"
                                                 };

            DataGridViewTextBoxColumn City = new DataGridViewTextBoxColumn
                                                    {
                                                        DataPropertyName = "City",
                                                        HeaderText = "Město"
                                                    };

            DataGridViewTextBoxColumn PSC = new DataGridViewTextBoxColumn
                                               {
                                                   DataPropertyName = "PSC",
                                                   HeaderText = "PSČ"
                                               };

            AdressList.Columns.Add(ID);
            AdressList.Columns.Add(Street);
            AdressList.Columns.Add(City);
            AdressList.Columns.Add(PSC);

            try
            {
                AdressList.Columns[0].Visible = false; //Hiding collumn 0 - Adress ID
            }
            catch( Exception exp)
            {
                objects.Log(exp.ToString());
            }


            if (objects.Persons.Count > 0)
                AdressList.DataSource = objects.Persons[0].Adresses;
        }

        /// <summary>
        /// Every time selection on namelist changes, show new information in Edit Person textboxes,
        /// Information person/ico labels
        /// </summary>
        private void NameList_SelectionChanged(object sender, EventArgs e)
        {
            if (NameList.SelectedRows.Count == 1) //if is something selected
            {
                string personID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //retreive its id
                Person tempPerson = objects.Persons.Single(p => p.PersonID.ToString() == personID); //find person Based on ID

                InformationName.Text = tempPerson.Name; //fill person information page
                InformationSurname.Text = tempPerson.Surname;
                InformationIC.Text = tempPerson.IC.ToString();
                InformationDic.Text = tempPerson.DIC.ToString();

                AdressList.DataSource = tempPerson.Adresses; //set datasource of datagridview adresslist 

                EditNameTextBox.Text = tempPerson.Name; //fill edit person textboxes
                EditSurnameTextBox.Text = tempPerson.Surname;
                EditICTextBox.Text = tempPerson.IC.ToString();
                EditDICTextBox.Text = tempPerson.DIC.ToString();

                if (tempPerson.ICInfo != null)
                { //if there are IC informations, show them
                    InformationCompany.Text = tempPerson.ICInfo.CompanyName;
                    InformationDateCreated.Text = tempPerson.ICInfo.DateCreated;
                    InformationDateValid.Text = tempPerson.ICInfo.DateValid;
                }
            }

        }
        #endregion

        #region Add Tab
        /// <summary>
        /// Sending info from add textboxes to object layer for check
        /// </summary>
        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            string name = AddNameTextBox.Text;
            string surname = AddSurnameTextBox.Text;
            string ic = AddIcTextBox.Text;
            string dic = AddDicTextBox.Text;

            string result = objects.AddPerson(name, surname, ic, dic); //sending paramas to object layer
            if(result != "")
            { //if we received some error, show it in messsagebox
                MessageBox.Show(result);
            }
            else
            { //else clear all textboxes
                AddNameTextBox.Text = "";
                AddSurnameTextBox.Text = "";
                AddIcTextBox.Text = "";
                AddDicTextBox.Text = "";
            }
           
        }

        /// <summary>
        /// Reading Add adress textboxes and sending its content to the objectlayer
        /// </summary>
        private void AddAdressButton_Click(object sender, EventArgs e)
        {
            string street = AddStreetTextBox.Text;
            string city = AddCityTextBox.Text;
            string psc = AddPSCTextBox.Text;

            if (NameList.SelectedRows.Count == 1)//if some person is selected
            {
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //Get persons id

                string result = objects.AddAdress(street, city, psc, ID); //try to add adress into database/list
                if (result != "")
                {//if it failed, show why
                    MessageBox.Show(result);
                }
                else
                { //else clear textboxes
                    AddStreetTextBox.Text = "";
                    AddCityTextBox.Text = "";
                    AddPSCTextBox.Text = "";
                }
            }
        }

        #endregion

        #region Edit Tab

        /// <summary>
        /// Reading Update textboxes and sending theirs value to objectlayer
        /// </summary>
        private void EditPersonButton_Click(object sender, EventArgs e)
        {
            string name = EditNameTextBox.Text;
            string surname = EditSurnameTextBox.Text;
            string ic = EditICTextBox.Text;
            string dic = EditDICTextBox.Text;



            if (NameList.SelectedRows.Count == 1)//if some row is selected
            { 
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //retreive first cell of first selected row


                string result = objects.UpdatePerson(ID, name, surname, ic, dic); //send update parameters to object layer
                if (result != "")
                { //if we received some error, show it in messsagebox
                    MessageBox.Show(result);
                }
                NameList_SelectionChanged(null, null); //show changes in textboxes
            }
        }

        /// <summary>
        /// Reading edit adress textboxes and sending their content to objectlayer
        /// </summary>
        private void EditAdressButton_Click(object sender, EventArgs e)
        {
            string street = EditStreetTextBox.Text;
            string city = EditCityTextBox.Text;
            string psc = EditPSCTextBox.Text;

            if (NameList.SelectedRows.Count == 1) //if person is selected
            {
                string personID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //retreive its id
                if (AdressList.SelectedRows.Count == 1) //if adress is selected
                {
                    string adressID = AdressList.SelectedRows[0].Cells[0].Value.ToString(); //retreive its id
                    string result = objects.UpdateAddress(adressID, street, city, psc, personID); //send update information to object layer
                    if (result != "")
                    { //if it fails, show why
                        MessageBox.Show(result);
                    }
                    else
                    { //else clear textboxes
                        AddStreetTextBox.Text = "";
                        AddCityTextBox.Text = "";
                        AddPSCTextBox.Text = "";
                    }
                }
            }
        }
        #endregion

        #region Information/Delete Tab
        /// <summary>
        /// Determining which person in list is selected, and then sending its ID to objectlayer for deletion
        /// </summary>
        private void DeletePersonButton_Click(object sender, EventArgs e)
        {
            if (NameList.SelectedRows.Count == 1) //if is something selected
            {
                string ID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //retreive its id
                objects.DeletePerson(ID); //send ID to objectlayer to delete

                InformationCompany.Text = ""; //clear textboxes
                InformationDateValid.Text = "";
                InformationDateCreated.Text = "";
            }
        }

        /// <summary>
        /// Determining which address in list is selected, and then sending its ID to objectlayer for deletion
        /// </summary>
        private void DeleteAdressButton_Click(object sender, EventArgs e)
        {
            if (AdressList.SelectedRows.Count == 1)
            {
                string adressID = AdressList.SelectedRows[0].Cells[0].Value.ToString(); //retreiving adress ID
                string personID = NameList.SelectedRows[0].Cells[0].Value.ToString(); //retreiving PersonsID
                objects.DeleteAdress(adressID, personID); //Send both IDs to object layer for deletion
            }
        }

#endregion



    }
}
