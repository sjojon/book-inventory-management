using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void SellBook(string title, int count)
        {
        }
    }
}