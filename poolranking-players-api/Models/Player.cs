using Newtonsoft.Json;

namespace poolranking_players_api.Models
{
    public class Player : NewPlayerCommand
    {
        public Player() { }

        public Player(NewPlayerCommand newPlayer)
        {
            Name = newPlayer.Name;
            Rating = newPlayer.Rating;
            Deviation = newPlayer.Deviation;
            Volatility = newPlayer.Volatility;
        }

        [JsonProperty("id")]
        public string Id { get; set; }
     }
}
