using System;

namespace poolranking_players_api.Models
{
    public class ModifyPlayerCommand
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
