using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookSystem
{
    public class ContactManager:IContacts
    {
        //private List<Contact> contacts = new List<Contact>();
        private Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();
        private Dictionary<string, ContactManager> addressBookDictionary = new Dictionary<string, ContactManager>();
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();


        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, string zip, string phoneNumber, string bookName)
        {
            Contact contact = new Contact(firstName, lastName, address, city, state, email, zip, phoneNumber);
            addressBookDictionary[bookName].contacts.Add(contact.FirstName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");
        }

        public void ViewContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].contacts)
            {
                if (item.Key == name)
                {
                    Console.WriteLine("First Name : " + item.Value.FirstName);
                    Console.WriteLine("Last Name : " + item.Value.LastName);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
                }
            }
        }
        public void ViewContact(string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].contacts)
            {
                Console.WriteLine("First Name : " + item.Value.FirstName);
                Console.WriteLine("Last Name : " + item.Value.LastName);
                Console.WriteLine("Address : " + item.Value.Address);
                Console.WriteLine("City : " + item.Value.City);
                Console.WriteLine("State : " + item.Value.State);
                Console.WriteLine("Email : " + item.Value.Email);
                Console.WriteLine("Zip : " + item.Value.Zip);
                Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
            }
        }

        public void EditContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].contacts)
            {
                if (item.Key == name)
                {
                    Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            item.Value.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            item.Value.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            item.Value.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            item.Value.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            item.Value.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            item.Value.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            item.Value.Zip = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            item.Value.PhoneNumber = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine("\nEdited Successfully\n");
                }
            }
        }

        public void DeleteContact(string name, string bookName)
        {
            Console.WriteLine("Delete a contact");
            Console.WriteLine("----------------");

            if (addressBookDictionary[bookName].contacts.ContainsKey(name))
            {
                addressBookDictionary[bookName].contacts.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }

        public void AddAddressBook(string bookName)
        {
            ContactManager addressBook = new ContactManager();
            addressBookDictionary.Add(bookName, addressBook);
            Console.WriteLine("AddressBook Created.");
        }
        public Dictionary<string, ContactManager> GetAddressBook()
        {
            return addressBookDictionary;
        }
        public List<Contact> GetListOfDictctionaryKeys(string bookName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in addressBookDictionary[bookName].contacts.Values)
            {
                book.Add(value);
            }
            return book;
        }
        public List<Contact> GetListOfDictctionaryKeys2(Dictionary<string, Contact> d)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in d.Values)
            {
                book.Add(value);
            }
            return book;
        }
        public bool CheckDuplicateEntry(Contact c, string bookName)
        {
            List<Contact> book = GetListOfDictctionaryKeys(bookName);
            if (book.Any(b => b.Equals(c)))
            {
                Console.WriteLine("Name already Exists.");
                return true;
            }
            return false;
        }
        public void SearchPersonByCity(string city)
        {
            foreach (ContactManager addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.contacts);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void SearchPersonByState(string state)
        {
            foreach (ContactManager addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.contacts);
                foreach (Contact contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void CreateCityDictionary()
        {
            foreach (ContactManager addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.contacts.Values)
                {
                    addressBookObj.cityDictionary.Add(contact, contact.City);
                }
            }
        }
        public void CreateStateDictionary()
        {
            foreach (ContactManager addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.contacts.Values)
                {
                    addressBookObj.stateDictionary.Add(contact, contact.State);
                }
            }
        }
    }
}