using HubChatEjemplo.Models;
using HubChatEjemplo.Models.StaticModels;
using Microsoft.AspNetCore.SignalR;

namespace HubChatEjemplo.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessaje(MessageModel messageModel)
        {
            await Clients.All.SendAsync("Receivemessage",messageModel);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (UsersOnline.Online.TryGetValue(Context.ConnectionId, out var nickname))
            {
                UsersOnline.Online.Remove(Context.ConnectionId);
                await Clients.All.SendAsync("UsuarioDesconectado", nickname);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task RegistrarUsuario(string nickname)
        {
            UsersOnline.Online[Context.ConnectionId] = nickname;

            await Clients.All.SendAsync("UsuarioConectado", nickname, UsersOnline.Online.Values.ToList());
        }
    }
}
