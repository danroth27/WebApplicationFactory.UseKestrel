using BlazorWebApp.Tests.WAF;
using Microsoft.Playwright.Xunit;

namespace Test;

public class WeatherPageTests : PageTest
{
    [Fact]
    public async Task Page_LoadsSuccessfully()
    {
        using var waf = new BlazorWebAppFactory();

        // var httpClient = waf.CreateClient();

        waf.UseKestrel();
        waf.StartServer();

        var weatherPagePath = waf.ClientOptions.BaseAddress.ToString() + "weather";
        var response = await Page.GotoAsync(weatherPagePath);
        var content = await response!.TextAsync();

        await Expect(Page).ToHaveTitleAsync("Weather");
        Assert.Contains(TestWeatherService.TestWeatherSummary, content);
    }
}
