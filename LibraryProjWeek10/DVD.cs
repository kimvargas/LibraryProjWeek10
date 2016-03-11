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
            Console.WriteLine($"\n\n****View Title****\n\nTitle: {this.Title.ToUpper()}\nISBN: {this.ISBN}\nLength: {this.Length} minutes\nStatus: {this.Status}");
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

        public DVD()
        {
            this.Title = "Please Add title before viewing.";
            this.ISBN = 0;
            this.Length = 0;
            this.Status = "What are you doing??";
        }







    }
}
