namespace shop_giay
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }

}
