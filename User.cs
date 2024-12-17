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
    
        if(!Regex.IsMatch(value, "^(?=.*[a-z]{8,})(?=.*\\d).+$"))
        {
            throw new ArgumentException("Password does not meet complexity requirements.");
        }
        _password = value;
    
        }
    }
    public string UserName { get; set; }

    public User(string name, string pass)
    {
        this.UserName = name;
        this.Password = pass;


    }
}