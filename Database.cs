using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Database
    {
        public void GetContactsFromDataBase(List<Contact> contactList)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB Address_Book1;Initial Catalog=AddressBookDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpRetrieveContacts";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Contact contact = new Contact
                        {
                            FirstName = dr.GetString(0),
                            LastName = dr.GetString(1),
                            Address = dr.GetString(2),
                            City = dr.GetString(3),
                            State = dr.GetString(4),
                            ZipCode = dr.GetInt32(5),
                            PhoneNumber = dr.GetInt64(6),
                            Email = dr.GetString(7)
                        };
                        contactList.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        // ability to update contact in database
        private void EditContactDatabase(string name, Contact contact)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB Address_Book1;Initial Catalog=AddressBookDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpUpdateContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@firstName", contact.FirstName);
                    command.Parameters.AddWithValue("@lastName", contact.LastName);
                    command.Parameters.AddWithValue("@address", contact.Address);
                    command.Parameters.AddWithValue("@city", contact.City);
                    command.Parameters.AddWithValue("@state", contact.State);
                    command.Parameters.AddWithValue("@zip", contact.ZipCode);
                    command.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@email", contact.Email);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    string outputMessage = result == 1 ? "Contact Updaeted SuccessFully" : "Contact Update failed";
                    Console.WriteLine(outputMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
