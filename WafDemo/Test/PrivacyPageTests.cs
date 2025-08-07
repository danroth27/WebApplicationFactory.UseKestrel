using BlazorWebApp.Tests.WAF;
using Microsoft.Playwright.Xunit;
using Test.Services;

namespace Test;

public class PrivacyPageTests : PageTest
{
    [Fact]
    public async Task Page_LoadsSuccessfully()
    {
        using var waf = new RazorWebFactory();

        // var httpClient = waf.CreateClient();

        waf.UseKestrel();
        waf.StartServer();

        var privacyPagePath = waf.ClientOptions.BaseAddress.ToString() + "Privacy";

        var response = await Page.GotoAsync(privacyPagePath);
        var content = await response!.TextAsync();

        await Expect(Page).ToHaveTitleAsync("Privacy Policy - RazorWeb");
        Assert.Contains(TestDataService.TestData, content);
    }
}