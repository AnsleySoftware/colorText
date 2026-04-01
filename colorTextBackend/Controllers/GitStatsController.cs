using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace colorTextBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitStatsController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string Username = "AnsleySoftware";
        private readonly string gitUsername = $"https://api.github.com/users/{Username}";
        private readonly string gitURL = $"https://api.github.com/users/{Username}/repos";
        public GitStatsController(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("gitstats")]
        public async Task<IActionResult> GetGitStats()
        {
            if (_cache.TryGetValue("gitStats", out string cachedData))
            {
                return Ok(cachedData);
            }

            HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "colorTextBackend");
            var response = await client.GetAsync(gitUsername);
            string data = await response.Content.ReadAsStringAsync();
            _cache.Set("gitStats", data, TimeSpan.FromHours(24));
            return Ok(data);
        }
    }
}
