using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Adapters.HetznerCloud.Repositories;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.CommandHandler;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCMonitoring.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        // GET: api/Servers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllServersCommand command = new GetAllServersCommand();
            
            HetznerCloudApiRepository hetznerCloudApiRepository = new HetznerCloudApiRepository("HERE GOES API KEY");

            GetAllServersCommandHandler commandHandler = new GetAllServersCommandHandler(hetznerCloudApiRepository);
            var servers = await commandHandler.Handle(command);
            return Ok(servers);
        }

        // GET: api/Servers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Servers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
