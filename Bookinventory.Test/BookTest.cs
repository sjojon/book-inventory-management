using System.Reflection;
using book_inventory_management;

namespace BookInventory.Test
{
    public class BookTest
    {
        private Book book;

        [Test]
        public void BookConstructorTest()
        {
            string title = "Title";
            string author = "Author";
            string genre = "Genre";
            Book book = new(title, author, genre);
            Book narnia = new("Narnia", "C.S. Lewis", "Fantasy");

            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(0, book.Id);
            Assert.AreEqual(1, narnia.Id);
        }

        [Test]
        public void DisplayBookDetailsTest()
        {
            book = new Book("Narnia", "C.S. Lewis", "Fantasy");
            book.DisplayBookDetails();

            // Resharper vil at jeg skal skrive dette isteden
            Assert.That(book.Title, Is.EqualTo("Narnia"));
            Assert.That(book.Author, Is.EqualTo("C.S. Lewis"));
            Assert.That(book.Genre, Is.EqualTo("Fantasy"));
        }

        [Test]
        public void UpdateTitleTest()
        {
            Book book = new("Narnia", "C.S. Lewis", "Fantasy");
            string newTitle = "Test";

            book.UpdateTitle(newTitle);

            Assert.That(book.Title, Is.EqualTo(newTitle));
        }

        [Test]
        public void UpdateAuthorTest()
        {
            Book book = new("Narnia", "C.S. Lewis", "Fantasy");
            string newAuthor = "Test";

            book.UpdateTitle(newAuthor);

            Assert.That(book.Title, Is.EqualTo(newAuthor));
        }

        [Test]
        public void UpdateGenreTest()
        {
            Book book = new("Narnia", "C.S. Lewis", "Fantasy");
            string newGenre = "Test";

            book.UpdateTitle(newGenre);

            Assert.That(book.Title, Is.EqualTo(newGenre));
        }
    }
}