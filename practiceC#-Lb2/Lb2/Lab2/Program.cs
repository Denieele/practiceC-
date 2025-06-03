namespace Lab2;
class Program
{
    public static void Main(string[] args)
    {
        List<User> users = new List<User>();
        
        var admin = new Admin { UserName = "admin1", Email = "admin@site.com" };
        admin.SetPassword("admin123");
        users.Add(admin);

        var moderator = new Moderator { UserName = "moder1", Email = "moder@site.com" };
        moderator.SetPassword("moder123");
        users.Add(moderator);

        var regularUser = new RegularUser { UserName = "user1", Email = "user@site.com" };
        regularUser.SetPassword("user123");
        users.Add(regularUser);
        
        foreach (var user in users)
        {
            Console.WriteLine("\n--- Information about a user ---");
            user.DisplayInfo();
            
            Console.WriteLine($"\nAuthentication {user.UserName}:");
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();
            
            if (user.Authenticate(password))
            {
                Console.WriteLine("Authenticated successfully!");
                
                if (user is Admin adm)
                {
                    adm.BlockUser(regularUser);
                }
                else if (user is Moderator mod)
                {
                    mod.ModerateContent();
                }
                else if (user is RegularUser reg)
                {
                    reg.PostComment();
                }
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}