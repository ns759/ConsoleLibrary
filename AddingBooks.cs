using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class AddingBooks
    {
        public static Book[] Add(Book[] library)
        {
            bool exceptionChoice = false;
            while (exceptionChoice == false)
            {
                try
                {
                    int previousLength = library.Length;
                    Console.WriteLine("How many books would you like to add?");
                    int newBooksNum = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (newBooksNum <= 0)
                        Convert.ToInt32("");
                    exceptionChoice = true;
                    Array.Resize(ref library, library.Length + newBooksNum);
                    for (int i = previousLength; i < library.Length; i++)
                    {
                        library[i] = new Book() { };
                        library[i].SetBook(i + 1);
                    }

                    if (newBooksNum == 1)
                        Console.WriteLine("New book has been added");
                    else
                        Console.WriteLine("New books have been added");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value has been entered.");
                    Program.PressAndContinue();
                }
            }
            return library;
        }
    }
}
