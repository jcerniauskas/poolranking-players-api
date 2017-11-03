using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poolranking_players_api.Data;
using poolranking_players_api.Models;

namespace poolranking_players_api.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private DataClient _dataClient;

        public PlayersController()
        {
            _dataClient = new DataClient();
        }

        [HttpGet]
        public async Task<List<Player>> Get()
        {
            return await _dataClient.GetPlayers();
        }

        [HttpGet("{id}")]
        public async Task<Player> Get(string id)
        {
            return await _dataClient.GetPlayer(id);
        }

        [HttpPost]
        public async Task<Player> Post([FromBody]NewPlayerCommand newPlayer)
        {
            Player player = new Player();
            player.Name = newPlayer.Name;

            return await _dataClient.CreatePlayerIfNotExists(player);
        }

        [HttpPut]
        public async Task<Player> Put([FromBody]Player modifiedPlayer)
        {
            return await _dataClient.UpdatePlayer(modifiedPlayer);
        }
    }
}
