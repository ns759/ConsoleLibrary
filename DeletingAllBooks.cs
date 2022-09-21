﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class DeletingAllBooks
    {
        public static Book[] Delete(Book[] library)
        {
            if (library.Length != 0)
            {
                Array.Resize(ref library, library.Length - library.Length);
                Console.WriteLine("All books have been deleted. ");
            }
            else
            {
                Console.WriteLine("Your library is empty. Add books first.");
            }
            Program.PressAndContinue();
            return library;
        }
    }
}
