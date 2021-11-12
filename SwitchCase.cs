using System.Linq;

namespace FileManager
{
    public partial class Program
    {
        /// <summary>
        /// Запускает выбранную ранее операцию.
        /// </summary>
        /// <param name="command">Команда(cd, ls и т.д.)</param>
        /// <param name="operation">Аргумент команды</param>
        static void ExecuteOperation(string command, string operation)
        {
            operation = string.Join(" ", operation.Split().Skip(1));

            switch (command)
            {
                case "help":
                    PrintHelp();
                    RecognizeOperation();
                    break;

                case "ls":
                    DirectoryFiles();
                    RecognizeOperation();
                    break;

                case "cd":
                    GetDirectory(operation);
                    RecognizeOperation();
                    break;

                case "mkdir":
                    CreateNewDirectory(operation);
                    RecognizeOperation();
                    break;

                case "rmr":
                    DeleteDirectory(operation);
                    RecognizeOperation();
                    break;

                case "drives":
                    GetAllDrives();
                    RecognizeOperation();
                    break;

                case "back":
                    GetBack();
                    RecognizeOperation();
                    break;

                case "clear":
                    ClearConsole();
                    RecognizeOperation();
                    break;

                case "cat":
                    ReadFile(operation);
                    RecognizeOperation();
                    break;

                case "catenc":
                    ReadFileWithEncoding(operation);
                    RecognizeOperation();
                    break;

                case "copy":
                    CopyFile(operation);
                    RecognizeOperation();
                    break;

                case "rm":
                    DeleteFile(operation);
                    RecognizeOperation();
                    break;

                case "touch":
                    CreateTxtFile(operation);
                    RecognizeOperation();
                    break;

                case "mv":
                    MoveToAnotherDir(operation);
                    RecognizeOperation();
                    break;

                case "touchenc":
                    CreateFileWithEncoding(operation);
                    RecognizeOperation();
                    break;

                case "concat":
                    ConcatinateFiles(operation);
                    RecognizeOperation();
                    break;

                case "quit":
                    QuitApplication();
                    break;
            }
            return;
        }
    }
}
