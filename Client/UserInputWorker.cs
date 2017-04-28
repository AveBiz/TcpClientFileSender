using System;

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

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }

                WriteFilePathIsInvalid();
            }
        }

        private static void WriteFilePathIsInvalid()
        {
            Console.Out.WriteLine("File path is invalid!");
        }
    }
}