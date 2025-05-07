using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Task_2
{
    public class Task_2
    {
    public void main2()
    {
        string inputFile = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask2/input.txt";
        string outputFile = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask2/words_by_length.txt";

        Console.Write("Введіть потрібну довжину слова: ");
        if (!int.TryParse(Console.ReadLine(), out int wordLength) || wordLength <= 0)
        {
            Console.WriteLine("Некоректна довжина.");
            return;
        }

        string text = File.ReadAllText(inputFile);

        // Знаходимо всі слова (без пунктуації)
        MatchCollection matches = Regex.Matches(text, @"\b\w+\b");

        List<string> resultWords = new List<string>();
        foreach (Match match in matches)
        {
            if (match.Value.Length == wordLength)
                resultWords.Add(match.Value);
        }

        File.WriteAllLines(outputFile, resultWords);

        Console.WriteLine($"Знайдено {resultWords.Count} слів довжини {wordLength}:");
        foreach (string word in resultWords)
            Console.WriteLine(word);
    }
}
}