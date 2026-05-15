using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private static string _defaultStats = @"{
            ""public_repos"": 3,
            ""followers"": 1,
            ""following"": 1,
            ""created_at"": ""2025-07-20T00:42:09Z""
        }";

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
                if (IsValidGitStats(cachedData))
                {
                    return Ok(cachedData);
                }
                else
                {
                    _cache.Remove("gitStats");
                } 
            }
            for (int i = 0; i < 3; i++)
            {
                string data = await FetchFromGitHub();
                if (IsValidGitStats(data))
                {
                    _cache.Set("gitStats", data, TimeSpan.FromHours(24));
                    _defaultStats = data;
                    return Ok(data);
                }
            }
            return Ok(_defaultStats);
        }

        private async Task<string> FetchFromGitHub()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "colorTextBackend");
            var response = await client.GetAsync(gitUsername);
            return await response.Content.ReadAsStringAsync();
        }

        private bool IsValidGitStats(string data)
        {
            return data.Contains("\"login\":\"AnsleySoftware\"")
                && data.Contains("\"user_view_type\":\"public\"");
        }
    }
}
