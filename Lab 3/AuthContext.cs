using System;

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
