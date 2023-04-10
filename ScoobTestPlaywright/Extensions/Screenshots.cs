namespace ScoobTestPlaywright.Extensions;

public class Screenshots
{
    public static async Task TakeScreenshot(IPage page)
    {
        await page.ScreenshotAsync(new()
        {
            Path = "../../../Screenshots/screenshot.png",
        });
    }
}
