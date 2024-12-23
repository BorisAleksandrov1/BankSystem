using System.ComponentModel;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft;

class bankLogic
{
    public static User currentUser;
    public static Dictionary<string, User> usersDict = new Dictionary<string, User>();

    static void Main()
    {
        string path = @"C:\Users\Admin\Projects\BankSystem";
        string usersPath = Path.Combine(path, "Users.json");

        string content = File.ReadAllText(usersPath);

        Dictionary<string, UserDTO> usersDtoDict = new Dictionary<string, UserDTO>();
        usersDtoDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(content);

        //make thet dictionary
        foreach (var kvp in usersDtoDict)
            {
                string key = kvp.Key;
                UserDTO dto = kvp.Value;
                usersDict[key] = new User(dto.UserName, dto.Password, dto.Email);
            }

        //check if the user has logged in before
        SingOrLog(path);

        //perform banking operations
        ChoseOperation();

        //Add logic to get the user key and make the position from the key = current user to update the dict
        
        //serialize the updated dictionary
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(usersDict, Newtonsoft.Json.Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(serializedObject);
            }
    }

    public static void ChoseOperation()
    {
        while (true)
        {
            System.Console.WriteLine("Welcome, " + currentUser._userName);
            System.Console.WriteLine("Choose an operation:");
            System.Console.WriteLine("1. Check balance");
            System.Console.WriteLine("2. Deposit money");
            System.Console.WriteLine("3. Withdraw money");
            System.Console.WriteLine("4. Transfer money");
            System.Console.WriteLine("5. Exit");

            string cmd = Console.ReadLine();

            switch (cmd)
            {
                case "1":
                    Operation.PrintBalance();
                    break;
                case "2":
                    Operation.Deposit();
                    break;
                case "3":
                    Operation.Withdraw();
                    break;
                case "4":
                    break;
                case "5":
                    System.Console.WriteLine("Goodbye!");
                    return;
                default:
                    System.Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static void SingOrLog(string path)
    {
        string cmd = string.Empty;

        System.Console.WriteLine("Do you have an account?");
        System.Console.WriteLine("If you do - type L to Log in");
        System.Console.WriteLine("If you dont - type S to sign in");
        cmd = Console.ReadLine();

        if (cmd == "S")
        {
            SignIn.Register();
            //updates the UserDict with the new User
        }
        else
        {
            Login.LoginService();
        }
    }
}