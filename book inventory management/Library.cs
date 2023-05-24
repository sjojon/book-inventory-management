namespace book_inventory_management
{
    internal class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
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
        }

        public void SellBook(Book book)
        {
            books.Remove(book);
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