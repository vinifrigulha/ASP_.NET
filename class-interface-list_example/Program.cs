class Program
{
    static void Main()
    {
        ILogger logger = new FileLogger("mylog.txt");
        BankAccount account1 = new BankAccount("Vinícius", 100, logger);
        BankAccount account2 = new BankAccount("Mariana", 100, logger);

        List<BankAccount> accounts = new List<BankAccount>
        {
            account1,
            account2
        };

        //accounts.Add(account1);
        //accounts.Add(account2);

        //accounts.Remove(account1);

        List<int> numbers = new List<int> {1, 4, 8, 10};

        DataStore<string> store = new DataStore<string>();
        store.Value = "Vinícius";
        Console.WriteLine(store.Value.Length);

    }
    
}

/*
    Criando uma lista com um tipo aleatório
*/

class DataStore<T>
{
    public T Value {get; set;}
}

class FileLogger : ILogger
{
    private readonly string filePath;

    public FileLogger(string filePath)
    {
        this.filePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(filePath, $"{message}\n");
    }
}

class ConsoleLogger : ILogger
{
}

interface ILogger
{
    void Log(string message)
    {
        Console.WriteLine($"LOGGER: {message}");
    }
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
