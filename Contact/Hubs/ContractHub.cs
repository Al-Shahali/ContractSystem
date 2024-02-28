using Microsoft.AspNetCore.SignalR;

namespace Contact.Hubs
{
    public class ContractHub :Hub
    {
        public static List<string> Editing = new();
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public async Task RowSelect(string ConCod)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("RowSelected", ConCod);
        }
        public async Task RowEdite(string ConCod)
        {
            if (!Editing.Contains(ConCod))
                Editing.Add(ConCod);
            await Clients.AllExcept(Context.ConnectionId).SendAsync("RowEditing", Editing);
        }
        public async Task CheckEdite()
        {
            await Clients.Caller.SendAsync("RowEditing", Editing);
        }
    }
}
