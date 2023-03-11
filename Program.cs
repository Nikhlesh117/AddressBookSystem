using System.Diagnostics.Contracts;
using System.Net;
using System.Xml.Linq;

namespace AddressBookSystem
{
    public class Program
    {
        private static readonly string firstName;
        private static readonly string lastName;

        public static void Main(String[] args)
        {
            ContactManager contactManager = new ContactManager();
            int choice, choice2;
            string bookName = "default";
            Console.WriteLine("Would You Like To \n1.Work on default AddressBook \n2.Create New AddressBook");
            choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    contactManager.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    contactManager.AddAddressBook(bookName);
                    break;
            }

            while (true)
            {
                Console.WriteLine($"Working On {bookName} AddressBook\n");
                Console.WriteLine("Choose An Option \n1.Add New Contact \n2.Edit Existing Contact \n3.Delete A Contact \n4.View A Contact \n5.View All Contacts \n6.Add New AddressBook \n7.Switch AddressBook \n8.Search Contact by city/state \n9.Count by City/State \n10.Sort Entries By Name \n0.Exit Application\n");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter First Name :");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        string lastName = Console.ReadLine();
                        Contact temp = new Contact(firstName, lastName, null, null, null, null, null , null);
                        if (contactManager.CheckDuplicateEntry(temp, bookName))
                        {
                            break;
                        }
                        Console.WriteLine("Enter Address :");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter City :");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter State :");
                        string state = Console.ReadLine();
                        Console.WriteLine("Enter Email :");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter Zip :");
                        string zip = Console.ReadLine();
                        Console.WriteLine("Enter Phone Number :");
                        string phoneNumber = Console.ReadLine();
                        contactManager.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                        break;
                    case 2:
                        string nameToEdit = Console.ReadLine();
                        contactManager.EditContact(nameToEdit, bookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name Of Contact To Delete :");
                        string nameToDelete = Console.ReadLine();
                        contactManager.DeleteContact(nameToDelete, bookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name Of Contact To View :");
                        string nameToView = Console.ReadLine();
                        contactManager.ViewContact(nameToView, bookName);
                        break; 
                    case 5:
                        contactManager.ViewContact(bookName);
                        break;
                    case 6:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        contactManager.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, ContactManager> item in contactManager.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (contactManager.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                contactManager.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                contactManager.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 9:
                        contactManager.DisplayCountByCityandState();
                        break;
                    case 10:
                        contactManager.SortByName();
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
