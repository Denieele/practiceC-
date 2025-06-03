namespace Lab2;

public class Moderator : User
{
    public void ModerateContent()
    {
        Console.WriteLine("Content was moderated");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Role: Moderator");
    }
}