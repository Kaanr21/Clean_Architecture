using Serilog;

public static class SerilogConfig
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.File("Logs/Errors.txt",
                          rollingInterval: RollingInterval.Day,
                          retainedFileCountLimit: 7,
                          fileSizeLimitBytes: 10_000_000,
                          rollOnFileSizeLimit: true)
            .CreateLogger();
    }
}
