using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace book_inventory_management
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }

        public Book(string newTitle, string newAuthor, string newGenre, int newQuantity)
        {
            Title = newTitle;
            Author = newAuthor;
            Genre = newGenre;
            Quantity = newQuantity;
        }

        public void DisplayBookDetails() //Displays the details of the book (title, author, genre, quantity).
        {
            Console.WriteLine(
                $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nNumber of books: {Quantity}\n");
        }

        public void AddCopies(int count) //Increases the quantity of the book by the specified count.
        {
        }

        public void SellCopies(int count) //Decreases the quantity of the book by the specified count.
        {
        }
    }
}