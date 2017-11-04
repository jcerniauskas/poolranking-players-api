using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using poolranking_players_api.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace poolranking_players_api.Data
{
    public class DataClient
    {
        private readonly DocumentClient _client;

        public DataClient()
        {
            _client = new DocumentClient(new Uri(Constants.EndpointUri), Constants.PrimaryKey);
        }

        private Uri CreateUri(string playerId = null)
        {
            if (playerId != null)
            {
                return UriFactory.CreateDocumentUri(Constants.DatabaseName, Constants.CollectionName, playerId);
            }

            return UriFactory.CreateDocumentCollectionUri(Constants.DatabaseName, Constants.CollectionName);
        }

        public async Task<Player> CreatePlayerIfNotExists(Player player)
        {
            if (player.Id != null)
            {
                try
                {
                    var foundPlayer = await _client.ReadDocumentAsync(CreateUri(player.Id));

                    return foundPlayer.Resource.ConvertTo<Player>();
                }
                catch (DocumentClientException e)
                {
                    if (e.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw;
                    }

                    var createdPlayerWithId = await _client.CreateDocumentAsync(CreateUri(), player);

                    return createdPlayerWithId.Resource.ConvertTo<Player>();
                }
            }

            var newPlayer = await _client.CreateDocumentAsync(CreateUri(), player);

            return newPlayer.Resource.ConvertTo<Player>();
        }

        public async Task<Player> GetPlayer(string playerId)
        {
            if (playerId == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return await _client.ReadDocumentAsync<Player>(CreateUri(playerId));
        }

        public async Task<List<Player>> GetPlayers()
        {
            List<Player> results = new List<Player>();
            IDocumentQuery<Player> query = _client.CreateDocumentQuery<Player>(CreateUri(), new FeedOptions { MaxItemCount = -1 }).AsDocumentQuery();

            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Player>());
            }

            return results;
        }
        public async Task<Player> UpdatePlayer(Player player)
        {
            var updatedPlayer = await _client.ReplaceDocumentAsync(CreateUri(player.Id), player);

            return updatedPlayer.Resource.ConvertTo<Player>();
        }
    }
}