using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClient.Controllers;

[ApiController]
[Route("[controller]")]
public class HttpClientController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public HttpClientController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet(Name = "TestHttpClient")]
    public async Task TestHttpClient()
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var result = await client.GetAsync("/mail/u/0/#inbox");
        Console.WriteLine(result.StatusCode);

    }
}
