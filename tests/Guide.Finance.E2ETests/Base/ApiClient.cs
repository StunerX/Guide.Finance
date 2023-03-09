namespace Guide.Finance.E2ETests.Base;

public class ApiClient
{
    private readonly HttpClient _client;

    public ApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await _client.GetAsync(url);
    }
    
    public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
    {
        return await _client.PostAsync(url, content);
    }
}