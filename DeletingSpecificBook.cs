using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class DeletingSpecificBook
    {
        public static Book[] Delete(Book[] library)
        {
            bool exceptionChoice = false;
            if (library.Length != 0)
            {
                while (exceptionChoice == false)
                {
                    try
                    {
                        int delIndex = Program.EnteringIndex(library.Length);
                        exceptionChoice = true;
                        if (delIndex != library.Length-1)
                        {
                            for (int i = delIndex; i < library.Length; i++)
                            {
                                library[i] = library[i + 1];
                            }
                        }
                        Array.Resize(ref library, library.Length - 1);
                        Console.WriteLine("The book has been deleted");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                        Program.PressAndContinue();
                    }
                }
            }
            else
            {
                Console.WriteLine("Your library is empty. Add books first.");
            }
            return library;
        }
    }
}
