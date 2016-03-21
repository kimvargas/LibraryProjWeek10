using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjWeek10
{
    class Book:Resource
    {
        public override string CheckOut()
        {
            this.Status = "Checked Out";
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked out.");
            Console.WriteLine($"\n{this.Title.ToUpper()} is due back on: {DateTime.Now.Date.AddDays(5).ToString("d")}.");
            string due = DateTime.Now.Date.AddDays(5).ToString("d");
            return due;
        }


        public Book()
        {
            this.Title = "Please Add title before viewing.";
            this.ISBN = 0;
            this.Length = 0;
            this.Status = "";
        }

        public Book(string Title, int ISBN, int Length, string Status, int Id)
        {
            this.Title = Title;
            this.ISBN = ISBN;
            this.Length = Length;
            this.Status = Status;
            this.Id = Id;
        }

        //Create a Book Descendant Class
        //   Override the CheckOut() Method so it gives a due back date that is 5 days from today (use DateTime)
    }
}
