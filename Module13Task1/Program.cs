using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Module13Task1
{
    class Program
    {
        public static List<string> ListStrings = new List<string>();
        public static LinkedList<string> LinkedStrings = new LinkedList<string>();

        private static void Main(string[] args)
        {
            string textPath = File.ReadAllText("D://Downloads/Text1.txt");
            var words = textPath.Split(new char[] { ',', ' ', '.', '\n', '\r', '–', '!', '?', ';', ':',}, 
                StringSplitOptions.RemoveEmptyEntries);

            var insertWord = "вставка";
            int insertionIndex = 1000;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var word in words)
            {
                ListStrings.Add(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"Вставка текста в List<T> заняла : {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Restart();
            foreach (var word in words)
            {
                LinkedStrings.AddLast(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"Вставка текста в LinkedList<T> заняла : {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Restart();
            if (ListStrings[insertionIndex] != null)
                ListStrings.Insert(insertionIndex, insertWord);
            stopwatch.Stop();
            Console.WriteLine($"Вставка текста в конкретное место в List<T> заняла : {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Restart();
            if (LinkedStrings.ElementAt(insertionIndex) != null) 
            { 
                LinkedListNode<string> node = LinkedStrings.First;
                for (int i = 0; i < insertionIndex;  i++)
                {
                    node = node.Next;
                }
                LinkedStrings.AddAfter(node, insertWord);
            }
            stopwatch.Stop();
            Console.WriteLine($"Вставка текста в конкретное место в LinkedList<T> заняла : {stopwatch.Elapsed.TotalMilliseconds}");
        }

    }
}