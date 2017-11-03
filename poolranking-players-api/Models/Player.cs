using System;

namespace poolranking_players_api.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public static Player GetMockedPlayer(string id = null)
        {
            return new Player
            {
                Id = (id ?? Guid.NewGuid().ToString()),
                Name = "Mocked Player",
                Rating = (new Random()).Next(1, 100)
            };
        }
    }
}
