public class UserManager : IUserManager
{
    private readonly MessengerContext _context;

    public UserManager(MessengerContext context)
    {
        _context = context;
    }

    Token Register(User user)
    {
        if(_context.Users.Any(u => u.Email == user.Email))
        {
            return null;
        }
        user.Id = _context.Users.Count() + 1;
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    Token LogIn(string login, string password)
    {

    }

    void Logout(string token)
    {

    }
}