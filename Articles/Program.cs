using System;
using System.Linq;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userArticle = Console.ReadLine().
                Split(", ",StringSplitOptions.RemoveEmptyEntries).
                ToArray();
            Article article = new Article(userArticle[0], userArticle[1], userArticle[2]);
            //onsole.WriteLine($";{userArticle[0]};");
            //Console.WriteLine($";{userArticle[1]};");
            //Console.WriteLine($";{userArticle[2]};");
            //Console.WriteLine(article.ToString());
            int commandsCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().
                    Split(": ", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();
                
                if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
                else if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
            }
            Console.WriteLine(article.ToString());
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public Article()
        {

        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }
        public override string ToString()
        {
            return this.Title + " - " + this.Content + ": " + this.Author;
        }
    }
}
