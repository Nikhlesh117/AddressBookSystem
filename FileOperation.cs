using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class FileOperation
    {
        private string filePath = @"D:\Work\Bridgelabz\.net repo\AddressBookSystem\AddressBookSystem\AddressBookRecord.txt";
        public void WriteToFile(Dictionary<string, ContactManager> addressBookDictionary)
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            foreach (ContactManager addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookobj.contacts.Values)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of Text File");
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
    }
}
