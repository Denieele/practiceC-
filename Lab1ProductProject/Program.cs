using System;

class Product
{
    private string name;
    private decimal price;
    private int quantity;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва не може бути порожньою.");
            name = value;
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Ціна не може бути від'ємною.");
            price = value;
        }
    }

    public int Quantity => quantity;

    public decimal TotalValue => price * quantity;

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        this.quantity = quantity;
    }

    public void Restock(int amount)
    {
        if (amount > 0)
            quantity += amount;
    }

    public void Sell(int amount)
    {
        if (amount > quantity)
            Console.WriteLine("Недостатньо товару на складі!");
        else
            quantity -= amount;
    }

    public string GetInfo()
    {
        return $"Товар: {Name}, Ціна: {Price} грн, Кількість: {Quantity}, Загальна вартість: {TotalValue} грн";
    }
}

class Program
{
    static void Main()
    {
        Product apple = new Product("Яблуко", 5, 100);
        Console.WriteLine(apple.GetInfo());

        apple.Sell(20);
        Console.WriteLine(apple.GetInfo());

        apple.Restock(50);
        Console.WriteLine(apple.GetInfo());

        apple.Price = 7;
        Console.WriteLine(apple.GetInfo());

        apple.Name = "Зелене яблуко";
        Console.WriteLine(apple.GetInfo());

        try
        {
            apple.Price = -10;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        try
        {
            apple.Name = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        apple.Sell(200);
    }
}