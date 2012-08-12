using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddressBook
{
    public class DataLayer
    {
        private static string dbPath = Application.StartupPath + "\\AdressBook.MDF"; //path to database
      
        //connection string for connecting to database
        public static string connectionString = @"Server=.\SQLExpress;AttachDbFilename="+dbPath+";Trusted_Connection=Yes;User Instance=True;";

        #region Insert Functions
        /// <summary>
        /// Inserting Person into database
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="surname">Surname of person</param>
        /// <param name="ic">Identification number of company</param>
        /// <param name="dic">Identification number of company for tax purposes</param>
        /// <returns>ID of inserted Person in database</returns>
        public int InsertPerson(string name, string surname, int ic, int dic)
        {
            //database command for inserting person into database in string form
            string command = "INSERT INTO Persons (Name, Surname ,IC, DIC) Values (@name, @surname,@ic,@dic); SELECT CAST(scope_identity() AS int)";

            int ID = 0;
            SqlConnection connect = new SqlConnection(connectionString); //connecting to database
            
            try
            {
                SqlCommand cmd = new SqlCommand(command, connect); //creating database commmand
                cmd.CommandText = command;
                connect.Open();               
                cmd.Parameters.AddWithValue("@name", name); //entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@ic", ic);
                cmd.Parameters.AddWithValue("@dic", dic);
                cmd.CommandType = CommandType.Text;
                ID = (Int32)cmd.ExecuteScalar(); //executing command and receiving a value of first collum of inserted row
            }
            catch(Exception exp)
            {
                throw exp;
            }
            finally
            {      
               connect.Close(); //closing database connection
            }
            return ID;
        }

        /// <summary>
        /// Inserting address into database
        /// </summary>
        /// <param name="street">Street name</param>
        /// <param name="city">City name</param>
        /// <param name="psc">Area Code</param>
        /// <param name="personID">ID of Person in Database</param>
        /// <returns>ID of inserted Address in database</returns>
        public int InsertAddres(string street, string city, int psc, int personID)
        {
            //database command for inserting adress into database in string form
            string query = "INSERT INTO Adresses(Street, City, PSC, PersonID) VALUES(@street,@city,@PSC,@PersonID);SELECT CAST(scope_identity() AS int)";
            int ID = 0;
            SqlConnection connect = new SqlConnection(connectionString); //creating connection

            try
            {
                connect.Open(); //opening connection
                SqlCommand cmd = new SqlCommand(query, connect); //creating command
                cmd.Parameters.AddWithValue("@street", street);//entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@PSC", psc);
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.CommandType = CommandType.Text;
                ID = (Int32)cmd.ExecuteScalar(); //executing command and receiving a value of first collum of inserted row

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            return ID;
        }

        /// <summary>
        /// Inserting information about IC into database
        /// </summary>
        /// <param name="companyName">Name of Company</param>
        /// <param name="dateCreated">Date of Creation</param>
        /// <param name="dateValid">Ics validity expiration date</param>
        /// <param name="personID">Id of Person in database</param>
        /// <returns>ID of icInfo in database</returns>
        public int InsertIco(string companyName, string dateCreated, string dateValid, int personID)
        {
            //database command for inserting adress into database in string form
            string query = "INSERT INTO IcInfo(CompanyName, DateCreated, DateValid, PersonID) VALUES(@company,@created,@valid,@PersonID);SELECT CAST(scope_identity() AS int)";
            SqlConnection connect = new SqlConnection(connectionString);
            int id;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);//creating sql command
                cmd.Parameters.AddWithValue("@company", companyName);//entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@created", dateCreated);
                cmd.Parameters.AddWithValue("@valid", dateValid);
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.CommandType = CommandType.Text;
                id = (Int32)cmd.ExecuteScalar();//executing command and receiving a value of first collum of inserted row
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            return id;
        }
        #endregion 
        
        #region Update commands
        /// <summary>
        /// Update Adress record
        /// </summary>
        /// <param name="AdressID">ID of adress in database</param>
        /// <param name="street">Street name</param>
        /// <param name="city">City name</param>
        /// <param name="psc">Area Code</param>
        public void UpdateAdress(int AdressID, string street, string city, int psc)
        {
            //database command for inserting adress into database in string form
            string query = "UPDATE Adresses SET Street=@street, City=@city, PSC=@psc WHERE AdressID=@AdressID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@AdressID", AdressID); //entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@PSC", psc);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery(); //executing command

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }


        }

        /// <summary>
        /// Updating information about IC
        /// </summary>
        /// <param name="companyName">New name of Company</param>
        /// <param name="dateCreated">New date of Creation</param>
        /// <param name="dateValid">New ic validity expiration date</param>
        public void UpdateIcInfo(int icID,string companyName, string dateCreated, string dateValid)
        {
            //database command for inserting adress into database in string form
            string query = "UPDATE IcInfo SET CompanyName=@companyName, DateCreated=@dateCreated, DateValid=@dateValid WHERE icID=@icID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@companyName", companyName); //entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@dateValid", dateValid);
                cmd.Parameters.AddWithValue("@icID", icID);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery(); //executing command

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }


        }

        /// <summary>
        /// Updating Person's record in database
        /// </summary>
        /// <param name="name">New name of person</param>
        /// <param name="surname">New surname of person</param>
        /// <param name="ic">New identification number of company</param>
        /// <param name="dic">New identification number of company for tax purposes</param>
        public void UpdatePerson(int PersonID, string name, string surname, int ic, int dic)
        {
            //database command for inserting adress into database in string form
            string query = "UPDATE Persons SET Name = @name, Surname = @surname, IC = @ic, DIC = @dic WHERE PersonID = @PersonID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@PersonID", PersonID); //entering variables represented in command string by @value
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@ic", ic);
                cmd.Parameters.AddWithValue("@DIC", dic);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery(); //executing command

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            
        }

        #endregion

        #region Delete fucntions
        /// <summary>
        /// Delete person's record in database
        /// </summary>
        /// <param name="PersonsID">Person's ID in database</param>
        public void DeletePerson(int PersonsID)
        {
            //database command for inserting adress into database in string form
            string query =
                "DELETE FROM Persons WHERE PersonID = @PersonID;" + //removing person
                " DELETE FROM Adresses WHERE PersonID =@PersonID;" + // removing adresses
                "DELETE FROM IcInfo WHERE PersonID =@PersonID;"; //removing icInfo

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@PersonID", PersonsID); //entering variables represented in command string by @value


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery(); //executing command

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }

        }


        /// <summary>
        /// Deleting person's adress
        /// </summary>
        /// <param name="AdressID">ID of adress in database</param>
        public void DeleteAdress(int AdressID)
        {
            //database command for inserting adress into database in string form
            string query = "DELETE FROM Adresses WHERE AdressID = @AdressID;";
                
            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@AdressID", AdressID); //entering variables represented in command string by @value
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery(); //executing command
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }

        }
