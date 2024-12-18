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

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value), "Password cannot be null or empty.");
        }
    
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
    public string UserName { get; set; }

    public User(string name, string pass)
    {
        UserName = name;
        Password = pass;


    }
}