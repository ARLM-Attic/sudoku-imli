using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class DataLayer
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AdressBook.mdf;Integrated Security=True;User Instance=True";

        public int InsertPerson(string name, string surname, int ic, int dic)
        {
            string query = "INSERT INTO Persons (Name, Surname ,IC, DIC) Values (@name, @surname,@ic,@dic); SELECT CAST(scope_identity() AS int)";

            int ID = 0;
            SqlConnection connect = new SqlConnection(connectionString);
            
            try
            {
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.CommandText = query;
                connect.Open();               
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@ic", ic);
                cmd.Parameters.AddWithValue("@dic", dic);
                cmd.CommandType = CommandType.Text;
                ID = (Int32)cmd.ExecuteScalar();
            }
            catch(Exception exp)
            {
                throw exp;
            }
            finally
            {      
               connect.Close(); 
            }
            return ID;
        }

        public int InsertAddres(string street, string city, int psc, int personID)
        {
            string query = "INSERT INTO Adresses(Street, City, PSC, PersonID) VALUES(@street,@city,@PSC,@PersonID);SELECT CAST(scope_identity() AS int)";
            int ID = 0;
            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@PSC", psc);
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.CommandType = CommandType.Text;
                ID = (Int32)cmd.ExecuteScalar();

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

        public int InsertIco(string companyName, string dateCreated, string dateValid, int personID)
        {
            string query = "INSERT INTO IcInfo(CompanyName, DateCreated, DateValid, PersonID) VALUES(@company,@created,@valid,@PersonID);SELECT CAST(scope_identity() AS int)";
            SqlConnection connect = new SqlConnection(connectionString);
            int id;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@company", companyName);
                cmd.Parameters.AddWithValue("@created", dateCreated);
                cmd.Parameters.AddWithValue("@valid", dateValid);
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.CommandType = CommandType.Text;
                id = (Int32)cmd.ExecuteScalar();
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

        public void UpdateAdress(int AdressID, string street, string city, int psc)
        {
            string query = "UPDATE Adresses SET Street=@street, City=@city, PSC=@psc WHERE AdressID=@AdressID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@AdressID", AdressID);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@PSC", psc);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

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


        public void UpdateIcInfo(int icID,string companyName, string dateCreated, string dateValid)
        {
            string query = "UPDATE IcInfo SET CompanyName=@companyName, DateCreated=@dateCreated, DateValid=@dateValid WHERE icID=@icID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@companyName", companyName);
                cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                cmd.Parameters.AddWithValue("@dateValid", dateValid);
                cmd.Parameters.AddWithValue("@icID", icID);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

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

        public void UpdatePerson(int PersonID, string name, string surname, int ic, int dic)
        {

            string query = "UPDATE Persons SET Name = @name, Surname = @surname, IC = @ic, DIC = @dic WHERE PersonID = @PersonID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@ic", ic);
                cmd.Parameters.AddWithValue("@DIC", dic);

                cmd.CommandType = CommandType.Text;
                int test = cmd.ExecuteNonQuery();

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

        public void DeletePerson(int PersonsID)
        {

            string query = "DELETE FROM Persons WHERE PersonID = @PersonID; DELETE FROM Adresses WHERE PersonID =@PersonID";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@PersonID", PersonsID);


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

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

        public void DeleteIC(int icID)
        {

            string query = "DELETE FROM IcInfo WHERE icID = @icID;";

            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@icID", icID);


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

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

        public void DeleteAdress(int AdressID)
        {

            string query = "DELETE FROM Adresses WHERE AdressID = @AdressID;";
                
            SqlConnection connect = new SqlConnection(connectionString);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@AdressID", AdressID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
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


        public BindingList<Person> SelectAllPersons(BindingList<Person> personsList)
        {

            string query = "Select * FROM Persons";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;
            int PersonId, ic, dic;

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
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


        public Person SelectAdresses(Person tempPerson)
        {

            string query = "Select * FROM Adresses where PersonID = @PersonID";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@PersonID", tempPerson.PersonID);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                
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

        public Person SelectIc(Person tempPerson)
        {

            string query = "Select * FROM IcInfo where PersonID = @PersonID";

            SqlConnection connect = new SqlConnection(connectionString);
            SqlDataReader reader;
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@PersonID", tempPerson.PersonID);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();

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



    }
}
