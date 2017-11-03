using System;

namespace poolranking_players_api.Models
{
    public class NewPlayerCommand
    {
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public decimal Deviation { get; set; }
        public decimal Volatility { get; set; }
    }
}
