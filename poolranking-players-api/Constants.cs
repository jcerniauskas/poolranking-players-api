using System;

namespace poolranking_players_api
{
    public static class Constants
    {
        public static string EndpointUri => Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT");
        public static string PrimaryKey => Environment.GetEnvironmentVariable("COSMOSDB_KEY");
        public static string DatabaseName => "Rankings";
        public static string CollectionName => "Player";
    }
}
