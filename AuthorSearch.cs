using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class AuthorSearch
    {
        static public void Search(Book[] library)
        {
            if (library.Length != 0)
            {
                bool exceptionChoice = false;
                while (exceptionChoice == false)
                {
                    Console.WriteLine("Enter the author you want to find");
                    string authorFind = Console.ReadLine();
                    Console.Clear();
                    if (authorFind == "")
                        authorFind = "No Author";
                    exceptionChoice = true;
                    bool search = false;
                    for (int i = 0; i < library.Length; i++)
                    {
                        if (library[i].GetAuthor() == authorFind)
                        {
                            library[i].GetBook(out string titleGet, out string authorGet, out int pagesGet);
                            Console.WriteLine("Book number " + (i + 1));
                            Console.WriteLine(titleGet);
                            Console.WriteLine("by " + authorGet);
                            Console.WriteLine(pagesGet + " pages");
                            Console.WriteLine();
                            search = true;
                        }
                    }
                    if (search == false)
                    {
                        Console.WriteLine("No books found");
                    }
                    Console.WriteLine("Enter 1, if you want to search once more");
                    Console.WriteLine("Enter anything else to return to the main menu");
                    string choice2 = Console.ReadLine();
                    Console.Clear();
                    if (choice2 == "1")
                        exceptionChoice = false;
                }
            }
            else
                Console.WriteLine("Your library is empty. Add books first.");
        }
    }
}
