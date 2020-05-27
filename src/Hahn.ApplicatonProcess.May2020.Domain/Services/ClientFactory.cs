using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class ClientFactory
    {
        private static readonly HttpClient client  = new HttpClient();
        public static async Task<bool> GetResult(string name) 
        {
            var requestUri = "https://restcountries.eu/rest/v2/name/" + name + "?fullText=true";
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

    }
}
