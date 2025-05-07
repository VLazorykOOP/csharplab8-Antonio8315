using System;
using System.IO;

namespace Task_5
{
    public class Task_5
    {
    public void main5()
    {
        string folderPath = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab8-Antonio8315/Lab8CSharp/FilesTask5/Берегій1";

        // Створення папки
        Directory.CreateDirectory(folderPath);

        // Створення файлу t1.txt
        string t1Path = Path.Combine(folderPath, "t1.txt");
        string t1Content = "Шевченко Степан Іванович, 2001 року народження, місце проживання м. Суми";
        File.WriteAllText(t1Path, t1Content);

        // Створення файлу t2.txt
        string t2Path = Path.Combine(folderPath, "t2.txt");
        string t2Content = "Комар Сергій Федорович, 2000 року народження, місце проживання м. Київ";
        File.WriteAllText(t2Path, t2Content);

        Console.WriteLine("Файли успішно створено в папці: " + folderPath);
    }
}
}