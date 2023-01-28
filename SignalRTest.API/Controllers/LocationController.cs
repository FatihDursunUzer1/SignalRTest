using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRTest.API.Constants;
using SignalRTest.API.Hubs;
using SignalRTest.API.Models;

namespace SignalRTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IHubContext<LocationHub> _hubContext;
        public LocationController(IHubContext<LocationHub> hubContext)
        {
            _hubContext=hubContext;
        }

        [HttpPost]
        public async Task<bool> TakeLocation(string userId,Location location)
        {
           await _hubContext.Clients.All.SendAsync(HubConstants.SendLocation, userId, location.Latitude,location.Longitude);
            return true;
        }
    }
}