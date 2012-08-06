using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class DataLayer
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AdressBook.mdf;Integrated Security=True;User Instance=True;Initial Catalog=InstanceDB";

        public void InsertPerson(string name, string surname, int ic, int dic)
        {
            string query = "INSERT INTO Persons (Name, Surname ,IC, DIC) Values (@name, @surname,@ic,@dic);";

           
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
                cmd.ExecuteNonQuery();
            }
            catch(Exception exp)
            {
                throw exp;
            }
            finally
            {      
               connect.Close(); 
            }
        }

        public void InsertAddres(string street, string city, int psc, int personID)
        {
            string query = "INSERT INTO Adresses(Street, City, PSC, PersonID) VALUES(@street,@city,@PSC,@PersonID);";

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


        public List<Person> SelectAllPersons(List<Person> personsList)
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
                cmd.Parameters.AddWithValue("@PersonID", tempPerson.ID);
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



    }
}
