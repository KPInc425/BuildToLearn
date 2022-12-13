var serviceProvider = new ServiceCollection()
    .AddLogging(options => 
    {
        options.AddConsole();
        options.SetMinimumLevel(LogLevel.Debug);
    })
    .AddSingleton<INextNumberGenerator, NextNumberGenerator>()
    .AddSingleton<IUserGuessProcessor, UserGuessProcessor>()
    .AddSingleton<App>()
    .BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogDebug("Starting application");

//do the actual work here
var app = serviceProvider.GetService<App>();
app.RunGame();

logger.LogDebug("All done!");

