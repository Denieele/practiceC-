namespace Lab1;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Product apple = new Product("Apple", 5, 100);
            apple.GetInfo();
            
            apple.Sell(20);
            apple.GetInfo();
            
            apple.Restock(50);
            apple.GetInfo();

            apple.Price = 7;
            apple.GetInfo();

            apple.Name = "Green apple";
            apple.GetInfo();

            apple.Price = -1;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Caught an error: {e}");
        }
    }
}