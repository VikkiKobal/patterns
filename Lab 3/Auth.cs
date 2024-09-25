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

public class LoginPasswordAuth : IAuthStrategy
{
    private const string ValidLogin = "admin";
    private const string ValidPassword = "password";

    public bool Authenticate()
    {
        string login = UserInputHelper.PromptUser("Enter login: ");
        string password = UserInputHelper.PromptUser("Enter password: ");

        if (IsAuthenticated(login, password))
        {
            Console.WriteLine("Authenticated successfully");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid login or password");
            return false;
        }
    }

    private bool IsAuthenticated(string login, string password)
    {
        return login == ValidLogin && password == ValidPassword;
    }
}

public class SmsCodeAuth : IAuthStrategy
{
    private const string ValidSmsCode = "1111";

    public bool Authenticate()
    {
        Console.WriteLine("SMS code sent to your phone: 1111");
        string smsCode = UserInputHelper.PromptUser("Enter SMS code: ");

        if (IsAuthenticated(smsCode))
        {
            Console.WriteLine("Authenticated successfully");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid SMS code");
            return false;
        }
    }

    private bool IsAuthenticated(string smsCode)
    {
        return smsCode == ValidSmsCode;
    }
}

public class ExternalServiceAuth : IAuthStrategy
{
    public bool Authenticate()
    {
        Console.WriteLine("Choose an external server:");
        Console.WriteLine("1. Google");
        Console.WriteLine("2. Facebook");
        Console.WriteLine("3. DIA");

        if (int.TryParse(UserInputHelper.PromptUser("Choose server: "), out int serverChoice) && serverChoice >= 1 && serverChoice <= 3)
        {
            string login = UserInputHelper.PromptUser("Enter login: ");
            Console.WriteLine("Authenticated successfully via external service.");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid server.");
            return false;
        }
    }
}

public class AuthContext
{
    private readonly IAuthStrategy _strategy;

    public AuthContext(IAuthStrategy strategy)
    {
        _strategy = strategy;
    }

    public void AuthenticateUser()
    {
        bool isAuthenticated = _strategy.Authenticate();
        if (isAuthenticated)
        {
            Console.WriteLine("Привіт!"); 
        }
    }
}
