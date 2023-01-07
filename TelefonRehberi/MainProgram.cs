internal class MainProgram
    {
        static void Main(string[] args)
        {

            PhoneBook phoneBook= new PhoneBook();

            PhoneBookMainMenu(phoneBook);
        }

        public static void PhoneBookMainMenu(PhoneBook phoneBook)
        {
            Console.WriteLine("\n****************** PHONE BOOK MAIN MENU ******************");
            Console.WriteLine("Please write the number of the transaction you want to do.");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(""
                + "(1) Create a new contact,\n"
                + "(2) Delete existing contact,\n"
                + "(3) Update existing contact,\n"
                + "(4) List all contacts,\n"
                + "(5) Search in the Phonebook,\n"
                + "(0) Exit the Phonebook,\n"
                );

            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "1":
                    phoneBook.addNewContact();
                    break;

                case "2":
                    phoneBook.deleteContact();
                    break;

                case "3":
                    phoneBook.updateContact();
                    break;

                case "4":
                    phoneBook.listAllContacts();
                    break;

                case "5":
                    phoneBook.searchContact();
                    break;

                case "0":
                    phoneBook.exitApp();
                    break;

                default:
                    Console.WriteLine("Invalid entry!");
                    PhoneBookMainMenu(phoneBook);
                    break;
            }

        }
    }
    