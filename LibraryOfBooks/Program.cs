namespace secondTask;

public static class Globals
{
    public static Func<string?, bool> restrains = input => {
        return string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input);
    };
}
class Book
{
    readonly public string title;
    readonly public string author;
    readonly public int year;
    public Book(string s_title, string s_author, int i_year)
    {
        title = s_title;
        author = s_author;
        year = i_year;
    }
}
class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> ListBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].author.ToLower() == author.ToLower())
            {
                result.Add(books[i]);
            }
        }
        return result;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Book a = new Book("Country of OZ", "Karabey", 1980);
        Book b = new Book("CounterString", "Tolstoy", 1282);
        Book c = new Book("CounterStrike", "ToLsToY", 2025);
        Library lib = new Library();
        lib.AddBook(a);
        lib.AddBook(b);
        lib.AddBook(c);

    string? input = "";
        while (Globals.restrains(input))
        {
            Console.Write("Enter author of book:");
            input = Console.ReadLine();
            if (Globals.restrains(input))
            {
                Console.Clear();
                Console.WriteLine("Entered string is null or empty or contains only whitespaces.");
            }
        }


        List<Book> result = lib.ListBooksByAuthor(input);
        if (result.Count == 0)
        {
            Console.WriteLine("Library doesn't have books of this author.");
        }
        else
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write((i + 1).ToString() + ") " + result[i].title + ", " + result[i].author + ", " + result[i].year);
                if (i == result.Count - 1)
                {
                    Console.WriteLine(".");
                }
                else
                {
                    Console.WriteLine(";");
                }
            }
        }
    }
}