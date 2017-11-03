using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using poolranking_players_api.Models;

namespace poolranking_players_api.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        [HttpGet("{id}")]
        public Player Get(string id)
        {
            return Player.GetMockedPlayer(id);
        }

        [HttpPost]
        public Player Post([FromBody]NewPlayerCommand newPlayer)
        {
            Player player = Player.GetMockedPlayer();
            player.Name = newPlayer.Name;

            return player;
        }

        [HttpPut("{id}")]
        public Player Put(string id, [FromBody]ModifyPlayerCommand modifiedPlayer)
        {
            Player player = Player.GetMockedPlayer(id);
            player.Name = modifiedPlayer.Name;
            player.Rating = modifiedPlayer.Rating;

            // Todo: Store new modified player object

            return player;
        }
    }
}
