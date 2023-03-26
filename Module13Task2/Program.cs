using System.Linq;

namespace Module13Task2
{
    class Program
    {
        private static void Main(string[] args)
        {
            HashSet<string> hashSet = new HashSet<string>();

            string textPath = File.ReadAllText("D://Downloads/Text1.txt");
            var noPunctuationText = new string(textPath.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(new char[] { ',', ' ', '.', '\n', '\r', '–', '!', '?', ';', ':', '(', ')'},
                StringSplitOptions.RemoveEmptyEntries);

            //Значением у нас является кол-во повторений, а ключ - само слово
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word]++;
                else
                    wordFrequency[word] = 1;
            }

            var topWords = wordFrequency.OrderByDescending(c => c.Value).Take(10);
            foreach (var topWord in topWords)
            {
                Console.WriteLine($"Слово '{topWord.Key}' встречается {topWord.Value} раз");
            }
        }
    }
}