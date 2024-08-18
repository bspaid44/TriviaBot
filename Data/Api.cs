using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBot.Data
{
    internal class Api
    {
        public async Task<Root> GetTriviaQuestion(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "TriviaBot/1.0");
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var maps = JsonConvert.DeserializeObject<Root>(content);
            return maps;
        }
    }
}
