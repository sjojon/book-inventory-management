namespace book_inventory_management
{
    public class Library
    {
        private List<Book> books;
        public Dictionary<Book, int> numberOfBooks;

        public Library()
        {
            books = new List<Book>();
            numberOfBooks = new Dictionary<Book, int>();
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("Books currently in the library:");
            Console.WriteLine();
            foreach (var book in books)
            {
                book.DisplayBookDetails();
            }
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            if (numberOfBooks.ContainsKey(book))
            {
                numberOfBooks[book] = book.Quantity;
            }
            else
            {
                numberOfBooks[book] = book.Quantity;
            }

            book.Library = this;
        }

        public void SellBook(Book book)
        {
            books.Remove(book);
            if (numberOfBooks.ContainsKey(book))
            {
                numberOfBooks[book]--;
                if (numberOfBooks[book] <= 0)
                {
                    numberOfBooks.Remove(book);
                }
            }

            book.Library = null;
        }

        public void AddCopies(Book book, int count) //Increases the quantity of the book by the specified count.
        {
            if (numberOfBooks.ContainsKey(book))
            {
                numberOfBooks[book] += count;
            }
            else
            {
                numberOfBooks[book] = count;
            }
        }

        public void SellCopies(Book book, int count) //Decreases the quantity of the book by the specified count.
        {
            if (numberOfBooks.ContainsKey(book))
            {
                numberOfBooks[book] -= count;
                if (numberOfBooks[book] < 0)
                {
                    numberOfBooks[book] = 0;
                }
            }
        }

        public int FindBookIndex(string title)
        {
            string lowerTitle = title.ToLower();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == lowerTitle)
                {
                    return i;
                }
            }

            return -1;
        }

        public Book GetBook(int index)
        {
            if (index >= 0 && index < books.Count)
            {
                return books[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid book index");
            }
        }
    }
}