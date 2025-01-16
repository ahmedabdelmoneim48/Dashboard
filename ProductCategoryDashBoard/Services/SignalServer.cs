using Microsoft.AspNetCore.SignalR;

public class SignalServer : Hub
{
    // You can add methods here that clients can call
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
