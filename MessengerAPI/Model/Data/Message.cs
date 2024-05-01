public class Message
{
    public long Id { get; set; }
    public long ToId { get; set; }
    public User ToUser { get; set; }
    public long FromId { get; set; }
    public User FromUser { get; set; }
    public long ContextId { get; set; }
    public List<Content> Context { get; set; } 
    public DateTime SendTime { get; set; }
    public DateTime UpdateTime { get; set; }
}