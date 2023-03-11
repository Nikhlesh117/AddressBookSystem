using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    interface IContacts
    {
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, string zip, string phoneNumber, string bookName);
        public void ViewContact(string name, string bookName);
        public void EditContact(string name, string bookName);
        public void DeleteContact(string name, string bookName);
        public void AddAddressBook(string bookName);
    }
}
