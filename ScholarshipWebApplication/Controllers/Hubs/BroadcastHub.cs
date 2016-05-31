using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace ScholarshipWebApplication.Controllers.Hubs
{
    public class BroadcastHub : Hub
    {
        public void Hello(string message)
        {
            Clients.All.displayNotification(message);
        }
    }

    public class Broadcast
    {
        private readonly static Lazy<Broadcast> _instance = new Lazy<Broadcast>(() => new Broadcast(GlobalHost.ConnectionManager.GetHubContext<BroadcastHub>().Clients));

        public static Broadcast Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private Broadcast(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        public void DisplayNotification(string message)
        {
            Clients.All.updateStockPrice(message);
        }
    }
}