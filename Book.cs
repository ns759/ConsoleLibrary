using System;
using System.Collections.Generic;
using System.Text;

namespace Project_3
{
    class Book
    {
        private string author;
        private string title;
        private int pages;
        public Book()
        {

        }
        public void SetBookFromFile(string title, string author, string pagesStr)
        {
            this.title = title;
            this.author = author;
            this.pages = Convert.ToInt32(pagesStr);
        }
        public void SetBook(int bookIndex)
        {
            bool exceptionBookSetter = false;
            while (exceptionBookSetter == false)
            {
                try
                {
                    Console.Write("Set the title for the book number " + bookIndex + ": ");
                    string title = Console.ReadLine();
                    if (title != "")
                    {
                        this.title = title;
                    }
                    else
                        Convert.ToInt32("No.");
                    exceptionBookSetter = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter the book title.");
                    Program.PressAndContinue();
                }
            }
            Console.Clear();

            Console.Write("Set the author for the book number " + bookIndex + ": ");
            string author = Console.ReadLine();
            if (author != "")
                this.author = author;
            else
                this.author = "No Author";
            Console.Clear();
            exceptionBookSetter = false;
            while (exceptionBookSetter == false)
            {
                try
                {
                    Console.Write("Set the number of pages for the book number " + bookIndex + ": ");
                    string pagesStr = Console.ReadLine();
                    if (pagesStr != "")
                        pages = Convert.ToInt32(pagesStr);
                    else
                        pages = 0;
                    exceptionBookSetter = true;
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value has been entered.");
                    Program.PressAndContinue();
                }
            }
        }
        public void ReSetTitle()
        {
            bool exceptionBookSetter = false;
            while (exceptionBookSetter == false)
            {
                try
                {
                    Console.WriteLine("Change the title for the book");
                    string title = Console.ReadLine();
                    Console.Clear();
                    if (title != "")
                    {
                        if (title != this.title)
                        {
                            this.title = title;
                            Console.WriteLine("The title has been changed!");
                        }
                        else
                        {
                            Console.WriteLine("You entered the same title.");
                        }
                    }
                    else
                        Convert.ToInt32("");
                    exceptionBookSetter = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter the book title.");
                    Program.PressAndContinue();
                }
            }
            Console.Clear();
        }
        public void ReSetAuthor()
        {
            Console.Write("Change the author for the book: ");
            this.author = Console.ReadLine();
            Console.Clear();
        }
        public void ReSetPages()
        {
            bool exceptionPageReSetter = false;
            while (exceptionPageReSetter == false)
            {
                try
                {
                    Console.Write("Change the number of pages for the book: ");
                    pages = Convert.ToInt32(Console.ReadLine());
                    exceptionPageReSetter = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value has been entered.");
                    Program.PressAndContinue();
                }
                Console.Clear();
            }
        }
        public void GetBook(out string title, out string author, out int pages)
        {
            title = this.title;
            author = this.author;
            pages = this.pages;
        }
        public string GetTitle()
        {
            return title;
        }
        public string GetAuthor()
        {
            return author;
        }
        public int GetPages()
        {
            return pages;
        }
    }
}
