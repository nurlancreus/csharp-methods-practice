using System.Text.RegularExpressions;

namespace CollectionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void countWords(string sentence)
            {
                string pattern = @"\W";

                Regex regex = new Regex(pattern);
                
                string[] words = regex.Split(sentence.Trim());

                Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    if (word == " ") continue;

                    if (wordsDictionary.ContainsKey(word))
                    {
                        wordsDictionary[word] += 1;
                    }
                    else wordsDictionary[word] = 1;
                }

                foreach (var item in wordsDictionary)
                {
                    Console.WriteLine($"word {item.Key} - count: {item.Value}");
                }
            }

            Console.WriteLine("Cumle daxil edin");
            
            countWords(Console.ReadLine());
        }
    }
}
