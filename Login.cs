class Login
{
    public static void LoginService()
    {
        System.Console.WriteLine("Enter your email address");
            string? email = Console.ReadLine();

            while (!ContainsUserName(email, bankLogic.usersDict))
            {
                System.Console.WriteLine("User not found. Please enter a valid email.");
                email = Console.ReadLine();
            }

        foreach (var user in bankLogic.usersDict)
            {

                if(user.Value._email == email)
                {
                    bankLogic.currentUser = user.Value;
                    bankLogic.currentKey = user.Key;
                    break;
                }
            }

        System.Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            while(bankLogic.currentUser.Password != password)
            {
                System.Console.WriteLine("Incorrect password. Please enter your password.");
                password = Console.ReadLine();
            }
    }

    public static bool ContainsUserName(string email, Dictionary<string, User> usersDict)
    {
        foreach (var item in usersDict)
        {
            var userCheck = item.Value;

            if (userCheck._email == email)
            {
                return true;
            }
        }
        return false;
    }
}