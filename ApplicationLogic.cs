using System;
using System.IO;
using System.Text;

namespace FileManager
{
    public partial class Program
    {

        /// <summary>
        /// Функция для просмотра списка дисков и его выбора.
        /// </summary>
        static void GetAllDrives()
        {
            int count = 1;

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (var drive in allDrives)
            {
                Console.WriteLine($"{count}) {drive}");
                count++;
            }

            Console.Write("\nВыберите нужный вам диск;\n" +
                "Введите имя диска: ");
            string path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.Write("\nДиск не существует!\n" +
                    "Введите имя диска из списка: ");
                path = Console.ReadLine();
            }

            try
            {
                Directory.SetCurrentDirectory(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Переход в директорию
        /// </summary>
        /// <param name="path">путь до директории</param>
        static void GetDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.SetCurrentDirectory(path);
                    Console.WriteLine("Переход выполнен!");
                }
                else
                {
                    Console.WriteLine("Директории не сущетсвует");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }


        /// <summary>
        /// Удаление существующей директории
        /// </summary>
        /// <param name="name">Название директории</param>
        static void DeleteDirectory(string name)
        {
            try
            {
                if (Directory.Exists(name))
                {
                    Directory.Delete(name);
                    Console.WriteLine("Директория удалена!");
                }
                else
                {
                    Console.WriteLine("Директории не существует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Создание новой директории
        /// </summary>
        /// <param name="name">Название директории</param>
        static void CreateNewDirectory(string name)
        {
            try
            {
                if (!Directory.Exists(name))
                {
                    Directory.CreateDirectory(name);
                    Console.WriteLine("Директория создана!");
                }
                else
                {
                    Console.WriteLine("Директория с таким названием уже существует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Функция для перехода на уровень выше в иерархии папок.
        /// </summary>
        static void GetBack()
        {
            try
            {
                GetDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
                Console.WriteLine($"Вы здесь: {Directory.GetCurrentDirectory()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Дальше некуда!\n" + ex);
            }
            return;
        }

        /// <summary>
        /// Вывод списка всех папок и файлов текущей директории.
        /// </summary>
        static void DirectoryFiles()
        {
            try
            {
                string[] filesAndFolders = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());

                foreach (var file in filesAndFolders)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;

        }

        /// <summary>
        /// Чтение файла в кодировке UTF-8.
        /// </summary>
        /// <param name="file">Имя файла для чтения.</param>
        static void ReadFile(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    var text = File.ReadAllText(file, Encoding.UTF8);
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine("Такой файл не сущетсвует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Чтение файла в выбранной кодировке.
        /// </summary>
        /// <param name="file">Имя файла для чтения.</param>
        static void ReadFileWithEncoding(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    string result = string.Empty;

                    Encoding unicode = Encoding.Unicode;
                    Encoding ascii = Encoding.ASCII;
                    Encoding iso = Encoding.Latin1;

                    Console.Write("В какой кодировке вы бы хотели прочитать выбранный файл?\n" +
                        "1) UTF-16\n" +
                        "2) ASCII\n" +
                        "3) ISO - 8859 - 1\n" +
                        "Введите номер кодировки(1, 2 или 3)\n" +
                        "\nВыбор: ");

                    int choice;

                    while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
                    {
                        Console.WriteLine("Неверный ввод!");
                        Console.Write("Выбор: ");
                    }

                    switch (choice)
                    {
                        case 1:
                            result = File.ReadAllText(file);
                            byte[] encodedBytesUTF16 = unicode.GetBytes(result);
                            result = string.Empty;

                            foreach (var encodedByte in encodedBytesUTF16)
                            {
                                result = encodedByte + " ";
                            }

                            Console.WriteLine(result);
                            break;

                        case 2:
                            result = File.ReadAllText(file);
                            byte[] encodedBytesASCII = ascii.GetBytes(result);
                            result = string.Empty;

                            foreach (var encodedByte in encodedBytesASCII)
                            {
                                result = encodedByte + " ";
                            }

                            Console.WriteLine(result);
                            break;

                        case 3:
                            result = File.ReadAllText(file);
                            byte[] encodedBytesISO = iso.GetBytes(result);
                            result = string.Empty;

                            foreach (var encodedByte in encodedBytesISO)
                            {
                                result = encodedByte + " ";
                            }

                            Console.WriteLine(result);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Такой файл не сущетсвует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Создание копии файла.
        /// </summary>
        /// <param name="file">Имя файла, копия которого создаётся</param>
        static void CopyFile(string file)
        {
            Console.Write("Для создании копии файла вы долнжы придумать ему новое имя\n" +
                "Имя копии: ");
            string newFileName = Console.ReadLine();

            try
            {
                if (File.Exists(file))
                {
                    File.Copy(file, newFileName);
                }
                else
                {
                    Console.WriteLine("Файл не сущетсвует!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Пермещение файла в другую директорию.
        /// </summary>
        /// <param name="file">Имя файла который будет перемещён.</param>
        static void MoveToAnotherDir(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    Console.Write("Куда бы вы хотели переместить файл?\n" +
                        "Путь: ");
                    string path = Console.ReadLine();

                    while (!Directory.Exists(path))
                    {
                        Console.Write("Такой директории не сущетсвует!\n" +
                            "Путь: ");
                        path = Console.ReadLine();
                    }

                    File.Move(file, path + $"{Path.AltDirectorySeparatorChar}{file}");
                    Console.WriteLine("Файл перемещен!");
                }
                else
                {
                    Console.WriteLine("Файл не сущетсвует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="file">Имя файла который будет удалён.</param>
        static void DeleteFile(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    Console.WriteLine("Файл удалён!");
                }
                else
                {
                    Console.WriteLine("Файл не сущетсвует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Создание текстового файла в кодировке UTF-8.
        /// </summary>
        /// <param name="name">Имя файла который будет создан.</param>
        static void CreateTxtFile(string name)
        {
            try
            {
                if (name == string.Empty)
                {
                    Console.WriteLine("Имя не может быть пустым!");
                    return;
                }

                if (!File.Exists(name))
                {
                    File.CreateText(name);
                    Console.WriteLine("Файл создан!");
                }
                else
                {
                    Console.WriteLine("Файл уже сущетсвует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// Создание текстового файла в выбранной кодировке.
        /// </summary>
        /// <param name="name">Имя файла который будет создан.</param>
        static void CreateFileWithEncoding(string name)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding ascii = Encoding.ASCII;
            Encoding iso = Encoding.Latin1;

            try
            {
                if (!File.Exists(name))
                {
                    Console.Write("В какой кодировке вы бы хотели создать файл?\n" +
                        "1) UTF-16\n" +
                        "2) ASCII\n" +
                        "3) ISO - 8859 - 1\n" +
                        "Введите номер кодировки(1, 2 или 3)\n" +
                        "\nВыбор: ");

                    int choice;

                    while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
                    {
                        Console.Write("Неверный ввод!\n" +
                            "Выбор: ");
                    }

                    Console.Write("Что бы вы хотели записать в файл?\n" +
                        "Текст: ");
                    string content = Console.ReadLine();

                    switch (choice)
                    {
                        case 1:
                            byte[] encodedBytesUTF16 = unicode.GetBytes(content);
                            content = string.Empty;

                            foreach (var encodedByte in encodedBytesUTF16)
                            {
                                content = encodedByte + " ";
                            }

                            File.WriteAllText(name, content, unicode);
                            Console.WriteLine("Файл создан в кодировке UTF-16");
                            break;

                        case 2:
                            byte[] encodedBytesASCII = ascii.GetBytes(content);
                            content = string.Empty;

                            foreach (var encodedByte in encodedBytesASCII)
                            {
                                content = encodedByte + " ";
                            }

                            File.WriteAllText(name, content, ascii);
                            Console.WriteLine("Файл создан в кодировке ASCII");
                            break;

                        case 3:
                            byte[] encodedBytesISO = iso.GetBytes(content);
                            content = string.Empty;

                            foreach (var encodedByte in encodedBytesISO)
                            {
                                content = encodedByte + " ";
                            }

                            File.WriteAllText(name, content, iso);
                            Console.WriteLine("Файл создан в кодировке ISO - 8859 - 1");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Файл уже сущетсвует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// конкатенация содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF-8.
        /// </summary>
        /// <param name="files">Файлы из которых будет происходить чтение</param>
        static void ConcatinateFiles(string files)
        {
            string[] fileNames = files.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (fileNames.Length < 2)
            {
                Console.WriteLine("Требуется минимум 2 файла!");
                return;
            }

            string result = string.Empty;

            foreach (var file in fileNames)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        string text = string.Empty;

                        text = File.ReadAllText(file, Encoding.UTF8);
                        result += text;
                    }
                    else
                    {
                        Console.WriteLine($"Файл {file} не существует!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            Console.WriteLine(result);
            return;
        }

        /// <summary>
        /// Завершение работы приложения.
        /// </summary>
        static void QuitApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Очистка консоли.
        /// </summary>
        static void ClearConsole()
        {
            Console.Clear();
            return;
        }
    }
}
