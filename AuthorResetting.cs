using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class AuthorResetting
    {
        public static void Reset(Book[] library)
        {
            bool exceptionChoice = false;
            if (library.Length != 0)
            {
                while (exceptionChoice == false)
                {
                    try
                    {
                        library[Program.EnteringIndex(library.Length)].ReSetAuthor();
                        exceptionChoice = true;
                        Console.WriteLine("The author has been changed! ");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value has been entered.");
                        Program.PressAndContinue();
                    }
                }
            }
            else
                Console.WriteLine("Your library is empty. Add books first.");
        }
    }
}
