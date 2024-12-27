namespace background_job_timer_vs_while.Services;

public class BackgroundJobWithTimer : BackgroundService
{
    private int instanceCount = 0;
    private Timer? timer;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        timer = new Timer(CustomTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));

        return Task.CompletedTask;
    }

    private async void CustomTask(object? state)
    {
        Interlocked.Add(ref instanceCount, 1);

        await Task.Delay(TimeSpan.FromSeconds(10));

        Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} - BackgroundJobWithTimer instanceCount: {instanceCount}");

        Interlocked.Add(ref instanceCount, -1);
    }

    public override void Dispose()
    {
        timer?.Dispose();
        base.Dispose();
    }
}