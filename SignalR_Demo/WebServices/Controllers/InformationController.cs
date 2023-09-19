using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebServices.Hubs;

namespace WebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private IHubContext<MyHub> _hubContext;
        private DemoRepository _repository;

        public InformationController(IHubContext<MyHub> hubContext, DemoRepository demoRepository) 
        { 
            _hubContext = hubContext;
            _repository = demoRepository;
        }

        public async Task<IActionResult> Send(int id) 
        {
            try 
            {
                Demo information = await _repository.GetMessageById(id);
                await _hubContext.Clients.All.SendAsync("sendInformation", information);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {

            try
            {
                List<String> products = new List<String>();
                products.Add("Hola");
                products.Add("soy");
                products.Add("una lista");
                return Ok("Hola mundo");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
