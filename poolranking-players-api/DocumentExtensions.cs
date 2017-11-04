using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace poolranking_players_api
{
    public static class DocumentExtensions
    {
        public static T ConvertTo<T>(this Document document) where T : class
        {
            return JsonConvert.DeserializeObject<T>(document.ToString());
        }
    }
}
