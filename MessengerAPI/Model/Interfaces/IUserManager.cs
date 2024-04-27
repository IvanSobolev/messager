public interface IUserManager
{
    Token Register(User user);
    Token LogIn(string login, string password);
    void Logout(string token);
}