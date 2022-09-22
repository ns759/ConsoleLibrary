using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class PagesResetting
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
                        library[Program.EnteringIndex(library.Length)].ReSetPages();
                        exceptionChoice = true;
                        Console.WriteLine("The number of pages has been changed! ");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                        Program.PressAndContinue();
                    }
                }
            }
            else
                Console.WriteLine("Your library is empty. Add books first.");
        }
    }
}
