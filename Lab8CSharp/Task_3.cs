using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Task_3
{
    public class Task_3
    {
        public void main3()
        {
            string inputFile = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask3/input.txt";
            string outputFile = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask3/output.txt";

            // Зчитати вміст файлу
            string text = File.ReadAllText(inputFile);

            // Знайти всі слова
            var words = Regex.Matches(text, @"\b\w+\b")
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .ToList();

            // Знайти довжину найдовшого слова
            int maxLength = words.Max(w => w.Length);

            // Зібрати всі найдовші слова
            var longestWords = words.Where(w => w.Length == maxLength).Distinct();

            // Вилучити найдовші слова з тексту
            foreach (var word in longestWords)
            {
                // Видаляємо слово з пробілами та знаками пунктуації (тільки як окреме слово!)
                text = Regex.Replace(text, $@"\b{Regex.Escape(word)}\b", "", RegexOptions.IgnoreCase);
            }

            // Прибрати зайві пробіли
            text = Regex.Replace(text, @"\s{2,}", " ").Trim();

            // Записати в новий файл
            File.WriteAllText(outputFile, text);

            Console.WriteLine("Текст після вилучення найдовших слів збережено у 'output.txt'");
        }
    }
}