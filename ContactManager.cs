using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookSystem
{
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact()
        {
            Console.WriteLine("Add a new contact");
            Console.WriteLine("-----------------");

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Zip: ");
            string zip = Console.ReadLine();

            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            contacts.Add(newContact);

            Console.WriteLine("Contact added successfully!");
        }

        public void ViewContacts()
        {
            Console.WriteLine("View all contacts");
            Console.WriteLine("------------------");

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"First name: {contact.FirstName}");
                    Console.WriteLine($"Last name: {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"Zip: {contact.Zip}");
                    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine();
                }
            }
        }

        public void EditContact(string name)
        {
            foreach (var contact in contacts)
            {
                if (contact.FirstName == name)
                {
                    Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            contact.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            contact.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            contact.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            contact.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            contact.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            contact.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            contact.Zip = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            contact.PhoneNumber = Console.ReadLine();
                            break;
                    }
                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Delete a contact");
            Console.WriteLine("----------------");

            Console.Write("Enter the first name of the contact to delete: ");
            string name = Console.ReadLine();

            Contact contactToDelete = null;

            foreach (var contact in contacts)
            {
                if (contact.FirstName == name)
                {
                    contactToDelete = contact;
                    break;
                }
            }

            if (contactToDelete == null)
            {
                Console.WriteLine($"Contact with first name '{name}' not found.");
            }
            else
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine("Contact deleted successfully!");
            }
        }
    }
}