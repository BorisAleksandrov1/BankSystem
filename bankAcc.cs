public class bankAccount
{
    public string _name;
    public decimal _balance;

    public bankAccount(string name)
    {
        _name = name;
    }

    public static void CreateAccount()
    {
        System.Console.WriteLine("Create a name for your account");
        string name = Console.ReadLine();

        bankAccount newAccount = new bankAccount(name);
        string newAccountID = Guid.NewGuid().ToString();

        bankLogic.currentUser._accounts.Add(newAccountID, newAccount);
        System.Console.WriteLine("Successfully created a new account called " + name);
    }

    public static void ChangeAccount()
    {
        System.Console.WriteLine("Here are your accounts");

        foreach (var kvp in bankLogic.currentUser._accounts)
        {
            bankAccount currentAccount = kvp.Value;
            Console.Write($"{currentAccount._name}, ");
        }

        System.Console.WriteLine("Which one do you want to use?");
        string cmd = Console.ReadLine();

        while (true)
        {
            foreach (var kvp in bankLogic.currentUser._accounts)
            {
                bankAccount currentAccount = kvp.Value;

                if (cmd == currentAccount._name)
                {
                    bankLogic.currentUser._currentAccount = currentAccount;
                    return;
                }
            }

            System.Console.WriteLine("No bank account called " + cmd);
            System.Console.WriteLine("Please write a valid name");
            cmd = Console.ReadLine();
        }
    }
}