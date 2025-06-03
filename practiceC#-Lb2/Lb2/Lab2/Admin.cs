namespace Lab2;

public class Admin : User
{
    public void BlockUser(User user)
    {
        Console.WriteLine($"User {user.UserName} was blocked");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Role: Administrator");
    }
}