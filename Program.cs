using System.Diagnostics.Contracts;
using System.Net;

namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(String[] args)
        {
            ContactManager contactManager = new ContactManager();

            while (true)
            {
                Console.WriteLine("Address Book Menu");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add new contact");
                Console.WriteLine("2. View all contacts");
                Console.WriteLine("3. Edit a contact");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        contactManager.AddContact();
                        break;
                    case "2":
                        contactManager.ViewContacts();
                        break;
                    case "3":
                        contactManager.EditContact("nk");
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
