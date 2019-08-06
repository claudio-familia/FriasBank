using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FriaBank.Models;
using Newtonsoft.Json;

namespace FriaBank.Services
{
    public class BeerService : IBeerService
    {
        public async Task<IEnumerable<Beer>> GetAllSeriesAsync(int page, int perPage)
        {
            var beers = new List<Beer>();
            try
            {
                using(var client = new HttpClient())
                {
                    var url = $"https://api.punkapi.com/v2/beers?page={page}&per_page={perPage}";
                    var response = await client.GetStringAsync(url);
                    //var response = await client.GetStringAsync("https://api.punkapi.com/v2/beers");
                    beers = JsonConvert.DeserializeObject<List<Beer>>(response);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
            }
            return beers;
        }        
    }
}
