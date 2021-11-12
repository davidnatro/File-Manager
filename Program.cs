using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace FileManager
{
    public partial class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в файловый менеджер!\n\n" +
                "Для вывода всех операциий введите help");
            RecognizeOperation();
        }

        /// <summary>
        /// Фукнция выбора дальнейшей операции.
        /// </summary>
        private static void RecognizeOperation()
        {
            string[] commands = { "ls", "cd", "drives", "help", "back", "clear", "cat",
                "catenc", "copy", "rm", "mv", "touch", "mkdir", "rmr", "touchenc", "concat", "quit" };
            string command;
            string operation;

            do
            {
                Console.Write("\ncmd: ");
                operation = Console.ReadLine();
                command = Regex.Replace(operation.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            } while (!commands.Contains(command));

            ExecuteOperation(command, operation);
            return;
        }

        /// <summary>
        /// Выводит всевозможные команды для работы с приложением
        /// </summary>
        static void PrintHelp()
        {
            Console.Write(
                "\ndrives ~ выводит список всех дисков.\n" +
                "ls ~ выводит список всех папок и файлов внутри текущей директории.\n" +
                "cd {имя директории} ~ переход в выбранную директорию.\n" +
                "mkdir {имя директории} ~ создание новой директории.\n" +
                "rmr {имя директории} ~ удаление выбранной директории.\n" +
                "back ~ подняться на уровень выше.\n" +
                "clear ~ очистить консоль.\n" +
                "cat {имя файла} ~ вывод содержимого файла в кодировке UTF-8.\n" +
                "catenc {имя файла} ~ вывод содержимого файла в выбранной кодировке.\n" +
                "copy {имя файла} ~ создаёт копию выбранного файла.\n" +
                "rm {имя файла} ~ удаляет выбранный файл.\n" +
                "mv {имя файла} ~ перемещает выбранный файл в другую директорию.\n" +
                "touch {имя файла} ~ создаёт текстовый файл в кодировке UTF-8.\n" +
                "touchenc {имя файла} ~ создаёт файл в выбранной кодировке.\n" +
                "concat {перечесление имена файлов через пробел} ~ конкатенация файлов и вывод результата в консоль " +
                "в кодировке UTF-8.\n" +
                "quit ~ выйти из приложения.\n"
                );
            return;
        }
    }
}