using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using System.Security.Cryptography;
namespace Task_1
{
    public class Task_1
    {
    public void main1()
    {
        string inputPath = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask1/input.txt";
        string outputPath = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask1/ips_found.txt";

        // Регулярний вираз для IP-адрес
        string ipPattern = @"(?:(?:25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\.){3}(?:25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)";

        // Зчитуємо вміст файлу
        string text = File.ReadAllText(inputPath);

        // Знаходимо всі IP
        MatchCollection matches = Regex.Matches(text, ipPattern);
        List<string> ipList = new List<string>();
        foreach (Match match in matches)
        {
            ipList.Add(match.Value);
        }

        // Запис знайдених IP у файл
        File.WriteAllLines(outputPath, ipList);

        Console.WriteLine($"Знайдено {ipList.Count} IP-адрес.");
        foreach (var ip in ipList)
            Console.WriteLine(ip);

        // Користувацькі дії
        Console.Write("Введіть IP-адресу для заміни або вилучення: ");
        string targetIp = Console.ReadLine()!;

        if (ipList.Contains(targetIp))
        {
            Console.Write("Бажаєте замінити (1) чи вилучити (2)? ");
            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                Console.Write("Введіть нову IP-адресу: ");
                string newIp = Console.ReadLine()!;
                text = text.Replace(targetIp, newIp);
            }
            else if (choice == "2")
            {
                text = text.Replace(targetIp, "");
            }

            File.WriteAllText("C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask1/output_modified.txt", text);
            Console.WriteLine("Зміни записані в output_modified.txt");
        }
        else
        {
            Console.WriteLine("Такої IP-адреси не знайдено у файлі.");
        }
    }
}
}