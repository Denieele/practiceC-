namespace Lab2;

public class RegularUser : User
{
    public void PostComment()
    {
        Console.WriteLine("Comment was posted");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Role: regular user");
    }

}