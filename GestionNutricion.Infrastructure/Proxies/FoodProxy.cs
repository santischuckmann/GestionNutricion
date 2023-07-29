using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Proxies
{
    public class FoodForNow
    {
        public string Name { get; set; }
        public int IdType { get; set; }
    }

    public interface IFoodProxy
    {
        public Task AddFood();
    }
    public class FoodProxy : Proxy, IFoodProxy
    {
        public FoodProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient) : base(apiUrls, httpClient)
        {
        }

        public async Task AddFood()
        {

            var content = new StringContent(
                JsonSerializer.Serialize(new FoodForNow
                {
                    Name = "Carne",
                    IdType = 1
                }), 
                Encoding.UTF8,
                "application/json"
                );

            var request = await _httpClient.PostAsync(_apiUrls.FoodUrl + "/api/Food", content);

            request.EnsureSuccessStatusCode();
        }
    }
}
