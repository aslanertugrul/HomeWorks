public class PhoneBook : IPhoneBook
{
    private static List<Contact> contacts = new List<Contact>();
    
    public PhoneBook()
        {
            contacts.Add(new Contact("Raif", "Çınar", "05311112233"));
            contacts.Add(new Contact("Tam", "Weblik", "05322223344"));
            contacts.Add(new Contact("Patika", "Dev", "02123334455"));
            contacts.Add(new Contact("Jane", "Doe", "05334445566"));
            contacts.Add(new Contact("John", "Doe", "05345556677"));
        }

    public void addNewContact()
    {
        Console.WriteLine("ADD NEW CONTACT");
        string name ="", surname="", number="";
        bool nameIsValid=false,surnameIsValid=false,numberIsValid=false;

        while (true) {
                if (!nameIsValid)
                {
                    Console.Write("Please enter Name: ");
                    name = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(name))
                        Console.WriteLine("Name cannot be empty!");
                    else
                        nameIsValid = true;
                }
                else if (!surnameIsValid)
                {
                    Console.Write("Please enter Surname: ");
                    surname = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(surname))
                        Console.WriteLine("Surname cannot be empty!");
                    else
                        surnameIsValid = true;
                }
                else if (!numberIsValid)
                {
                    Console.Write("Please enter the 11 digit phone number: ");
                    number = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(number))
                        Console.WriteLine("Phone number cannot be empty!");
                    else if (number.Length == 11)
                    {
                        if (long.TryParse(number, out long longNum) == false)
                        {
                            Console.WriteLine("You entered an invalid phone number. Please try again.");
                        }
                        else
                        {
                            numberIsValid = true;
                        }
                    }
                    else
                        Console.WriteLine("The phone number must be 11 digits. Please try again.");
                }

                if (nameIsValid && surnameIsValid && numberIsValid)
                    break;
            }

            contacts.Add(new Contact(name, surname, number));

            Console.WriteLine(name + " " + surname + " has been added to the Phonebook.");
            ReturnToMainMenu();
        }

    public void deleteContact()
    {
        Console.WriteLine("\nDELETE EXISTING CONTACT BY NUMBER");
        Console.WriteLine("Please enter the 11-digit phone number that you want to delete.");

            string number = Console.ReadLine().Trim();
            Contact contact = GetContactByPhoneNumber(number);

            if (contact == null)
            {
                Console.WriteLine("Number: {" + number + "} invalid or not found!");
                TryAgainForNumber:
                Console.WriteLine(""
                        + "(1) Try again,\n"
                        + "(2) Return to main menu.\n"
                        );
                string choose = Console.ReadLine();
                if (choose.Equals("1"))
                {
                    deleteContact();
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    goto TryAgainForNumber;
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} will be deleted from phone book. Do you confirm? (y/n)");

                    string confirm = Console.ReadLine();
                    if (confirm.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("{" + contact.GetFullName + ", " + contact.ContactPhoneNumber + "} has been deleted.");
                        contacts.Remove(contact);
                        break;
                    }
                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Contact deletion was cancelled.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry!");
                    }
                }
                ReturnToMainMenu();
            }
    }

    public void exitApp()
    {
        
    }

    public void listAllContacts()
    {
        Console.WriteLine("\n********************** ALL CONTACTS **********************");
            Console.WriteLine("----------------------------------------------------------");

            foreach (Contact contact in contacts)
            {
                Console.Write("\n"
                    + "Name          : {" + contact.ContactName
                    + "}\nSurname       : {" + contact.ContactSurname
                    + "}\nPhone Number  : {" + contact.ContactPhoneNumber
                    + "}\n-\n");
            }

            ReturnToMainMenu();
    }

    public void searchContact()
    {
           Console.WriteLine("\n********************* SEARCH CONTACT *********************");

            TryAgainForSearch:
            bool isChoiceOk = false;
            int choose = 0;
            while (!isChoiceOk)
            {
                Console.WriteLine("Please write the number of the transaction you want to do.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(""
                    + "(1) Search by name,\n"
                    + "(2) Search by surname,\n"
                    + "(3) Search by phone number,\n"
                    + "(4) Return to main menu... ,\n"
                    );

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("1"))
                {
                    isChoiceOk = true;
                    choose = 1;
                }
                else if (userInput.Equals("2"))
                {
                    isChoiceOk = true;
                    choose = 2;
                }
                else if (userInput.Equals("3"))
                {
                    isChoiceOk = true;
                    choose = 3;
                }
                else if (userInput.Equals("4"))
                {
                    isChoiceOk = true;
                    choose = 4;
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    isChoiceOk = false;
                    choose = 0;
                }
            }

            Contact contact = null;
            bool found = true;
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Please enter contact name.");
                    string name = Console.ReadLine().Trim();
                    contact = GetContactByName(name);
                    if (contact == null)
                    {
                        Console.WriteLine("Name: {" + name + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter contact surname.");
                    string surname = Console.ReadLine().Trim();
                    contact = GetContactBySurname(surname);
                    if (contact == null)
                    {
                        Console.WriteLine("Surname: {" + surname + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 3:
                    Console.WriteLine("Please enter phone number.");
                    string number = Console.ReadLine().Trim();
                    contact = GetContactByPhoneNumber(number);
                    if (contact == null)
                    {
                        Console.WriteLine("Phone Number: {" + number + "} not found!");
                        goto TryAgainForSearch;
                    }
                    break;
                case 4:
                    found= false;
                    ReturnToMainMenu();
                    break;
            }

            if (found)
            {
                Console.WriteLine(contact.ToString());
                ReturnToMainMenu();
            }
    }

    public void updateContact()
    {
        Console.WriteLine("\nUPDATE CONTACT");
        TryAgainForUpdate:
            bool isChoiceOk = false;
            int choose = 0;
            while (!isChoiceOk)
            {
                Console.WriteLine("Please write the number of the transaction you want to do.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(""
                    + "(1) Name update,\n"
                    + "(2) Surname update,\n"
                    + "(3) Phone number update,\n"
                    + "(4) Return to main menu... ,\n"
                    );

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("1"))
                {
                    isChoiceOk = true;
                    choose = 1;
                }
                else if (userInput.Equals("2"))
                {
                    isChoiceOk = true;
                    choose = 2;
                }
                else if (userInput.Equals("3"))
                {
                    isChoiceOk = true;
                    choose = 3;
                }
                else if (userInput.Equals("4"))
                {
                    isChoiceOk = true;
                    choose = 4;
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                    isChoiceOk = false;
                }
            }

            Contact contact = null;
            bool found = true;
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Please enter the updated name.");
                    string name = Console.ReadLine().Trim();
                    contact = GetContactByName(name);
                    if (contact == null)
                    {
                        Console.WriteLine("Name: {" + name + "} not found!");
                        goto TryAgainForUpdate;
                    }

                    Console.WriteLine("Please enter the new name.");
                    string newName = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newName))
                    {
                        Console.WriteLine("New name cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    contact.ContactName = newName;
                    break;
                case 2:
                    Console.WriteLine("Please enter the updated surname.");
                    string surname = Console.ReadLine().Trim();
                    contact = GetContactBySurname(surname);
                    if (contact == null)
                    {
                        Console.WriteLine("Surname: {" + surname + "} not found!");
                        goto TryAgainForUpdate;
                    }
                    Console.WriteLine("Please enter the new surname.");
                    string newSurname = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newSurname))
                    {
                        Console.WriteLine("New surname cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    contact.ContactSurname = newSurname;
                    break;
                case 3:
                    Console.WriteLine("Please enter the updated phone number.");
                    string number = Console.ReadLine().Trim();
                    contact = GetContactByPhoneNumber(number);
                    if (contact == null)
                    {
                        Console.WriteLine("Phone Number: {" + number + "} not found!");
                        goto TryAgainForUpdate;
                    }
                    Console.WriteLine("Please enter the new 11 digit phone number.");
                    string newPhoneNumber = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(newPhoneNumber))
                    {
                        Console.WriteLine("New phone number cannot be empty!");
                        goto TryAgainForUpdate;
                    }
                    else if (newPhoneNumber.Length == 11)
                    {
                        if (long.TryParse(number, out long longNum) == false)
                        {
                            Console.WriteLine("You entered an invalid phone number. Please try again.");
                            goto TryAgainForUpdate;
                        }
                    }
                    contact.ContactPhoneNumber = newPhoneNumber;
                    break;
                case 4:
                    found = false;
                    ReturnToMainMenu();
                    break;
            }

            if (found)
            {
                Console.WriteLine("Phone book updated.");
                ReturnToMainMenu();
            }
        }
   
    private Contact GetContactByName(string name)
        {
            foreach (Contact contact in contacts)
            {
                if(contact.ContactName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

    private Contact GetContactBySurname(string surname)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.ContactSurname.Equals(surname, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

    private Contact GetContactByPhoneNumber(string number)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.ContactPhoneNumber.Equals(number, StringComparison.InvariantCultureIgnoreCase))
                    return contact;
            }
            return null;
        }

    private void ReturnToMainMenu()
        {
            MainProgram.PhoneBookMainMenu(this);
        }

}