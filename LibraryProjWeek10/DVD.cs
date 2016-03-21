using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjWeek10
{
    class DVD:Resource
    {
        public override void ViewTitle()
        {
            Console.WriteLine($"\n\nTitle: {this.Title.ToUpper()}\nISBN: {this.ISBN}\nLength: {this.Length} minutes\nStatus: {this.Status}");
        }

        public override void AddTitle()
        {
            this.Status = "Available";
            Console.Write("\nDVD Title: ");
            this.Title = Console.ReadLine();
            Console.Write("\nISBN: ");
            this.ISBN = ValidateISBN(Console.ReadLine());
            Console.Write("\nLength in minutes: ");
            this.Length = ValidateLength(Console.ReadLine());
        }

        public override string CheckOut()
        {
            this.Status = "Checked Out";
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked out.");
            Console.WriteLine($"\n{this.Title.ToUpper()} is due back on: {DateTime.Now.Date.AddDays(3).ToString("d")}.");
            string due = DateTime.Now.Date.AddDays(3).ToString("d");
            return due;
        }

        public override int ValidateLength(string length)
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
                    Console.Write("Please enter a valid Length in numbers (exclude \"minutes\"): ");
                    length = Console.ReadLine();
                }
            }
            return validLength;
        }

        public DVD()
        {
            this.Title = "Please Add title before viewing.";
            this.ISBN = 0;
            this.Length = 0;
            this.Status = "";
        }

        public DVD(string Title, int ISBN, int Length, string Status, int Id)
        {
            this.Title = Title;
            this.ISBN = ISBN;
            this.Length = Length;
            this.Status = Status;
            this.Id = Id;
        }






    }
}
