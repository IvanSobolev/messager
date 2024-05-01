public class Content
{
    public long Id { get; set; }
    public long MessageId { get; set; }
    public Message message { get; set; }
    public ContentType Type { get; set; }
    public string ContentValue { get; set; }
}