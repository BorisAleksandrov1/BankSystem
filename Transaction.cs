using System.Runtime.CompilerServices;

class UserTransfer
{
    public static User userToSend;
    public static string userToSendKey;

    public static void Transfer()
    {
        GetUser();
        decimal amount = GetAmount();

        bankLogic.currentUser._currentAccount._balance -= amount;
        userToSend._currentAccount._balance += amount;

        //update userToSend in dict
        bankLogic.usersDict[userToSendKey] = userToSend;
    }

    public static decimal GetAmount()
    {
        System.Console.WriteLine("Enter the amount that you want to transfer");
        decimal amount = decimal.Parse(Console.ReadLine());
        return amount;
    }

    public static void GetUser()
    {
        System.Console.WriteLine("Please write the email of the person that you want to transfer the money");
        string email = Console.ReadLine();
        while(!CheckUser(email))
        {
            System.Console.WriteLine("This user does not exist please write a valid email");
            email = Console.ReadLine();
        }
    }

    public static bool CheckUser(string email)
    {
        foreach (var user in bankLogic.usersDict)
            {
                if(user.Value._email == email)
                {
                    userToSend = user.Value;
                    userToSendKey = user.Key;
                    return true;
                }
            }
        return false;
    }
}