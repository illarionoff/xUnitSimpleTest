namespace TestApp.Functionality;

public record User (string firstName, string lastName)
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string PhoneNumber { get; set; }
    public bool VerifiedEmail { get; set; } = false;
}

public class UserManagement
{
    private readonly List<User> _users = new();
    private int idCounter = 1;

    public IEnumerable<User> AllUsers => _users;
    public void AddUser(User user)
    {
        _users.Add(user with {Id = idCounter++ });
    }

    public void UpdatePhone(User user)
    {
        var dbUSer = _users.First(x => x.Id == user.Id);
        dbUSer.PhoneNumber= user.PhoneNumber;
    }

    public void VerifyEmail(int userId)
    {
        var dbUSer = _users.First(x => x.Id == userId);
        dbUSer.VerifiedEmail = true;
    }
}
