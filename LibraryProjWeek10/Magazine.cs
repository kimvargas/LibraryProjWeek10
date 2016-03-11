using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjWeek10
{
    class Magazine:Resource
    {
        public override void CheckOut()
        {
            this.Status = "Checked Out";
            Console.WriteLine($"\n{this.Title.ToUpper()} is due back on: {DateTime.Now.AddDays(2)}.");
            Console.WriteLine($"\n{this.Title.ToUpper()} has been checked out.");
        }

        public Magazine()
        {
            this.Title = "Please Add title before viewing.";
            this.ISBN = 0;
            this.Length = 0;
            this.Status = "What are you doing??";
        }



        //Create a Magazine Descendant Class
        //   Override the CheckOut() Method so it gives a due back date that is 2 days from today (use DateTime)


    }
}
