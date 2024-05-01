public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Token> Tokens { get; set; } = new List<Token>();
    public List<Message> ReceivedMessages { get; set; } = new List<Message>();
    public List<Message> SentMessages { get; set; } = new List<Message>();

    public Token CreateNewToken(int tokenId)
    {
        Token token = new Token(tokenId, this); 
        Tokens.Add(token);
        return token;
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}