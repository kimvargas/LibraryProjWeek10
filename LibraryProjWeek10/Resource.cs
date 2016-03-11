using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjWeek10
{
    abstract class Resource
    {
        private string title;
        private double isbn;
        private int length;
        private string status;

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public double ISBN
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }

        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }


        public virtual void ViewTitle()
        {
            Console.WriteLine($"\n\n****View Title****\n\nTitle: {this.Title.ToUpper()}\nISBN: {this.ISBN}\nLength: {this.Length} pages\nStatus: {this.Status}");
        }

        public virtual void AddTitle()
        {
            this.Status = "Available";
            Console.Write("\nBook Title: ");
            this.Title = Console.ReadLine();
            Console.Write("\nISBN: ");
            this.ISBN = ValidateISBN(Console.ReadLine());
            Console.Write("\nLength in pages: ");
            this.Length = ValidateLength(Console.ReadLine());
        }
        
        public virtual void CheckOut()
        {
            this.Status = "Checked Out";
            Console.WriteLine($"\n{this.Title.ToUpper()} is due back on: {DateTime.Now.AddDays(3)}.");
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked out.");
        }

        public virtual void CheckIn()
        {
            this.Status = "Available";
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked back in.");
        }



        public double ValidateISBN(string isbn)
        {
            double validIsbn = 0;
            bool tryAgain = false;
            while (!tryAgain)
            {
                tryAgain = double.TryParse(isbn, out validIsbn);
                if (tryAgain)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid ISBN: ");
                    isbn = Console.ReadLine();
                }
            }
            return validIsbn;
        }

        public int ValidateLength(string length)
        {
            int validLength = 0;
            bool tryAgain = false;
            while (!tryAgain)
            {
                tryAgain = int.TryParse(length, out validLength);
                if (tryAgain)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid Length in numbers (exclude \"pages\" or \"minutes\"): ");
                    length = Console.ReadLine();
                }
            }
            return validLength;
        }






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
        //      Print “{ Title of the item} has been checked out."
        //


        //  CheckIn() Method
        //      Status should be changed to “Available”

    }
}
