var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<SignalR>();
builder.Services.AddSingleton<Mysql>();

var logger = new LoggerConfiguration()
    .WriteTo.Console() // 将日志输出到控制台
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // 将日志写入到文件
    .CreateLogger();

builder.Services.AddSingleton<Serilog.ILogger>(logger);

builder.Services.AddSignalR().AddHubOptions<MonitoringSoftwareHub>(options =>
{
    options.EnableDetailedErrors = true;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHub<MonitoringSoftwareHub>("/MonitoringSoftwareHub");
app.MapHub<SensorHub>("/SensorHub");


app.Run();
