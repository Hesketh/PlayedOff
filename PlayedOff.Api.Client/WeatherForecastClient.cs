namespace PlayedOff.Api.Client;

public sealed class WeatherForecastClient : Client
{
    public WeatherForecastClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<WeatherForecast[]> GetAsync()
    {
        return await GetAsync<WeatherForecast[]>("WeatherForecast");
    }
}