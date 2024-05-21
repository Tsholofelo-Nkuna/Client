using Client.Model.DatabaseViews;
using Client.Service;
using Client.SQLServer.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService) {
         this._clientService = clientService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<ClientDetailsViewItem> Get()
        {
            return this._clientService.GetAllClients();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ClientDetailsViewItem? Get(long id)
        {
            return this._clientService.GetClient(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] ClientDetailsViewItem value)
        {
            var clientToAdd = new Model.Entities.ClientEntity
            {
                ContactNumber = value.ContactNumber,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Id = value.ClientUniqueId,
                Gender = value.Gender,

            };
           var affectedRowCount = this._clientService.AddClient(clientToAdd);
            
            this._clientService.AddClientAddress(new Model.Entities.AddressEntity
            {
                ClientUniqueId = value.ClientUniqueId <= 0 && affectedRowCount > 0 ? this._clientService.LastInsertedClientId ?? 0 : value.ClientUniqueId,
                Description = value.AddressDescription,
                Id = value.AddressUniqueId ?? 0,
            });
        }


        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
           return this._clientService.DeleteClient(id);
        }
    }
}
