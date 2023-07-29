using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Proxies
{
     public abstract class Proxy
     {
         public readonly ApiUrls _apiUrls;
         public readonly HttpClient _httpClient;

         public Proxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient)
         {
             _apiUrls = apiUrls.Value;
             _httpClient = httpClient;
         }
     }
}
