using System;
using System.IO;
using System.Linq;


namespace Modul8Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folder = @"D:\Temp";             //  отладочная информация, затереть перед сдачей
            long folderSize = 0;

            // Ввод и провека папки на существование
            Console.WriteLine("Введите директорию для расчёта занимаемого места :");
            folder = Console.ReadLine();

            if (!Directory.Exists(folder))
            {
                Console.WriteLine(" Вы ввели не существующую директорию. Программа прекращает свою работу.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Начат расчёт размеров директории " + folder);

            GetDirSize(folder, ref folderSize);

            Console.WriteLine("Размер директории = " + folderSize);

            Console.ReadKey();

        }

        public static void GetDirSize(string aFolder, ref long folderSize)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(aFolder);
            DirectoryInfo[] arrDir = dirInfo.GetDirectories();
            FileInfo[] arrFile = dirInfo.GetFiles();

            //Console.WriteLine(dirInfo.FullName);      отладочная информация, затереть перед сдачей

            try
            {
                // Суммируем размер файлов в директории
                foreach (var file in arrFile)
                {
                    folderSize = (folderSize + file.Length);

                    //Console.WriteLine(file.FullName);  отладочная информация, затереть перед сдачей
                }

                // Рекурсивно проходим по всем остальним директориям
                foreach (var dir in arrDir)
                {
                    GetDirSize(dir.FullName, ref folderSize);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось считать размер файла или директории по причине\n " + ex.Message);
            }

        }
    }
}
