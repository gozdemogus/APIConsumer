using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //List<CurrencyListViewModel> currencies = new List<CurrencyListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=AED&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "d80a8a96b9msh79c2f2fa5dedc03p1a4e44jsn8ee7fee646a7" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               var currencies = JsonConvert.DeserializeObject<CurrencyListViewModel>(body);
                return View(currencies.exchange_rates);
            }
        }
    }
}

