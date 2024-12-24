using System.Net;
using System.Text.RegularExpressions;

class User
{
    private string _password;
    public string Password
    {
        get { return _password; }
        set
        {
            if (value.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            // Check for at least one number using regex
            if (!Regex.IsMatch(value, @"(\d)\w+"))
            {
                throw new ArgumentException("Password must contain at least one number.");
            }

            // Check for at least one uppercase letter using regex
            if (!Regex.IsMatch(value, @"([A-Z])\w+"))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }
            _password = value;

        }
    }
    public string _email;
    public string _userName;
    //public decimal _balance;
    public Dictionary<string, bankAccount> _accounts = new Dictionary<string, bankAccount>();
    public bankAccount _currentAccount;
    public User(string name, string pass, string email)
    {
        _email = email;
        _userName = name;
        Password = pass;
    }
}