public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Token> Tokens { get; set; } // Отношение один ко многим с таблицей Tokens
    public List<Message> ReceivedMessages { get; set; } // Отношение один ко многим с таблицей Message
    public List<Message> SentMessages { get; set; } // Отношение один ко многим с таблицей Message

    public Token CreateNewToken()
    {
        
    }
}