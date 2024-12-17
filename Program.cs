using System.ComponentModel;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //read the json and get the dictionary of users

        string path = Path.Combine("C:", "Users", "Admin", "Projects", "BankSystem");
        string usersPath = Path.Combine(path, "Users.json");

        string content = File.ReadAllText(usersPath);

        System.Console.WriteLine(content);

        //make thet dictionary
        Dictionary<string, User> UsersDict = new Dictionary<string, User>();
        UsersDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, User>>(content);

        //check if the user has logged in before
        string cmd = string.Empty;

        System.Console.WriteLine("Do you have an account?");
        System.Console.WriteLine("If you do - type L to Log in");
        System.Console.WriteLine("If you dont - type S to sign in");
        cmd = Console.ReadLine();

        if (cmd == "S")
        {
            System.Console.WriteLine("Whats do you want your user name to be");
            string newName = Console.ReadLine();

            System.Console.WriteLine("Create a password");
            string password = Console.ReadLine();

            //check the password
            while (true)
            {
                if (!Regex.IsMatch(password, "^(?=.*[a-z]{8,})(?=.*\\d).+$"))
                {
                    Console.WriteLine("Password must have at least 8 lowercase letters and 1 number.");
                }
                else
                {
                    Console.WriteLine("Password set successfully!");
                    break;
                }

                Console.WriteLine("Please enter a valid password:");
                password = Console.ReadLine(); // Ask for input again
            }

            User currentUser = new User(newName, password);

            //create an guid id
            string newId = Guid.NewGuid().ToString();

            UsersDict.Add(newId, currentUser);

            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(UsersDict, Newtonsoft.Json.Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(usersPath))
            {
                sw.Write(serializedObject);
            }
        }

    }
}