using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryProjWeek10
{
    class Program
    {
        static string header = "*************** BOOTCAMP LIBRARY SYSTEM ***************";
        static string menu0 = "\n\nMENU\n\n(Please type a number.)" +
            "\n\n1. View All Resources\n2. View Available Resources\n3. Edit Resources\n" +
            "4. View Student Accounts\n5. View All Students\n6. Checkout Item\n7. Return Item" +
            "\n8. Reset all Student Accounts \n9. Exit\n";
        static string menu1 = "\nALL RESOURCES\n\n";
        static string menu2 = "\nAVAILABLE RESOURCES\n\n";
        static string menu3 = "\nEDIT RESOURCES\n\n";
        static string menu4 = "\nSTUDENT ACCOUNTS\n\n";
        static string menu5 = "\nVIEW STUDENTS\n\n";
        static string menu6 = "\nITEM CHECKOUT\n\n";
        static string menu7 = "\nITEM RETURN\n\n";
        static string menu8 = "\nRESET ALL STUDENTS/RESOURCES\n\n";
        
        static Dictionary<string, int> Students = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Quinn Bennett", 101 },
            {"Lawrence Hudson", 102},
            {"Imari Childress", 103},
            {"Jennifer Evans", 104},
            {"Margaret Landefeld", 105},
            {"Jacob Lockyer", 106},
            {"Richard Raponi", 107},
            {"Cameron Robinson", 108},
            {"Krista Scholdberg", 109},
            {"Ashley Stewart", 110},
            {"Cadale Thomas", 111},
            {"Kimberly Vargas", 112},
            {"Mary Winkelman", 113}
        };


        static List<Resource> resources = new List<Resource>()
            { new Book("Programming Interviews Exposed",90007001,290,"Available",1001),
            new Book("Killer Game Programming", 90007002, 198, "Available",1002),
            new Book("Head First C#", 90007003, 326, "Available",1003),
            new Magazine("Hot Java Monthly", 90008001, 81, "Available",2001),
            new Magazine("Designers Digest", 90008002, 56, "Available",2002),
            new Magazine("C# Junkies - Jan Issue", 90008003, 62, "Available",2003),
            new DVD("Assembly Language Tutor", 90009001, 86, "Available",3001),
            new DVD("Mastering C Pointers", 90009002, 93, "Available",3002),
            new DVD("Javascript For Kids", 90009003, 24, "Available",3003)
            };


        static void Main(string[] args)
        {
            StreamWriter AllBooks = new StreamWriter(@"Books.txt");
            using (AllBooks)
            {
                AllBooks.WriteLine("\n*****All Books*****\n\n\n");
                foreach(Resource item in resources)
                {
                    if (item.GetType().Name == "Book")
                    {
                        AllBooks.WriteLine(item.Id + " " + item.Title);
                    }
                }
            }
            StreamWriter AllMags = new StreamWriter(@"Magazines.txt");
            using (AllMags)
            {
                AllMags.WriteLine("\n*****All Magazines*****\n\n\n");
                foreach (Resource item in resources)
                {
                    if (item.GetType().Name == "Magazine")
                    {
                        AllMags.WriteLine(item.Id + " " + item.Title);
                    }
                }
            }
            StreamWriter AllDVDs = new StreamWriter(@"DVDs.txt");
            using (AllDVDs)
            {
                AllDVDs.WriteLine("\n*****All DVDs*****\n\n\n");
                foreach (Resource item in resources)
                {
                    if (item.GetType().Name == "DVD")
                    {
                        AllDVDs.WriteLine(item.Id + " " + item.Title);
                    }
                }
            }

            StudentFiles(Students);

            while (true)
            {                
                Header(menu0);
                int menuChoice = ValidateMenu(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        //View All Resources(read from a file)
                        //      Resources titles only need to be included in the file
                        Header(menu1);
                        StreamWriter AllResources = new StreamWriter(@"AllResources.txt");
                        using (AllResources)
                        {
                            for (int i = 0; i < resources.Count(); i++)
                            {
                                AllResources.WriteLine((i+1) + ". " + resources[i].Title + " (" + resources[i].GetType().Name + ")");
                            }
                        }

                        StreamReader AllResourcesRead = new StreamReader(@"AllResources.txt");
                        using (AllResourcesRead)
                        {

                            Console.WriteLine(AllResourcesRead.ReadToEnd());
                        }
                        Footer();

                        break;
                    case 2:
                        //View Available Resources
                        Header(menu2);

                        ViewResources("Available");
                        Console.WriteLine("\n\nWould you like to see checked out resources? Y/N\n");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            StreamReader CheckedOutResourcesReader = new StreamReader(@"CheckedOutResources.txt");
                            using (CheckedOutResourcesReader)
                            {
                                Console.WriteLine("\n\n" + CheckedOutResourcesReader.ReadToEnd());
                            }
                        } else
                        {
                            continue;
                        }


                        Footer();
                        break;

                    case 3:
                        //    //Edit Resources
                        Header(menu3);
                        AllResourcesRead = new StreamReader(@"AllResources.txt");
                        using (AllResourcesRead)
                        {
                            Console.WriteLine(AllResourcesRead.ReadToEnd());
                        }
                        
                        Console.WriteLine("Choose a resource to edit.");
                        int edit = ValidateMenu(Console.ReadLine())-1;
                        //Header(menu3);
                        resources[edit].EditTitle(menu3);
                        break;
                    case 4:
                        //    //View Student Accounts
                        Header(menu4);
                        Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                        string userRequest = Console.ReadLine().ToUpper();

                        string validUserRequest = ValidName(userRequest);
                        int studentFileReq = Students[validUserRequest];


                        string fileName = studentFileReq + ".txt";
                        try
                        {
                            StreamReader srStudentAcct = new StreamReader(fileName);
                            Console.WriteLine("\n\nStudent Account for " + validUserRequest.ToUpper() + ": \n");
                            using (srStudentAcct)
                            {
                                Console.WriteLine(srStudentAcct.ReadToEnd());
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.Error.WriteLine("This student is not in the system. Please check spelling and try again or register new student.");
                        }
                        catch (IOException)
                        {
                            Console.Error.WriteLine("Cannot open the file {0}", fileName);
                        }


                        Footer();
                        break;



                    case 5:
                    //    //View All Students(read from a file)
                    //    //Student names are all that is required for the file
                        Header(menu5);
                        StreamWriter AllStudentsWrite = new StreamWriter(@"AllStudents.txt");
                        using (AllStudentsWrite)
                        {
                            int i = 1;
                            foreach (KeyValuePair<string, int> student in Students)
                            {
                                AllStudentsWrite.WriteLine(i + ". " + student.Key);
                                i++;
                            }
                        }
                        StreamReader AllStudentsRead = new StreamReader(@"AllStudents.txt");
                        using (AllStudentsRead)
                        {
                            Console.WriteLine(AllStudentsRead.ReadToEnd());
                        }

                        Footer();
                        break;

                    case 6:
                        //    //Check OUT Resource
                        Header(menu6);
                        Console.WriteLine("\n\nEnter student name:\n--Type \"Help\" to see list of students.");
                        string validatedRequest = ValidName(Console.ReadLine());
                        int studentId = Students[validatedRequest];
                        Console.WriteLine("\n\nEnter resource ID:\n--Type \"Help\" to see available resources.");
                        int validRes = ValidResourceOut(Console.ReadLine());
                        string due;
                        
                        StreamWriter AddTitleToCOR = new StreamWriter(@"CheckedOutResources.txt", true);
                        StreamWriter AddTitleToStudent = new StreamWriter(studentId + ".txt", true);
                        using (AddTitleToStudent)
                        {
                            using (AddTitleToCOR)
                            {
                                foreach (Resource item in resources)
                                {
                                    if (item.Id == validRes)
                                    {
                                        due = item.CheckOut();
                                        AddTitleToStudent.WriteLine($"{item.Id} {item.Title} ({item.GetType().Name}) - Due:{due}");
                                        AddTitleToCOR.WriteLine($"{item.Id} {item.Title} - Due:{due}");
                                    }
                                }

                            }
                        }
                            Footer();
                            break;
                    case 7:
                        //    //Check IN Resource
                        Header(menu7);
                        

                        Console.WriteLine("\n\nEnter student name:\n--Type \"Help\" to see list of students.");
                        
                        validatedRequest = ValidName(Console.ReadLine());
                        studentId = Students[validatedRequest];
                        Console.WriteLine($"\n\nEnter resource ID:\n--Type \"Help\" to see {validatedRequest.ToUpper()}'s Checked Out Resources.\n");
                        validRes = ValidResourceIn(Console.ReadLine(),validatedRequest);
                        
                        //if SR line !contain validRes, cw
                        string[] studentAcct = System.IO.File.ReadAllLines(studentId + ".txt");
                        IEnumerable<string> studentAcctUpdate = studentAcct.Where(line => !line.Contains(validRes.ToString()));
                        System.IO.File.WriteAllLines(studentId + ".txt", studentAcctUpdate);

                        string[] checkedOutFile = System.IO.File.ReadAllLines(@"CheckedOutResources.txt");
                        IEnumerable<string> checkedOutFileUpdate = checkedOutFile.Where(line => !line.Contains(validRes.ToString()));
                        System.IO.File.WriteAllLines(@"CheckedOutResources.txt", checkedOutFileUpdate);

                        foreach (Resource item in resources)
                        {
                            if (item.Id == validRes)
                            {
                                item.CheckIn();
                            }
                        }

                        StreamReader studentAcctReview = new StreamReader(studentId + ".txt");
                        using (studentAcctReview)
                        {
                            Console.WriteLine(("\n\n" + studentAcctReview.ReadToEnd());
                        }
                        
                        Footer();
                        break;

                    case 8:
                        Header(menu8);
                        Console.WriteLine("\n\n\nWould you like to clear student accounts? Y/N \n\nThis will \"return\" all books.");
                        string clearChoice = Console.ReadLine().ToUpper();
                        if (clearChoice == "Y")
                        {
                            StudentFiles(Students);
                            StringBuilder printCleared = new StringBuilder();
                            foreach (KeyValuePair<string, int> student in Students)
                            {
                                printCleared.Append(student.Key);
                                printCleared.Append(" ");
                                printCleared.Append(student.Value.ToString());
                                printCleared.Append("\t--  File Cleared\n");
                            }
                            Console.WriteLine(printCleared);
                        }



                        Footer();
                        break;
                    case 9:
                        return;
                    
                    
                    default:
                        break;
                }
            }
            
        }

        static void Header(string menu)
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

        static void Footer()
        {
            Console.WriteLine("\n\nHit any key to continue.");
            Console.ReadKey();
        }

        static string ValidName(string userRequest)
        {

            int studentFileReq = 0;
            bool validName = true;

            while (validName)
            {

                if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ListStudents(Students);
                    Console.WriteLine("\n\nEnter student name:");
                    userRequest = Console.ReadLine().ToUpper();
                }
                try
                {
                    studentFileReq = Students[userRequest];
                    validName = false;
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("This student is not in the system. Please check spelling and try again or register new student.");
                    Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                    userRequest = Console.ReadLine().ToUpper();
                }


            }
            return userRequest;
        }

        static void ListStudents(Dictionary<string, int> Students)
        {
            int a = 1;
            foreach (KeyValuePair<string, int> student in Students.OrderBy(i => i.Value))
            {
                Console.WriteLine(a + ". " + student.Key);
                a++;
            }
        }

        static void StudentFiles(Dictionary<string, int> Students)
        {
            foreach (KeyValuePair<string, int> student in Students)
            {
                StreamWriter NewFile = new StreamWriter(student.Value + ".txt");
                NewFile.WriteLine($"\n{student.Key.ToUpper()}'S CHECKED OUT RESOURCES: \n\n");
                NewFile.Close();
            }

            StreamWriter CleanDictionary = new StreamWriter("CheckedOutResources.txt");
            CleanDictionary.WriteLine("\n****Checked Out Resources****\n\n");
            CleanDictionary.Close();

        }

        static void ViewResources(string status)
        {
            for (int i = 0; i < resources.Count(); i++)
            {
                if (resources[i].Status == status)
                {
                    Console.WriteLine(resources[i].Id + " " + resources[i].Title + " (" + resources[i].GetType().Name + ")");
                }
            }

        }

        static int ValidResourceOut(string resReq)
        {
            int validatedRes = 0;

            bool tryAgain = false;
            while (!tryAgain)
            {
                if (resReq.ToUpper() == "HELP")
                {
                    ViewResources("Available");

                    Console.Write("\nEnter resource ID: ");
                    resReq = Console.ReadLine();

                } else
                {
                    tryAgain = int.TryParse(resReq, out validatedRes);
                    if (tryAgain)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter a valid ID or type \"Help\": ");
                        resReq = Console.ReadLine();
                    }
                }
            }
            return validatedRes;
        }


        static int ValidResourceIn(string resReq, string student)
        {
            int validatedRes = 0;

            bool tryAgain = false;
            while (!tryAgain)
            {
                if (resReq.ToUpper() == "HELP")
                {
                    StreamReader StudentAcct = new StreamReader(Students[student] + ".txt");
                    using (StudentAcct)
                    {
                        Console.WriteLine("\n\n" + StudentAcct.ReadToEnd());
                    }

                    Console.Write("\nEnter resource ID: ");
                    resReq = Console.ReadLine();

                } else
                {
                    tryAgain = int.TryParse(resReq, out validatedRes);
                    if (tryAgain)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter a valid ID or type \"Help\": ");
                        resReq = Console.ReadLine();
                    }
                }
            }
            
            return validatedRes;
        }

    }
}
