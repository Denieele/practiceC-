namespace Lab2;

using System.Text;

public class User
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    private string? _password;

    public void SetPassword(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new ArgumentException("Password cannot be null or empty");

        if (newPassword.Length < 6) 
            throw new ArgumentException("Password must be at least 6 characters");

        _password = HashPassword(newPassword); 
    }


    public bool Authenticate(string inputPassword)
    {
        if (string.IsNullOrEmpty(_password))
            return false;
        
        return VerifyPassword(inputPassword, _password);
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {UserName}");
        Console.WriteLine($"Email: {Email}");
    }

    private String HashPassword(string Password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string inputPassword, string storedHash)
    {
        var hash = HashPassword(inputPassword);
        return hash == storedHash;
    }
}