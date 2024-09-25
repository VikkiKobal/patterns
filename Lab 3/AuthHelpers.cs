using System;

    public static class UserInputHelper
    {
        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }

    public interface IAuthStrategy
    {
        bool Authenticate();
    }
