using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Map.Location.BI.Interfaces;
using Map.Location.Data.Base;

namespace Map.Location.API.Hubs
{
    public class GeolocationHub : Hub
    {
        private const string dispatcher = "dispatcher";
        private readonly IGeolocation _geolocation;
        private readonly IFires _fires;
        private static Dictionary<string, Coordinates> UsersOnMap = new Dictionary<string, Coordinates>();

        public GeolocationHub(IGeolocation geolocation, IFires fires)
        {
            _geolocation = geolocation;
            _fires = fires;
        }

        public async Task GetFires()
        {
            await Clients.Caller.SendAsync("Fires", _fires.GetFires());
        }

        public async Task OnM4SLocation(string lng, string lat)
        {
            UsersOnMap[Context.ConnectionId].Lat = Parse(lat);
            UsersOnMap[Context.ConnectionId].Lon = Parse(lng);

            await Clients.Caller.SendAsync("M4S", UsersOnMap.Where(x => x.Key != Context.ConnectionId).Select(x => x.Value).ToArray());
        }

        public async Task JoinFamaly(string connectionId, string type)
        {
            await Groups.AddToGroupAsync(connectionId, type);
            await Clients.Group(dispatcher).SendAsync("Подключен новый спасатель.");
        }

        public override async Task OnConnectedAsync()
        {
            await JoinFamaly(Context.ConnectionId, "Default");

            await base.OnConnectedAsync();
        }

        private double Parse(string d) => double.Parse(d);
    }
}
