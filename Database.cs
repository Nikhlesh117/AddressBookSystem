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
        // ability to view contacts that were added to database at particular period
        public void GetContactsFromDataBase(string date)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            List<Contact> contactList = new List<Contact>();
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpGetContactByDate";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@date", date);
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
                    Console.WriteLine($"Contacts added within {date}: ");
                    Console.WriteLine();
                    if (contactList.Count == 0)
                    {
                        Console.WriteLine("no records found");
                    }
                    if (contactList.Count >= 1)
                    {
                        Console.WriteLine($"{contactList.Count} records found");
                        Listview(contactList);
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
        public void GetCountByCity()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpGetCountByCity";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    int count = 0; string city;
                    while (dr.Read())
                    {
                        count = dr.GetInt32(0);
                        city = dr.GetString(1);
                        Console.WriteLine($"City: {city}, No of Contacts: {count}");
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
    }
}
