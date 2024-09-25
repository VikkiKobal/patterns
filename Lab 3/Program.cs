using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select authentication method:");
        Console.WriteLine("1. Login and Password");
        Console.WriteLine("2. SMS Code");
        Console.WriteLine("3. External Service");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
        {
            IAuthStrategy authStrategy;

            switch (choice)
            {
                case 1:
                    authStrategy = new LoginPasswordAuth();
                    break;
                case 2:
                    authStrategy = new SmsCodeAuth();
                    break;
                case 3:
                    authStrategy = new ExternalServiceAuth();
                    break;
                default:
                    throw new InvalidOperationException("Invalid choice");
            }

            AuthContext context = new AuthContext(authStrategy);
            context.AuthenticateUser();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid authentication method.");
        }
    }
}
