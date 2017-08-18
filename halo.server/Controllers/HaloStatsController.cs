using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace halo.server.Controllers
{
    [Route("api/[controller]")]
    public class HaloStatsController : Controller
    {
        private readonly string _secretApiKey;
        public HaloStatsController(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var tempKey = configuration["haloApiKey"];
            if (string.IsNullOrEmpty(tempKey))
            {
                throw new ArgumentException("Cannot find configuration key haloApiKey. Ensure that you have setup secrets for .net core with your halo api development key.");
            }
            _secretApiKey = tempKey;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matchId = "81703c95-000d-4535-b80f-1ea08ffd4bba";
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.haloapi.com");
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _secretApiKey);
                var response = await client.GetAsync($"/stats/h5/arena/matches/{matchId}");
                var stringResult = await response.Content.ReadAsStringAsync();
                return Ok(new {Text = stringResult });
            }
        }
    }
}