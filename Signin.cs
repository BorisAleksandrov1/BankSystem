using System.Text.RegularExpressions;

class SignIn
{
    public static void Register()
    {
        System.Console.WriteLine("Whats do you want your user name to be");
        string? newName = Console.ReadLine();

        System.Console.WriteLine("Enter your email address");
        string? email = Console.ReadLine();

        System.Console.WriteLine("Create a password");
        string? password = Console.ReadLine();

        //check the password
        CheckPassByRegex(password);

        CreateUser(newName, email, password);
    }
    public static void CreateUser(string newName, string email, string password)
    {
        User newUser = new User(newName, password, email);

        bankAccount newAccount = new bankAccount("Main");
        string newAccountID = Guid.NewGuid().ToString();

        newUser._accounts.Add(newAccountID, newAccount);
        newUser._currentAccount = newAccount;

        bankLogic.currentUser = newUser;

        string newId = Guid.NewGuid().ToString();
        bankLogic.currentKey = newId;

        bankLogic.usersDict.Add(newId, newUser);
    } 

    public static void CheckPassByRegex(string password)
    {
        while (true)
        {
            bool valid = true;

            if (password.Length < 8)
            {
                System.Console.WriteLine("Password must be at least 8 characters long.");
                valid = false;
            }
            if (!Regex.IsMatch(password, @"(\d)\w+"))
            {
                Console.WriteLine("Password must contain at least one number.");
                valid = false;
            }
            if (!Regex.IsMatch(password, @"([A-Z])\w+"))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                valid = false;
            }
            if (valid)
            {
                Console.WriteLine("Password set successfully!");
                break;
            }

            Console.WriteLine("Please enter a valid password:");
            password = Console.ReadLine(); // Ask for input again
        }
    }
}