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
                        case 1: // Add book
                            AddBook(library);

                            //library.AddBook(new Book(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(),
                            //    int.Parse(Console.ReadLine())));
                            Console.Clear();
                            library.DisplayAllBooks();
                            break;
                        case 2: // Display books
                            Console.Clear();
                            library.DisplayAllBooks();
                            break;
                        case 3: // Edit books
                            Console.Clear();
                            library.DisplayAllBooks();
                            EditMenu(library);
                            break;
                        case 4: //Exit
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

        private static void AddBook(Library library)
        {
            Console.WriteLine(
                "Please enter a book to add:");
            Console.WriteLine("Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Author:");
            string author = Console.ReadLine();
            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();

            Book book = new Book(title, author, genre);
            library.AddBook(book);

            Console.WriteLine("Number of books to add to library:");
            int quantity = int.Parse(Console.ReadLine());

            library.AddCopies(book, quantity);
        }

        private static Library Initialize()
        {
            Library library = new();
            //library.AddBook(new Book("Lord of the Rings", "J.R.R. Tolkien", "Fantasy"));
            //library.AddBook(new Book("Narnia", "C. S. Lewis", "Fantasy"));
            //library.AddBook(new Book("The Name of the Wind", "Patrick Rothfuss", "Fantasy"));
            Book book1 = new Book("Lord of the Rings", "J.R.R. Tolkien", "Fantasy");
            library.AddBook(book1);
            library.AddCopies(book1, 3);

            Book book2 = new Book("Narnia", "C. S. Lewis", "Fantasy");
            library.AddBook(book2);
            library.AddCopies(book2, 4);

            Book book3 = new Book("The Name of the Wind", "Patrick Rothfuss", "Fantasy");
            library.AddBook(book3);
            library.AddCopies(book3, 2);
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
                    case 1: // Edit title
                        EditTitle(library, book);
                        break;
                    case 2: // Edit author
                        EditAuthor(library, book);
                        break;
                    case 3: // Edit genre
                        EditGenre(library, book);
                        break;
                    case 4: // Number of copies to add
                        NumberOfCopiesToAdd(library, book);
                        break;
                    case 5: // Number of copies to sell
                        NumberOfCopiesToSell(library, book);
                        break;
                    case 6: // Sell all books
                        SellAllBooks(library, book);
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

        private static void SellAllBooks(Library library, Book book)
        {
            library.SellBook(book);
            book.DisplayBookDetails();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("ALL BOOKS SOLD!");
            Console.WriteLine();
            library.DisplayAllBooks();
        }

        private static void NumberOfCopiesToSell(Library library, Book book)
        {
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

            library.SellCopies(book, sellCount);
            Console.Clear();

            if (book.Quantity == 0)
            {
                library.SellBook(book);
                Console.WriteLine("You sold all copies of this book!");
            }

            Console.WriteLine("Book(s) sold and removed from library");
            book.DisplayBookDetails();
            library.DisplayAllBooks();
        }

        private static void NumberOfCopiesToAdd(Library library, Book book)
        {
            Console.WriteLine("Enter the number of copies to add:");
            string addCopies = Console.ReadLine();
            int addCount = Convert.ToInt32(addCopies);
            library.AddCopies(book, addCount);
            Console.Clear();
            book.DisplayBookDetails();
            Console.WriteLine("Book bought and added to library");
            library.DisplayAllBooks();
        }

        private static void EditGenre(Library library, Book book)
        {
            Console.WriteLine("Edit genre:");
            string newGenre = Console.ReadLine();
            book.UpdateGenre(newGenre);
            Console.Clear();
            book.DisplayBookDetails();
            Console.WriteLine("Genre updated");
            library.DisplayAllBooks();
        }

        private static void EditAuthor(Library library, Book book)
        {
            Console.WriteLine("Edit Author:");
            string newAuthor = Console.ReadLine();
            book.UpdateAuthor(newAuthor);
            Console.Clear();
            book.DisplayBookDetails();
            Console.WriteLine("Author updated");
            library.DisplayAllBooks();
        }

        private static void EditTitle(Library library, Book book)
        {
            Console.WriteLine("Edit title:");
            string newTitle = Console.ReadLine();
            book.UpdateTitle(newTitle);
            Console.Clear();
            book.DisplayBookDetails();
            Console.WriteLine("Title updated");
            library.DisplayAllBooks();
        }
    }
}