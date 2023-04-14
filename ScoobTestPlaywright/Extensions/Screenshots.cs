namespace ScoobTestPlaywright.Extensions;

public class Screenshots
{
    public static async Task TakeScreenshot(IPage page)
    {
        var date = DateTime.Now.ToString("dd-MM-yyyy h_mm_ss_tt");
        var guid = Guid.NewGuid().ToString();

        await page.ScreenshotAsync(new()
        {
            Path = $"../../../Screenshots/Screenshot - {date} ({guid}).png",
        });
    }

    public static async Task SpecificScreenshot(IPage page, string locator)
    {
        var date = DateTime.Now.ToString("dd-MM-yyyy h_mm_tt");
        var guid = Guid.NewGuid().ToString();
        await page.Locator(locator).ScreenshotAsync(new()
        {
            Path = $"../../../Screenshots/Specific_Screenshot - {date} ({guid}).png",
        });
    }
}
