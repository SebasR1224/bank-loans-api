namespace BankLoans.Models;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    private User(string name, string email, string password, string role)
    {
        Id = Guid.NewGuid().ToString("N");
        Name = name;
        Password = password;
        Email = email;
        Role = role;
    }

    public static User Create(string name, string email, string password, string role)
    {
        return new User(name, email, password, role);
    }
}