#endregion

        #region Select Functions
        /// <summary>
        /// Load all persons in database into list
        /// </summary>
        /// <param name="personsList">List to load information into</param>
        /// <returns></returns>
        public BindingList<Person> SelectAllPersons(BindingList<Person> personsList)
        {
            //database command for inserting adress into database in string form
            string query = "Select * FROM Persons";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader(); //executing command
                while(reader.Read())
                {
                   Person tempPerson = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                   personsList.Add(tempPerson);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            return personsList;
        }

        /// <summary>
        /// Load all adresses associated with person into list
        /// </summary>
        /// <param name="tempPerson">Object representing person</param>
        /// <returns>Object representing person with adresses loaded</returns>
        public Person SelectAdresses(Person tempPerson)
        {
            //database command for inserting adress into database in string form
            string query = "Select * FROM Adresses where PersonID = @PersonID";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@PersonID", tempPerson.PersonID); //entering variables represented in command string by @value
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader(); //executing command
                
                 while(reader.Read())
                {                
                    Adress tempAdress = new Adress(reader.GetInt32(0),reader[1].ToString(),reader[2].ToString(),reader.GetInt32(3),reader.GetInt32(4));
                    tempPerson.Adresses.Add(tempAdress);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            return tempPerson;

        }

        /// <summary>
        /// Load information about IC into person's object
        /// </summary>
        /// <param name="tempPerson">Object representing person</param>
        /// <returns>Object representing person with icInfo loaded</returns>
        public Person SelectIc(Person tempPerson)
        {
            //database command for inserting adress into database in string form
            string query = "Select * FROM IcInfo where PersonID = @PersonID";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect); //creating sql command
                cmd.Parameters.AddWithValue("@PersonID", tempPerson.PersonID); //entering variables represented in command string by @value

                reader = cmd.ExecuteReader(); //executing command
                 
                while (reader.Read())
                {
                    ICO tempIc = new ICO(reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    tempPerson.ICInfo = tempIc;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connect.Close();
            }
            return tempPerson;

        }

        #endregion

    }
}
