namespace background_job_timer_vs_while.Services;

public class BackgroundJobWithWhile : BackgroundService
{
    private int instanceCount = 0;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            instanceCount++;

            // Do something
            await Task.Delay(TimeSpan.FromSeconds(10));

            Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")} - BackgroundJobWithWhile instanceCount: {instanceCount}");

            instanceCount--;

            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }
    }
}
