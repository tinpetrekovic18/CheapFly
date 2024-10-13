using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


public class AmadeusFlight
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiSecret;

    public AmadeusFlight(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        _apiKey = configuration["AmadeusApiKey"];
        _apiSecret = configuration["AmadeusApiSecret"];
    }

    public async Task<string> GetFlightOffers(string departureAirport, string destinationAirport, string departureDate, string returnDate, int passengers, string currency)
    {
        // Prvo moramo dobiti token za autentifikaciju
        var token = await GetAccessToken(_apiKey, _apiSecret);

        // Pripremamo zahtjev za pretragu letova
        var requestUri = $"https://test.api.amadeus.com/v2/shopping/flight-offers?originLocationCode={departureAirport}&destinationLocationCode={destinationAirport}&departureDate={departureDate}&returnDate={returnDate}&adults={passengers}&currencyCode={currency}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;  // Vraćamo odgovor kao JSON
        }
        return null;
    }

    private async Task<string> GetAccessToken(string apiKey, string apiSecret)
    {
        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "https://test.api.amadeus.com/v1/security/oauth2/token");
        tokenRequest.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", apiKey),
            new KeyValuePair<string, string>("client_secret", apiSecret)
        });

        var response = await _httpClient.SendAsync(tokenRequest);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(content);
            return tokenResponse.access_token;
        }

        return null;
    }
}
