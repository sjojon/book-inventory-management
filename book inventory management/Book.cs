namespace book_inventory_management
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public int Id { get; set; }
        public static int NextId { get; set; } = 0;
        public Library Library { get; set; }

        public int Quantity
        {
            get
            {
                if (Library != null && Library.numberOfBooks.ContainsKey(this))
                {
                    return Library.numberOfBooks[this];
                }

                return 0;
            }
        }

        public Book(string newTitle, string newAuthor, string newGenre)
        {
            Title = newTitle;
            Author = newAuthor;
            Genre = newGenre;
            Id = NextId;
            NextId++;
        }

        public void DisplayBookDetails() //Displays the details of the book (title, author, genre, quantity).
        {
            Console.WriteLine(
                $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nNumber of books in library: {Quantity}\n");
        }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void UpdateAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void UpdateGenre(string newGenre)
        {
            Genre = newGenre;
        }
    }
}