using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int articlesNum = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            //onsole.WriteLine($";{userArticle[0]};");
            //Console.WriteLine($";{userArticle[1]};");
            //Console.WriteLine($";{userArticle[2]};");
            //Console.WriteLine(article.ToString());
            
            for (int i = 0; i < articlesNum; i++)
            {
                string[] currArticle = Console.ReadLine().
                    Split(", ", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();
                Article article = new Article(currArticle[0], currArticle[1], currArticle[2]);
                articles.Add(article);
            
            }
            foreach(Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }
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

        //public void Edit(string content)
        //{
        //    this.Content = content;
        //}
        //public void ChangeAuthor(string author)
        //{
        //    this.Author = author;
        //}
        //public void Rename(string title)
        //{
        //    this.Title = title;
        //}
        public override string ToString()
        {
            return this.Title + " - " + this.Content + ": " + this.Author;
        }
    }
}
