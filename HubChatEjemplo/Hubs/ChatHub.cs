using HubChatEjemplo.Models;
using Microsoft.AspNetCore.SignalR;

namespace HubChatEjemplo.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessaje(MessageModel messageModel)
        {
            await Clients.All.SendAsync("Receivemessage",messageModel);
        }
    }
}
