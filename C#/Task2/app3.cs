using System;

namespace ConsoleApp3
{
    class Program
    {
        class Book
        {
            Title title;
            Author author;
            Content content;

            public Title Title { set { title = value; } }
            public Author Author { set { author = value; } }
            public Content Content { set { content = value; } }

            public void Show()
            {
                title.Show();
                author.Show();
                content.Show();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Read();
            }
        }

        class Title
        {
            public string name;
            public void Show() 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(name);
            }
        }

        class Author
        {
            public string name;
            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(name);
            }
        }

        class Content
        {
            public string name;
            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(name);
            }
        }

        static void Main(string[] args)
        {
            Book book = new Book();
            Title title = new Title();
            Author autor = new Author();
            Content content = new Content();
            title.name = "Gold calf.";
            autor.name = "Ilf & Petrov.";
            content.name = "Very funny...";
            book.Title = title;
            book.Author = autor;
            book.Content = content;
            book.Show();
        }
    }
}
