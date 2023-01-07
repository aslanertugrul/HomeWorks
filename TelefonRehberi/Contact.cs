public class Contact
{
    private string name,surName,phoneNumber;

    public Contact (string contactName, string contactSurname, string contactPhoneNumber) {
        this.name=contactName;
        this.surName=contactSurname;
        this.phoneNumber=contactPhoneNumber;
    }

    public override string ToString()
        {
            return "Contact:\n"
                + "Name          : {" + name
                + "}\nSurname       : {" + surName
                + "}\nPhone Number  : {" + phoneNumber + "}\n";
        }

        public string ContactName { get { return name; } set { name = value; } }

        public string GetFullName { get { return name + " " + surName; } }

        public string ContactSurname { get { return surName; } set { surName = value; } }

        public string ContactPhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
}