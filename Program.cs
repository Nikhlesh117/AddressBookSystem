namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to the Address Book System");


            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter state: ");
            string state = Console.ReadLine();

            Console.Write("Enter zip code: ");
            string zip = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("\n");


            contact newContact = new contact(firstName, lastName, address, city, state, zip, phoneNumber, email);

        }
    }
}
