using System.Globalization;

public class Token
{
    public long Id { get; set; }
    public string TokenValue { get; set; }
    public DateTime Deadtime { get; set; }

    public long UserId { get; set; } // Внешний ключ для связи с таблицей User
    public User ConnectUser { get; set; } // Навигационное свойство к пользователю
    
    public Token(long id, User user)
    {
        Id = id;
        TokenValue = new Random().Next(9999999, 10000000).ToString();
        ConnectUser = user;
    }
}