public class UserManager : IUserManager
{
    private readonly MessengerContext _context;

    public UserManager(MessengerContext context)
    {
        _context = context;
    }

    public Token Register(User user)
    {
        if(_context.Users.Any(u => u.Email == user.Email))
        {
            return null;
        }
        
        user.Id = _context.Users.Count() + 1;
        Token regToken = user.CreateNewToken(_context.Tokens.Count() + 1);

        _context.Users.Add(user);
        _context.Tokens.Add(regToken);
        _context.SaveChanges();
        return regToken;
    }

    public Token LogIn(string login, string password)
    {
        User user = _context.Users.FirstOrDefault(u => u.Email == login && u.Password == password);
        if(user==null)
        {
            return null;
        }
        Token newToken = user.CreateNewToken(_context.Tokens.Count() + 1);
        _context.Tokens.Add(newToken);
        _context.SaveChanges();
        return newToken;
    }

    public void Logout(string token)
    {
        _context.Tokens.Where(t => t.TokenValue == token).ToList().ForEach(t => _context.Tokens.Remove(t));
        _context.SaveChanges();
    }
}