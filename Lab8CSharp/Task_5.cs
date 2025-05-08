using System;
using System.IO;

namespace Task_5
{
    public class Task_5
    {
        public void main5()
        {
            string folderPathTemp = @"C:\temp";
            string folderPathB1 = Path.Combine(folderPathTemp, "Берегій1");
            string folderPathB2 = Path.Combine(folderPathTemp, "Берегій2");
            string folderPathAll = Path.Combine(folderPathTemp, "ALL");

            // 1. Створення папок
            Directory.CreateDirectory(folderPathTemp);
            Directory.CreateDirectory(folderPathB1);
            Directory.CreateDirectory(folderPathB2);

            // 2. Створення t1.txt
            string t1Path = Path.Combine(folderPathB1, "t1.txt");
            string t1Content = "Шевченко Степан Іванович, 2001 року народження, місце проживання м. Суми";
            File.WriteAllText(t1Path, t1Content);

            // Створення t2.txt
            string t2Path = Path.Combine(folderPathB1, "t2.txt");
            string t2Content = "Комар Сергій Федорович, 2000 року народження, місце проживання м. Київ";
            File.WriteAllText(t2Path, t2Content);

            Console.WriteLine("Файли успішно створено в Берегій1.");

            // 3. Створення t3.txt
            string t3Path = Path.Combine(folderPathB2, "t3.txt");
            File.WriteAllText(t3Path, File.ReadAllText(t1Path) + Environment.NewLine + File.ReadAllText(t2Path));

            // 4. Вивести інформацію
            Console.WriteLine("\nФайли в Берегій1:");
            foreach (var file in Directory.GetFiles(folderPathB1))
                PrintFileInfo(file);

            // 5.
            File.Move(t2Path, Path.Combine(folderPathB2, "t2.txt"));

            // 6.
            File.Copy(t1Path, Path.Combine(folderPathB2, "t1.txt"), true);

            // 7.
            Directory.Move(folderPathB2, folderPathAll);
            Directory.Delete(folderPathB1, true);

            // 8. Вивід інформації про файли в ALL
            Console.WriteLine("\nФайли в папці ALL:");
            foreach (var file in Directory.GetFiles(folderPathAll))
                PrintFileInfo(file);
        }

        private void PrintFileInfo(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            Console.WriteLine($"Файл: {fi.Name} | Розмір: {fi.Length} байт | Створено: {fi.CreationTime}");
        }
    }
}
