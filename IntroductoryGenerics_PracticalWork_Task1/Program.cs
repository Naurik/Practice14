using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntroductoryGenerics_PracticalWork_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] words = File.ReadAllText(@"C:\Users\Acer-PC\source\repos\game-statistics-master\IntroductoryGenerics_PracticalWork_Task1\verse.txt", Encoding.Default).Split(new[] {' '});
            string tempStr;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(',')|| words[i].Contains('.'))
                {
                    tempStr = words[i].Substring(0, words[i].Length - 1);
                    words[i] = tempStr;
                }
            }
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < words.Length; i++)
            {
                dictionary.Add(i, words[i]);
            }

            int k = 0;
            Dictionary<int, string> newDictionary = new Dictionary<int, string>();

            for (int i = 0; i < dictionary.Count; i++)
            {
                if (!newDictionary.ContainsValue(dictionary[i]))
                {
                    newDictionary.Add(k++, dictionary[i]);
                }
            }

            int count = 0;
            Console.WriteLine("{0, 23} {1,22}", "Слово", "Кол-во");
            for (int i = 0; i < newDictionary.Count; i++)
            {
                if (newDictionary[i] == " ")
                    continue;
                for (int j = 0; j < dictionary.Count; j++)
                {
                    if (newDictionary[i] == dictionary[j])
                        count++;
                }
                Console.WriteLine($"{i + 1,2} {newDictionary[i],20} {count,20}");
                count = 0;
            }
            Console.WriteLine($"Всего слов: {dictionary.Count}, из них уникальных: {newDictionary.Count}");
            Console.ReadLine();
        }
    }
}
