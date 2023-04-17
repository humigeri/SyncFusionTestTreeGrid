namespace SyncFusionTestWeather;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate, bool dataSourceWithEmptyColumn)
    {
        return Task.FromResult(Enumerable.Range(1, 1000).Select(index => new WeatherForecast
        {
            Day = startDate.AddDays(index).Year * 10000 + startDate.AddDays(index).Month * 100 + startDate.AddDays(index).Day,
            Date = dataSourceWithEmptyColumn ? null : startDate.AddDays(index),
            Month = startDate.AddDays(index).Day == 1 ? null : startDate.AddDays(index).Year * 10000 + startDate.AddDays(index).Month * 100 + 1,
            //Month = index / 7,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = dataSourceWithEmptyColumn ? null : Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList());
    }
}
