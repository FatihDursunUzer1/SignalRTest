using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.API.Hubs
{
	public class LocationHub:Hub
	{
		public async Task SendUserLocation(string userId, Models.Location location)
		{
			await Clients.All.SendAsync("LocationMessage",userId,location);
		}
	}
}

