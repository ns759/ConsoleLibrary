using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class DescriptionAllBooks
    {
        static public void Desription(Book[] library)
        {
            if (library.Length != 0)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    library[i].GetBook(out string titleGet, out string authorGet, out int pagesGet);
                    Console.WriteLine("Book number " + (i + 1));
                    Console.WriteLine(titleGet);
                    Console.WriteLine("by " + authorGet);
                    Console.WriteLine(pagesGet + " pages");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Your library is empty. Add books first.");
        }
    }
}
