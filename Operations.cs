class Operation
{
    public static void PrintBalance()
    {
        Console.Clear();
        Console.WriteLine($"Your current balance is: {bankLogic.currentUser._balance}");
    }

    public static void Deposit()
    {
        Console.Clear();
        Console.Write("Enter the amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        bankLogic.currentUser._balance += amount;
        Console.WriteLine($"Deposit successful. Your new balance is: {bankLogic.currentUser._balance}");
    }

    public static void Withdraw()
    {
        Console.Clear();
        Console.Write("Enter the amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        bankLogic.currentUser._balance -= amount;
        Console.WriteLine($"Withdrawal successful. Your new balance is: {bankLogic.currentUser._balance}");
    }
}