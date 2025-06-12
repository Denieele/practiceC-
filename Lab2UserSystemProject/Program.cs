using System;
using System.Collections.Generic;

class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    private string _password;

    public void SetPassword(string newPassword)
    {
        _password = newPassword;
    }

    public bool Authenticate(string inputPassword)
    {
        return _password == inputPassword;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {UserName} | Email: {Email}");
    }
}

class Admin : User
{
    public void BlockUser(User user)
    {
        Console.WriteLine($"Користувача {user.UserName} заблоковано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Роль: Адміністратор");
    }
}

class Moderator : User
{
    public void ModerateContent()
    {
        Console.WriteLine("Контент модеровано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Роль: Модератор");
    }
}

class RegularUser : User
{
    public void PostComment()
    {
        Console.WriteLine("Коментар опубліковано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Роль: Звичайний користувач");
    }
}

class Program
{
    static void Main()
    {
        List<User> users = new List<User>
        {
            new Admin { UserName = "AdminUser", Email = "admin@example.com" },
            new Moderator { UserName = "ModUser", Email = "mod@example.com" },
            new RegularUser { UserName = "RegUser", Email = "user@example.com" }
        };

        users[0].SetPassword("admin123");
        users[1].SetPassword("mod123");
        users[2].SetPassword("user123");

        Console.WriteLine("=== Інформація про користувачів ===");
        foreach (var user in users)
            user.DisplayInfo();

        Console.WriteLine("\n=== Тестування методів ===");

        if (users[0] is Admin admin)
            admin.BlockUser(users[2]);

        if (users[1] is Moderator moderator)
            moderator.ModerateContent();

        if (users[2] is RegularUser regularUser)
            regularUser.PostComment();

        Console.WriteLine("\n=== Перевірка аутентифікації ===");
        Console.WriteLine($"AdminUser: {(users[0].Authenticate("admin123") ? "Успішна аутентифікація" : "Невірний пароль")}");
        Console.WriteLine($"ModUser: {(users[1].Authenticate("wrong") ? "Успішна аутентифікація" : "Невірний пароль")}");
        Console.WriteLine($"RegUser: {(users[2].Authenticate("user123") ? "Успішна аутентифікація" : "Невірний пароль")}");
    }
}