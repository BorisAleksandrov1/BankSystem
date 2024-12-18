using System.ComponentModel;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //read the json and get the dictionary of users

        string path = Path.Combine("C:", "Users", "Admin", "Projects", "BankSystem");
        string usersPath = Path.Combine(path, "Users.json");

        string content = File.ReadAllText(usersPath);

        //make thet dictionary
        Dictionary<string, UserDTO> UsersDictDTO = new Dictionary<string, UserDTO>();
        UsersDictDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(content);

        Dictionary<string, User> usersDict = new Dictionary<string, User>();
        foreach (var user in UsersDictDTO)
        {
            string key = user.Key;
            UserDTO dto = user.Value;

            usersDict[key] = new User(dto.UserName, dto.Password);
        }

        //check if the user has logged in before
        string cmd = string.Empty;

        System.Console.WriteLine("Do you have an account?");
        System.Console.WriteLine("If you do - type L to Log in");
        System.Console.WriteLine("If you dont - type S to sign in");
        cmd = Console.ReadLine();

        User currentUser;

        if (cmd == "S")
        {
            System.Console.WriteLine("Whats do you want your user name to be");
            string newName = Console.ReadLine();

            System.Console.WriteLine("Create a password");
            string password = Console.ReadLine();

            //check the password
            CheckPassword(password);

            User newUser = new User(newName, password);
            currentUser = newUser;
            string newId = Guid.NewGuid().ToString();

            usersDict.Add(newId, newUser);

            //serialize the updated dictionary
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(usersDict, Newtonsoft.Json.Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(usersPath))
            {
                sw.Write(serializedObject);
            }
        }
        else
        {
            System.Console.WriteLine("Enter your user name");
            string userName = Console.ReadLine();

            foreach(var item in usersDict)
            {
                var userCheck = item.Value;

                if(userCheck.UserName == userName)
                {

                }
            }
        }

    }

    public static void FindUserName(string name, Dictionary<string, User> usersDict)
    {
        
    }

    public static void CheckPassword(string password)
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
            if(valid)
            {
                Console.WriteLine("Password set successfully!");
                break;
            }

            Console.WriteLine("Please enter a valid password:");
            password = Console.ReadLine(); // Ask for input again
        }
    }
}