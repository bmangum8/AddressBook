using System;
using System.Collections.Generic;

namespace addressBook
{
    class Program
{
    /*
        1. Add the required classes to make the following code compile.
        HINT: Use a Dictionary in the AddressBook class to store Contacts. The key should be the contact's email address.

        2. Run the program and observe the exception.

        3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
            Print meaningful error messages in the catch blocks.
    */

    static void Main(string[] args)
    {
        // Create a few contacts
        Contact bob = new Contact() {
            FirstName = "Bob", LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
        };
        Contact sue = new Contact() {
            FirstName = "Sue", LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
        };
        Contact juan = new Contact() {
            FirstName = "Juan", LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
        };


        // Create an AddressBook and add some contacts to it
        AddressBook addressBook = new AddressBook();
        addressBook.AddContact(bob);
        addressBook.AddContact(sue);
        addressBook.AddContact(juan);

        // Try to addd a contact a second time
        //Terminal error message: Unhandled exception. 
        //System.ArgumentException: An item with the same key has already been added. Key: sue.jones@email.com
        try
        {
        addressBook.AddContact(sue);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("That contact already exists.");
        }


        // Create a list of emails that match our Contacts
        List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };


        try{
        // Insert an email that does NOT match a Contact
        emails.Insert(1, "not.in.addressbook@email.com");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("That email does not exist.");
        }
        //Terminal error message: Name: Sue
        // Email: sue.jones@email.com
        // Address: 322 Hard Way, Testville, TN 11111
        // Unhandled exception. System.Collections.Generic.KeyNotFoundException: 
        // The given key 'not.in.addressbook@email.com' was not present in the dictionary.


        //  Search the AddressBook by email and print the information about each Contact
        foreach (string email in emails)
        {
        try
        {
            Contact contact = addressBook.GetByEmail(email);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name: {contact.FirstName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("We could not find that contact.");
        }
        }
    }

//declare Contact class
public class Contact 
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Address {get; set;}

}


//declare AddressBook class
public class AddressBook
{
    //a property on address book class
    //key is email. value is whole contact object
    public Dictionary<string, Contact> addressbook { get; set; }

    //made a constructor
    public AddressBook()
    {
        addressbook = new Dictionary<string, Contact>();
    }

    //create AddContact method
    public void AddContact(Contact contact)
    {
        addressbook.Add(contact.Email, contact);
    }


     //create getByEmail method
    public Contact GetByEmail(string email)
    {
        return addressbook[email];
    }
}
}
}
