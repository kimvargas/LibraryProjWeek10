using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjWeek10
{
    class Program
    {
        static string header = "*************** BOOTCAMP LIBRARY SYSTEM ***************";
        static string menu = "\n1. Do the BOOK\n2. Do the MAGAZINE\n3. Do the DVD\n4. Stop this nonsense!\n";
        


        static void Main(string[] args)
        {
            DVD theDVD = new DVD();
            Magazine theMagazine = new Magazine();
            Book theBook = new Book();
            while (true)
            {
                Header();
                int menuChoice = ValidateMenu(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        Header();
                        Console.WriteLine("Let's view the thing!");
                        theBook.ViewTitle();
                        Console.WriteLine("\nHit any key to add title.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's Add some info!");
                        theBook.AddTitle();
                        theBook.ViewTitle();

                        Console.WriteLine("\nHit any key to check out.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's check it out!");
                        theBook.CheckOut();
                        theBook.ViewTitle();

                        Console.WriteLine("\nHit any key to check in.");
                        Console.ReadKey();

                        Header();
                        Console.WriteLine("Let's check it back!");
                        theBook.CheckIn();
                        theBook.ViewTitle();

                        Console.WriteLine("\nHit any key to stop the madness.");
                        Console.ReadKey();
                        break;

                    case 2:
                        Header();
                        Console.WriteLine("Let's view the thing!");
                        theMagazine.ViewTitle();
                        Console.WriteLine("\nHit any key to add title.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's Add some info!");
                        theMagazine.AddTitle();
                        theMagazine.ViewTitle();

                        Console.WriteLine("\nHit any key to check out.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's check it out!");
                        theMagazine.CheckOut();
                        theMagazine.ViewTitle();

                        Console.WriteLine("\nHit any key to check in.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's check it back!");
                        theMagazine.CheckIn();
                        theMagazine.ViewTitle();

                        Console.WriteLine("\nHit any key to stop the madness.");
                        Console.ReadKey();
                        break;

                    case 3:
                        Header();
                        Console.WriteLine("Let's view the thing!");
                        theDVD.ViewTitle();
                        Console.WriteLine("\nHit any key to add title.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's Add some info!");
                        theDVD.AddTitle();
                        theDVD.ViewTitle();

                        Console.WriteLine("\nHit any key to check out.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's check it out!");
                        theDVD.CheckOut();
                        theDVD.ViewTitle();

                        Console.WriteLine("\nHit any key to check in.");
                        Console.ReadKey();
                        
                        Header();
                        Console.WriteLine("Let's check it back!");
                        theDVD.CheckIn();
                        theDVD.ViewTitle();

                        Console.WriteLine("\nHit any key to stop the madness.");
                        Console.ReadKey();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }



            //Instantiate an object from each of the eligible classes
            //  Call ViewTitle() Method for each object
            //  Call AddTitle() Method for each object //Call ViewTitle() after to view result
            //  Call CheckIn() Method for each object //Call ViewTitle() after to view result
            //  Call CheckOut() Method for each object //Call ViewTitle() after to view result



            //***************************************************************************************************

            //Create a Resource Base Class(use the keyword that will prevent the instantiation of Resource Class objects)
            //  Fields & Properties
            //      Title(title of resource)
            //      ISBN(ISBN number of resource)
            //      Length(length of resource as # of pages)
            //      Status (available or checked out)

            //  ViewTitle() Method that prints out the title, ISBN, length and status of object

            //  AddTitle() Method that allows the user to input values for the properties for a newly instantiated(object instantiation is hard - coded for now)
            //      Status should initially be assigned to the status of “Available”
            //      For Length, ask the user for the length in pages

            //  CheckOut() Method
            //      Status should be changed to “Checked Out”
            //      Tell the user(print) the item is due back on the date that is 3 days from today (use DateTime)
            //      Print “{ Title of the item} has been checked out.
            //
            //  CheckIn() Method
            //      Status should be changed to “Available”

            //Create a DVD Descendant Class
            //  Override the ViewTitle() Method so that the Length property will print as “Minutes” instead of “Pages” (i.e.Length: 90 Minutes for DVD vs. 90 Pages for Book / Magazine / Resource)
            //  Override the AddTitle() Method to ask the user for the length of the DVD in Minutes

            //Create a Book Descendant Class
            //   Override the CheckOut() Method so it gives a due back date that is 5 days from today (use DateTime)

            //Create a Magazine Descendant Class
            //   Override the CheckOut() Method so it gives a due back date that is 2 days from today (use DateTime)

        }

        static void Header()
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine(menu);
        }

        static int ValidateMenu(string choice)
        {
            int validChoice = 0;
            bool tryAgain = false;
            while (!tryAgain)
            {
                tryAgain = int.TryParse(choice, out validChoice);
                if (tryAgain)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid menu item: ");
                    choice = Console.ReadLine();
                }
            }
            return validChoice;
        }
    }
}
