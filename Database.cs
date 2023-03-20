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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "SpRetrieveContacts";
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
    }
}
