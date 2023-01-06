class Program
{
    static void Main()
    {
        Console.Write("What is your name? A: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hi, {name}! Nice to meet you :)");
        
        while (true)
        {
            try
            {
                Console.Write("\nWhen were you born? A: ");
                int year = int.Parse(Console.ReadLine());
                int age = int.Parse(DateTime.Now.ToString("yyyy")) - year;
                
                if ((year < 0) || (year > int.Parse(DateTime.Now.ToString("yyyy"))))
                {
                    Console.WriteLine("Oops... :(");
                    Console.WriteLine("Invalid year. Please try again!");
                }
                else
                {
                    Console.WriteLine($"Awesome!! So you are or will be {age} years old this year!");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}"); // Tells what excetion happened
                Console.WriteLine($"\n{e.StackTrace}"); // Tells where is located the exception
                Console.WriteLine($"\nPlease try again!");
            }
        }
    }
}
