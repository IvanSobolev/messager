public class Message
{
    public long Id { get; set; }
    public long ToId { get; set; }
    public User ToUser { get; set; } // Навигационное свойство к пользователю, которому адресовано сообщение
    public long FromId { get; set; }
    public User FromUser { get; set; } // Навигационное свойство к пользователю, отправившему сообщение
    public long ContextId { get; set; }
    public List<Content> Context { get; set; } // Навигационное свойство к контенту сообщения
    public DateTime SendTime { get; set; }
    public DateTime UpdateTime { get; set; }
}