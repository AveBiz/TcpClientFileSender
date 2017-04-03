using System;
using System.IO;

namespace Client
{
    internal static class UserInputWorker
    {
        internal static string GetFilePathFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter file path: ");

                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    WriteFilePathIsInvalid();
                    continue;
                }

                if (!File.Exists(userInput))
                {
                    WriteFileIsNotExists();
                    continue;
                }

                FileStream fileStream;

                try
                {
                    fileStream = File.OpenRead(userInput);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }

                if (!fileStream.CanRead)
                {
                    Console.WriteLine("Can't read this file");
                }

                fileStream.Close();

                return userInput;
            }
        }

        private static void WriteFileIsNotExists()
        {
            Console.WriteLine("File didn't exists");
        }

        private static void WriteFilePathIsInvalid()
        {
            Console.Out.WriteLine("File path is invalid!");
        }
    }
}