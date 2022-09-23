using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class TitleSearch
    {
        static public void Search(Book[] library)
        {
            if (library.Length != 0)
            {
                bool exceptionChoice = false;
                while (exceptionChoice == false)
                {
                    try
                    {
                        Console.WriteLine("Enter the title you want to find");
                        string titleFind = Console.ReadLine();
                        Console.Clear();
                        if (titleFind == "")
                            Convert.ToInt32("");
                        exceptionChoice = true;
                        bool search = false;
                        for (int i = 0; i < library.Length; i++)
                        {
                            if (library[i].GetTitle() == titleFind)
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
                            Console.WriteLine("No books found");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value has been entered.");
                        Program.PressAndContinue();
                    }
                    Console.WriteLine("Enter 1, if you want to search once more");
                    Console.WriteLine("Enter anything else to return to the main menu");
                    string choice2 = Console.ReadLine();
                    Console.Clear();
                    if (choice2 == "1")
                        exceptionChoice = false;
                    else
                        exceptionChoice = true;
                }
            }
            else
            {
                Console.WriteLine("Your library is empty. Add books first.");
            }
        }
    }
}
