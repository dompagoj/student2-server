using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Student2.Server.SignalRHubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
