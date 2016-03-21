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
        private int id;

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

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }



        public virtual void ViewTitle()
        {
            Console.WriteLine($"\n\nTitle: {this.Title.ToUpper()}\nISBN: {this.ISBN}\nLength: {this.Length} pages\nStatus: {this.Status}");
        }

        public virtual void AddTitle()
        {
            this.Status = "Available";
            Console.Write("\nBook ID: ");
            this.Id = ValidateId(Console.ReadLine());
            Console.Write("\nBook Title: ");
            this.Title = Console.ReadLine();
            Console.Write("\nISBN: ");
            this.ISBN = ValidateISBN(Console.ReadLine());
            Console.Write("\nLength in pages: ");
            this.Length = ValidateLength(Console.ReadLine());
        }

        public virtual void EditTitle(string menu)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*************** BOOTCAMP LIBRARY SYSTEM ***************");
                Console.WriteLine(menu);
                Console.WriteLine("Current Info:");
                ViewTitle();

                Console.WriteLine("\n\nEdit:\n1. Title\n2. ISBN\n3. Length\n4. Return to Main");
                int choice = Convert.ToInt32(ValidateISBN(Console.ReadLine()));
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nCurrent Title: " + this.Title);
                        Console.WriteLine("\nEnter new Title: ");
                        this.Title = Console.ReadLine();
                        Console.WriteLine("\n\nNew Title: " + this.Title);
                        Footer();
                        break;

                    case 2:
                        Console.WriteLine("\nCurrent ISBN: " + this.ISBN);
                        Console.WriteLine("\nEnter new ISBN: ");
                        this.ISBN = ValidateISBN(Console.ReadLine());
                        Console.WriteLine("\n\nNew ISBN: " + this.ISBN);
                        Footer();
                        break;

                    case 3:

                        Console.WriteLine("\nCurrent Length: " + this.Length);
                        Console.WriteLine("\nEnter new Length: ");
                        this.Length = ValidateLength(Console.ReadLine());
                        Console.WriteLine("\n\nNew Length: " + this.Length);
                        Footer();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
                
            }
        }

        public virtual string CheckOut()
        {
            this.Status = "Checked Out";
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked out.");
            Console.WriteLine($"\n{this.Title.ToUpper()} is due back on: {DateTime.Now.Date.AddDays(3).ToString("d")}.");
            string due = DateTime.Now.Date.AddDays(3).ToString("d");
            return due;
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

        public virtual int ValidateLength(string length)
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
                    Console.Write("Please enter a valid Length in numbers (exclude \"pages\"): ");
                    length = Console.ReadLine();
                }
            }
            return validLength;
        }


        public int ValidateId(string id)
        {
            int validId = 0;
            bool tryAgain = false;
            while (!tryAgain)
            {
                tryAgain = int.TryParse(id, out validId);
                if (tryAgain)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid ID: ");
                    id = Console.ReadLine();
                }
            }
            return validId;
        }

        public void Footer()
        {
            Console.WriteLine("\n\nHit any key to continue.");
            Console.ReadKey();
        }






//Project Week Iteration #3
//100 Points

//Main Menu
//View All Resources(read from a file)
//Resources titles only need to be included in the file
//View Available Resources
//Edit Resources
//View Student Accounts
//View All Students(read from a file)
//Student names are all that is required for the file
//Check In Resource
//Check Out Resource

//Classes
//Resources must be categorized into 3 child classes(books, magazines, and DVDs)
//Must be a Resources abstract parent class
//Each resource should be instantiated as an object
//3 methods of the Resources class should be virtual and overridden in the child classes
//Each resource should have information regarding the following:
//Title
//ISBN
//Length(pages and minutes depending on resource format)
//Status(Available or Checked Out)

//StreamReader/StreamWriter Files
//Must be a text file to list all resources in the system
//Each resource should have the resource format listed in parentheses like such: Learn C# (Book)
//Must be a text file to list all students in the system
//Must be a text file for each resource type to list all resources of each type(i.e.Books File, Magazines File, DVDs file)
//Must be a currently checked out resources text file
//Each student account should have a text file

//Answer questions completely on the submission form
//Participate in peer review on Wednesday
//Submit project through this form: Submission Form


//Due: Monday, March 21st before 8:00 AM



    }
}
