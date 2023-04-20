namespace ScoobTestPlaywright.Extensions;

public class TraceViewer : PageTest
{
    public TraceViewer(string testName)
    {
        Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = testName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    public async Task StopTrace(string testName)
    {
        await Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = $"../../../Traces/{testName}.zip"
        });
    }
}
