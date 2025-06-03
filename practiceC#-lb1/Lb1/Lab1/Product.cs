namespace Lab1;

public class Product
{
    private string _name;
    private decimal _price;
    private int _quantity;

    private decimal TotalValue => _price * _quantity;
    
    public Product(string name, decimal price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public string Name
    {
        get => _name;
        set => _name = !string.IsNullOrEmpty(value) 
            ? value 
            : throw new ArgumentException("Name cannot be null or empty");
    }

    public decimal Price
    {
        get => _price;
        set => _price = value >= 0 
            ? value 
            : throw new ArgumentException("Price cannot be negative");
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value >= 0 
            ? value 
            : throw new ArgumentException("Quantity cannot be negative");
    }

    public void Sell(int amount)
    {
        if(amount <= 0) 
            throw new ArgumentException("Amount cannot be negative");
        if(_quantity < amount)
            throw new ArgumentException("Not enough quantity on warehouse");
        _quantity -= amount;
        Console.WriteLine($"Sold {amount} of the product {_name}");
    }

    public void Restock(int amount)
    {
        if(amount <= 0) 
            throw new ArgumentException("Amount of supply cannot be negative");
        _quantity += amount;
        Console.WriteLine($"Restocked {amount} of the product {_name}");
    }

    public void GetInfo()
    {
        Console.WriteLine($"Product: {_name}, Price: {_price}, Quantity: {_quantity}, Overall cost: {TotalValue}");
    }
}