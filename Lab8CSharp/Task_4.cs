using System;
using System.IO;

namespace Task_4
{
    public class Task_4
    {
    public void main4()
    {
        string fileName = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask4/reverse_numbers.dat";
        int n = 20;

        // Запис у файл
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            for (int i = 1; i <= n; i++)
            {
                writer.Write(1.0 / i);
            }
        }

        // Зчитування і вивід компонентів з індексом кратним 3
        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            int index = 1;
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                double value = reader.ReadDouble();
                if (index % 3 == 0)
                {
                    Console.WriteLine($"Елемент {index}: {value}");
                }
                index++;
            }
        }
    }
}
}