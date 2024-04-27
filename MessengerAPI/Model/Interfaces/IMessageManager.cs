public interface IMessageManager
{
    List<Message> GetMessageHistory(string token, long userIdChat);
    List<User> GetActiveChat(string token);
    List<Message> SendMessage(string token, long userToId);
    List<Message> UpdateMessage(string token, long userToId, Message newMessage);
}