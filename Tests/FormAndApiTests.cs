using System.Net;
using System.Text.Json;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace DemoQa.Playwright.Tests;

public class FormAndApiTests : PageTest
{
    [Test]
    public async Task ValidatesTextBoxFormAndApiResponse()
    {
        var formData = new
        {
            FullName = "John Doe",
            Email = "john.doe@example.com",
            CurrentAddress = "123 Main St",
            PermanentAddress = "456 Secondary St"
        };

        await TestContext.Out.WriteLineAsync("Fill and submit the DemoQA text box form");

        await Page.GotoAsync("https://demoqa.com/text-box");
        await Page.Locator("#userName").FillAsync(formData.FullName);
        await Page.Locator("#userEmail").FillAsync(formData.Email);
        await Page.Locator("#currentAddress").FillAsync(formData.CurrentAddress);
        await Page.Locator("#permanentAddress").FillAsync(formData.PermanentAddress);
        await Page.Locator("#submit").ClickAsync();

        await TestContext.Out.WriteLineAsync("Validate submitted values in the output section");

        await Expect(Page.Locator("#output")).ToBeVisibleAsync();
        await Expect(Page.Locator("#name")).ToContainTextAsync(formData.FullName);
        await Expect(Page.Locator("#email")).ToContainTextAsync(formData.Email);
        await Expect(Page.Locator("p#currentAddress")).ToContainTextAsync(formData.CurrentAddress);
        await Expect(Page.Locator("p#permanentAddress")).ToContainTextAsync(formData.PermanentAddress);

        await TestContext.Out.WriteLineAsync("Validate public API response");

        var apiRequestContext = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = "https://jsonplaceholder.typicode.com"
        });

        var response = await apiRequestContext.GetAsync("/posts/1");

        Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));

        using var document = JsonDocument.Parse(await response.TextAsync());
        var root = document.RootElement;

        Assert.That(root.TryGetProperty("userId", out var userId), Is.True);
        Assert.That(userId.ValueKind, Is.EqualTo(JsonValueKind.Number));
        Assert.That(root.GetProperty("id").GetInt32(), Is.EqualTo(1));
        Assert.That(root.GetProperty("title").ValueKind, Is.EqualTo(JsonValueKind.String));
        Assert.That(root.GetProperty("body").ValueKind, Is.EqualTo(JsonValueKind.String));

        await apiRequestContext.DisposeAsync();

        TestContext.Out.WriteLine("All tests passed.");
    }
}