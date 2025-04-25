﻿using Microsoft.Playwright.Xunit;

namespace Test;

public class WeatherPageTests : PageTest
{
    [Fact]
    public async Task Page_LoadsSuccessfully()
    {
        using var waf = new BlazorWebAppFactory();

        // 
        // _ = waf.CreateClient();

        waf.UseKestrel();
        waf.StartServer();

        await Task.Delay(30000);
        var privacyPagePath = waf.ClientOptions.BaseAddress.ToString() + "weather";
        var response = await Page.GotoAsync(privacyPagePath);
        var content = await response!.TextAsync();

        await Expect(Page).ToHaveTitleAsync("Weather");
        Assert.Contains(TestWeatherService.TestWeatherSummary, content);
    }
}
