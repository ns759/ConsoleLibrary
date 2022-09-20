using System;
using System.IO;

namespace Project_3
{
    class Program
    {
        static readonly string path;
        static void Main(string[] args)
        {
            int numOfBooks;//Number of books in the library
            string choice;
            Book[] library = new Book[] { };
            Console.WriteLine("Welcome!");
            PressAndContinue();
            //Cheking if file has been created and creating the new one if not
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) { fs.Close(); }
            numOfBooks = FileReading(path).Length;
            library = CopyingFromFileToLibrary(numOfBooks, library);
            do
            {
                bool exceptionChoice = false;
                bool alreadyDone = false;
                choice = MainMenuChoice();
                numOfBooks = library.Length;
                switch (choice)
                {
                    //Done
                    case ("1"):
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
                                PressAndContinue();
                            }
                        }
                        break;
                    //Done
                    case ("2"):
                        if (numOfBooks == 0)
                        {
                            Console.WriteLine("Your library is empty. Add books first.");
                            PressAndContinue();
                            continue;
                        }
                        while (exceptionChoice == false)
                        {
                            try
                            {
                                Console.Write("Enter the book index: ");
                                int delIndex = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (delIndex < 0 || delIndex > (library.Length))
                                    Convert.ToInt32("");
                                exceptionChoice = true;
                                if (delIndex != library.Length)
                                {
                                    for (int i = delIndex - 1; i < library.Length - 1; i++)
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
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }                        
                        break;
                    case ("3"):
                        if (numOfBooks != 0)
                        {
                            Console.WriteLine("Your library is empty. Add books first.");
                            PressAndContinue();
                            continue;
                        }
                        Array.Resize(ref library, library.Length - library.Length);
                        Console.WriteLine("All books have been deleted. ");
                        break;
                    case ("4"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    int bookIndex = EnteringIndex(numOfBooks);
                                    exceptionChoice = true;
                                    library[bookIndex].GetBook(out string titleGet, out string authorGet, out int pagesGet);
                                    Console.WriteLine("Book number " + (bookIndex + 1));
                                    Console.WriteLine(titleGet);
                                    Console.WriteLine("by " + authorGet);
                                    Console.WriteLine(pagesGet + " pages\n");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first. ");
                        break;
                    case ("5"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    int bookIndex = EnteringIndex(numOfBooks);
                                    exceptionChoice = true;
                                    library[bookIndex].ReSetTitle();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first.");
                        break;
                    case ("6"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    int bookIndex = EnteringIndex(numOfBooks);
                                    exceptionChoice = true;
                                    library[bookIndex].ReSetAuthor();
                                    Console.WriteLine("The author has been changed!");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first.");
                        break;
                    case ("7"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    library[EnteringIndex(numOfBooks)].ReSetPages();
                                    exceptionChoice = true;
                                    Console.WriteLine("The number of pages has been changed! ");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first.");
                        break;
                    case ("8"):
                        if (numOfBooks != 0)
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
                        break;
                    case ("9"):
                        if (numOfBooks == 0)
                        {
                            Console.WriteLine("Your library is empty. Add books first.");
                            PressAndContinue();
                            continue;
                        }
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
                                PressAndContinue();
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
                        break;
                    case ("10"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                Console.WriteLine("Enter the author you want to find");
                                string authorFind = Console.ReadLine();
                                Console.Clear();
                                if (authorFind == "")
                                    authorFind = "No Author";
                                exceptionChoice = true;
                                bool search = false;
                                for (int i = 0; i < library.Length; i++)
                                {
                                    if (library[i].GetAuthor() == authorFind)
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
                                {
                                    Console.WriteLine("No books found");
                                }
                                Console.WriteLine("Enter 1, if you want to search once more");
                                Console.WriteLine("Enter anything else to return to the main menu");
                                string choice2 = Console.ReadLine();
                                Console.Clear();
                                if (choice2 == "1")
                                    exceptionChoice = false;
                                else
                                    alreadyDone = true;
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first.");
                        break;
                    case ("11"):
                        if (numOfBooks != 0)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the number of pages you want to find");
                                    string pagesFindStr = Console.ReadLine();
                                    if (pagesFindStr == "")
                                        pagesFindStr = "0";
                                    int pagesFind = Convert.ToInt32(pagesFindStr);
                                    if (pagesFind < 0)
                                    {
                                        Convert.ToInt32("No.");
                                    }
                                    Console.Clear();
                                    exceptionChoice = true;
                                    bool search = false;
                                    for (int i = 0; i < library.Length; i++)
                                    {
                                        if (library[i].GetPages() == pagesFind)
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
                                    {
                                        Console.WriteLine("No books found");
                                    }
                                    Console.WriteLine("Enter 1, if you want to search once more");
                                    Console.WriteLine("Enter anything else to return to the main menu");
                                    string choice2 = Console.ReadLine();
                                    Console.Clear();
                                    if (choice2 == "1")
                                        exceptionChoice = false;
                                    else
                                        alreadyDone = true;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                            Console.WriteLine("Your library is empty. Add books first.");
                        break;
                    case ("12"):
                        if (numOfBooks != 0 && numOfBooks != 1)
                        {
                            while (exceptionChoice == false)
                            {
                                try
                                {
                                    if (numOfBooks != 2)
                                    {
                                        Console.WriteLine("The first book:");
                                        int bookIndex1 = EnteringIndex(numOfBooks);
                                        Console.WriteLine("The second book:");
                                        int bookIndex2 = EnteringIndex(numOfBooks);
                                        Console.Clear();
                                        exceptionChoice = true;
                                        if (bookIndex1 == bookIndex2)
                                            Console.WriteLine("The indices were same.");
                                        else
                                        {
                                            Book book1 = new Book { };
                                            book1 = library[bookIndex2];
                                            library[bookIndex2] = library[bookIndex1];
                                            library[bookIndex1] = book1;
                                            Console.WriteLine("The books have been switched.");
                                        }
                                    }
                                    else
                                    {
                                        exceptionChoice = true;
                                        Book book1 = new Book { };
                                        book1 = library[1];
                                        library[1] = library[0];
                                        library[0] = book1;
                                        Console.WriteLine("The books have been switched.");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid value has been entered. Press any button and enter it once more");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                Console.WriteLine("Enter 1, if you want to search once more");
                                Console.WriteLine("Enter anything else to return to the main menu");
                                string choice2 = Console.ReadLine();
                                Console.Clear();
                                if (choice2 == "1")
                                    exceptionChoice = false;
                                else
                                    alreadyDone = true;
                            }
                        }
                        else
                            Console.WriteLine("There aren't enough books in your library. Add books first.");
                        break;
                    case ("13"):
                        SavingToFile(library, path);
                        Console.WriteLine("Changes are saved");
                        break;
                    case ("0"):
                        Console.WriteLine("Would you like to save changes?\nEnter 1 if you do and anything else if you don't");
                        if (Console.ReadLine() == "1")
                            SavingToFile(library, path);
                        break;
                    default:
                        Console.Write("Invalid value has been entered. ");
                        break;
                }
                if (alreadyDone == true)
                    continue;
                PressAndContinue();
            } while (choice != "0");
        }
        /// <summary>
        /// Static variable for the file path
        /// </summary>
        static Program()
        {
            path = "C:\\Users\\new user\\File.txt";
        }
        /// <summary>
        /// Copies all the books from the file to the library
        /// </summary>
        /// <param name="numOfBooks"> Number of books to be copied from the file to the library </param>
        /// <param name="library"> The array of books where the file data will be copied to </param>
        static Book[] CopyingFromFileToLibrary(int numOfBooks, Book[] library)
        {
            if (numOfBooks != 0)
            {
                Array.Resize(ref library, library.Length + numOfBooks);
                for (int i = 0; i < numOfBooks; i++)
                {
                    library[i] = new Book { };
                    library[i].SetBookFromFile(
                        ConvertingTo2dArray(FileReading(path))[i, 0], 
                        ConvertingTo2dArray(FileReading(path))[i, 1], 
                        ConvertingTo2dArray(FileReading(path))[i, 2]);
                }
                Console.WriteLine("The library has been imported from the file.");
            }
            else
                Console.WriteLine("The file is empty. Create new library.");
            PressAndContinue();
            return library;
        }
        /// <summary>
        /// Brings up the main menu and asks to make a choice
        /// </summary>
        static string MainMenuChoice()
        {
            Console.WriteLine("What would you like to do?\n" +
                "Enter 1 if you want to add book/books to the library\n" +
                "Enter 2 if you want to delete a specific book from the library\n" +
                "Enter 3 if you want to delete all books from the library\n" +
                "Enter 4 if you want to get the full description of the specific book\n" +
                "Enter 5 if you want to change the title of the specific book\n" +
                "Enter 6 if you want to change the author of the specific book\n" +
                "Enter 7 if you want to change the number of pages of the specific book\n" +
                "Enter 8 if you want to get the full descriptions of all the books\n" +
                "Enter 9 if you want to find book/books by title\n" +
                "Enter 10 if you want to find book/books by author\n" +
                "Enter 11 if you want to find book/books by number of pages\n" +
                "Enter 12 if you want to switch books in the library\n" +
                "Enter 13 if you want to save changes to the file\n" +
                "Enter 0 if you want to finish");
            string choice = Console.ReadLine();
            Console.Clear();
            return choice;
        }
        /// <summary>
        /// Asks user for the index and checks the input format
        /// </summary>
        /// <param name="numOfBooks">Number of books in the library</param>
        /// <returns>Index of the book user wants to work with</returns>
        static int EnteringIndex(int numOfBooks)
        {
            Console.Write("Enter the book index: ");
            int bookIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if (bookIndex < 0 && bookIndex >= numOfBooks)
                Convert.ToInt32("");
            Console.Clear();
            return bookIndex;
        }
        /// <summary>
        /// Reads file and puts data to the string array
        /// </summary>
        /// <param name="path">an absolute link to the file</param>
        /// <returns>Array of strings. Strings represents books in the format "Title Author Pages"</returns>
        static string[] FileReading(string path)
        {
            string[] arrayFileLines = new string[] { };
            string[] arrayBookElements;
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    arrayBookElements = line.Split('_');
                    line = "";
                    for (int i = 0; i < arrayBookElements.Length; i++)
                    {
                        line += arrayBookElements[i];
                        if (i == arrayBookElements.Length - 1)
                            break;
                        else
                            line += " ";
                    }
                    Array.Resize(ref arrayFileLines, arrayFileLines.Length + 1);
                    arrayFileLines[^1] = line;
                }
            }
            
            return arrayFileLines;
        }
        /// <summary>
        /// Converts string array from the FileReading method to the 2d array
        /// </summary>
        /// <param name="array">String array from the FileReading method</param>
        /// <returns>2d array which represents elements of the books. Example:
        ///[Title 1][Author 1][Pages 1]
        ///[Title 2][Author 2][Pages 2]
        /// </returns>
        static string[,] ConvertingTo2dArray(string[] array)
        {
            string[,] array2d = new string[array.Length, 3];
            for (int i = 0; i < array.Length; i++)
            {
                string[] arrayHelp = array[i].Split('¬');
                for (int j = 0; j < 3; j++)
                {
                    array2d[i, j] = arrayHelp[j];
                }
            }
            return array2d;
        }
        /// <summary>
        /// Saves the data taken from the console to the file
        /// </summary>
        /// <param name="libraryInstance">Array of the book type variables</param>
        /// <param name="path">an absolute link to the file</param>
        static void SavingToFile(Book[] libraryInstance, string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                string textLine;
                string[] titleArray = new string[]{ };
                string titleString = "";
                string[] authorArray = new string[] { };
                string authorString = "";
                int numOfBooksForFile = libraryInstance.Length;
                for (int i = 0; i<numOfBooksForFile; i++)
                {
                    titleString = "";
                    authorString = "";
                    titleArray = libraryInstance[i].GetTitle().Split(' ');
                    for(int j=0; j<titleArray.Length; j++)
                    {
                        titleString += titleArray[j];
                        if (j == titleArray.Length - 1)
                        {
                            break;
                        }
                        else
                        {
                            titleString += "_";
                        }
                    }
                    authorArray = libraryInstance[i].GetAuthor().Split(' ');
                    for (int j = 0; j < authorArray.Length; j++)
                    {
                        authorString += authorArray[j];
                        if (j == authorArray.Length - 1)
                        {
                            break;
                        }
                        else
                        {
                            authorString += "_";
                        }
                    }
                    textLine = titleString + "¬" + authorString + "¬" + Convert.ToString(libraryInstance[i].GetPages());
                    sw.WriteLine(textLine);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.Clear();
        }
        static void PressAndContinue()
        {
            Console.Write("Press any button to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}