using System;

namespace Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] autors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random random = new Random();
            int messagesCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < messagesCount; i++)
            {
                string message = phrases[random.Next(phrases.Length)] + " "+
                    events[random.Next(events.Length)] + " " +
                    autors[random.Next(autors.Length)] + " - " +
                    cities[random.Next(cities.Length)];
                Console.WriteLine(message);
                
            }
        }
    }
}
