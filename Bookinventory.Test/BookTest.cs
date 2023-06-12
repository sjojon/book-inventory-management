using System.Reflection;
using book_inventory_management;

namespace BookInventory.Test
{
    public class BookTest
    {
        [Test]
        public void BookConstructorTest()
        {
            string title = "Title";
            string author = "Author";
            string genre = "genre";
            Book book = new Book(title, author, genre);
            Book narnia = new Book("narnia", "c.s lewis", "fantasy");

            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(0, book.Id);
            Assert.AreEqual(1, narnia.Id);
        }
    }
}