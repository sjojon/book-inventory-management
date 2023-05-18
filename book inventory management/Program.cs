using System.Transactions;

namespace book_inventory_management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine();
            var library = Initialize();

            Menu(library);
        }

        private static void Menu(Library library)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Menu:\n1. Add book\n2. Display books\n3. Exit");
                string inputAnswer = Console.ReadLine();
                bool number = int.TryParse(inputAnswer, out int answer);

                if (number)
                {
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine(
                                "Please enter a book to add:");
                            Console.WriteLine("Title:");
                            string title = Console.ReadLine();
                            Console.WriteLine("Author:");
                            string author = Console.ReadLine();
                            Console.WriteLine("Genre:");
                            string genre = Console.ReadLine();
                            Console.WriteLine("Number of books to add to library:");
                            int quantity = int.Parse(Console.ReadLine());

                            library.AddBook(new Book(title, author, genre, quantity));

                            //library.AddBook(new Book(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(),
                            //    int.Parse(Console.ReadLine())));
                            Console.Clear();
                            library.DisplayAllBooks();
                            break;
                        case 2:
                            Console.Clear();
                            library.DisplayAllBooks();
                            break;
                        case 3:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Please enter 1, 2 or 3!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
        }

        private static Library Initialize()
        {
            Library library = new();
            library.AddBook(new Book("Lord of the Rings", "J.R.R. Tolkien", "Fantasy", 3));
            library.AddBook(new Book("Narnia", "C. S. Lewis", "Fantasy", 4));
            library.AddBook(new Book("The Name of the Wind", "Patrick Rothfuss", "Fantasy", 2));
            return library;
        }
    }
}