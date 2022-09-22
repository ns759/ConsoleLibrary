using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class TitleResetting
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
                        int bookIndex = Program.EnteringIndex(library.Length);
                        exceptionChoice = true;
                        library[bookIndex].ReSetTitle();
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
