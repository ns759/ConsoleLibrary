using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class DescriptionSpecificBook
    {
        public static void Description(Book[] library)
        {
            int numOfBooks = library.Length;
            bool exceptionChoice = false;
            if (numOfBooks != 0)
            {
                while (exceptionChoice == false)
                {
                    try
                    {
                        int bookIndex = Program.EnteringIndex(numOfBooks);
                        exceptionChoice = true;
                        library[bookIndex].GetBook(out string titleGet, out string authorGet, out int pagesGet);
                        Console.WriteLine("Book number " + (bookIndex + 1));
                        Console.WriteLine(titleGet);
                        Console.WriteLine("by " + authorGet);
                        Console.WriteLine(pagesGet + " pages\n");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value has been entered.");
                        Program.PressAndContinue();
                    }
                }
            }
            else
                Console.WriteLine("Your library is empty. Add books first. ");
        }
    }
}
