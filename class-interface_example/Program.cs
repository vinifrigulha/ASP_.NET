class Program
{
    static void Main()
    {
        ILogger logger = new FileLogger();
        BankAccount account1 = new BankAccount("Vinícius", 100, logger);
        BankAccount account2 = new BankAccount("Mariana", 100, logger);

        account1.Deposit(-100);
        
        account2.Deposit(150);

        Console.WriteLine(account2.Balance);

    }
    
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
        File.AppendAllText("log.txt", $"{message}\n");
    }
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"LOGGER: {message}");
    }
}

interface ILogger
{
    void Log(string message);
}

class BankAccount
{
    private string name;
    private readonly ILogger logger;

    public decimal Balance 
    { 
        get; private set;
    }

    public BankAccount(string name, decimal balance, ILogger logger)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Nome inválido.");
        }
        if (balance < 0)
        {
            throw new Exception("Saldo não pode ser negativo.");
        }
        this.name = name;
        Balance = balance;
        this.logger = logger;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            logger.Log($"Não é possível depositar {amount} na conta de {name}.");
            return;
        }
        Balance += amount;
    }

}
