using System.ComponentModel.Design;
using System.Reflection;
using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

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
                Console.WriteLine("Menu:\n1. Add book\n2. Display books\n3. Edit books\n4. Exit");
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
                            Console.Clear();
                            library.DisplayAllBooks();
                            EditMenu(library);
                            break;
                        case 4:
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

        public static void EditMenu(Library library)
        {
            Console.WriteLine("Enter the name of the book you want to edit:");
            string getIndex = Console.ReadLine().ToLower();
            Console.Clear();
            int index = library.FindBookIndex(getIndex);

            if (index == -1) return;
            Book book = library.GetBook(index);
            book.DisplayBookDetails();
            Console.WriteLine(
                "What property do you want to edit?\n1. Title\n2. Author\n3. Genre\n4. Add copies\n5. Sell copies\n6. Sell all books");
            string inputAnswer = Console.ReadLine();
            bool number = int.TryParse(inputAnswer, out int answer);
            if (number)
            {
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Edit title:");
                        string newTitle = Console.ReadLine();
                        book.UpdateTitle(newTitle);
                        Console.Clear();
                        book.DisplayBookDetails();
                        Console.WriteLine("Title updated");
                        library.DisplayAllBooks();
                        break;
                    case 2:
                        Console.WriteLine("Edit Author:");
                        string newAuthor = Console.ReadLine();
                        book.UpdateAuthor(newAuthor);
                        Console.Clear();
                        book.DisplayBookDetails();
                        Console.WriteLine("Author updated");
                        library.DisplayAllBooks();
                        break;
                    case 3:
                        Console.WriteLine("Edit genre:");
                        string newGenre = Console.ReadLine();
                        book.UpdateGenre(newGenre);
                        Console.Clear();
                        book.DisplayBookDetails();
                        Console.WriteLine("Genre updated");
                        library.DisplayAllBooks();
                        break;
                    case 4:
                        Console.WriteLine("Enter the number of copies to add:");
                        string addCopies = Console.ReadLine();
                        int addCount = Convert.ToInt32(addCopies);
                        book.AddCopies(addCount);
                        Console.Clear();
                        book.DisplayBookDetails();
                        Console.WriteLine("Book bought and added to library");
                        library.DisplayAllBooks();
                        break;
                    case 5:
                        Console.WriteLine("Enter the number of copies to sell:");
                        string sellCopies = Console.ReadLine();
                        int sellCount = Convert.ToInt32(sellCopies);

                        while (sellCount > book.Quantity)
                        {
                            Console.WriteLine("You can't sell more books than currently in inventory!");
                            Console.WriteLine("Enter a valid number to sell:");
                            sellCopies = Console.ReadLine();
                            sellCount = Convert.ToInt32(sellCopies);
                        }

                        book.SellCopies(sellCount);
                        Console.Clear();

                        if (book.Quantity == 0)
                        {
                            library.SellBook(book);
                            Console.WriteLine("You sold all copies of this book!");
                        }

                        Console.WriteLine("Book(s) sold and removed from library");
                        book.DisplayBookDetails();
                        library.DisplayAllBooks();
                        break;
                    case 6:
                        library.SellBook(book);
                        book.DisplayBookDetails();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("ALL BOOKS SOLD!");
                        Console.WriteLine();
                        library.DisplayAllBooks();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Please enter a number!");
            }
        }
    }
}