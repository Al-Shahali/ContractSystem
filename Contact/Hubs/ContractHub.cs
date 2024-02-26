using Microsoft.AspNetCore.SignalR;

namespace Contact.Hubs
{
    public class ContractHub :Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
