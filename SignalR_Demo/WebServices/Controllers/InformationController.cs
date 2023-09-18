using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebServices.Hubs;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private IHubContext<MyHub> _hubContext;

        public InformationController(IHubContext<MyHub> hubContext) 
        { 
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Send(string message) 
        {
            await _hubContext.Clients.All.SendAsync("sendMessage",message);
            return Ok();
        }

        public async Task<IActionResult> Test()
        {
            return Ok("Hola mundo");
        }

    }
}
