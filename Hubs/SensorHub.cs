namespace IndustrialInternet.Hubs;

public class SensorHub : Hub
{
    private readonly SignalR signalR;
    private readonly Mysql mysql;
    private readonly Serilog.ILogger logger;

    public SensorHub(SignalR signalR, Mysql mysql, Serilog.ILogger logger)
    {
        this.signalR = signalR;
        this.mysql = mysql;
        this.logger = logger;
    }



    public async Task ReceiveSensorData(SensorDataModel sensorDataModel)
    {

        // 处理传感器数据


        // 插入数据库
        await mysql.InsertSensorData(sensorDataModel);

        // 将数据传递给MonitoringSoftwareHub
        var detectionHub = Context.GetHttpContext().RequestServices.GetRequiredService<IHubContext<MonitoringSoftwareHub>>();
        await detectionHub.Clients.All.SendAsync(SignalR.MonitoringSoftwareMethod.RealTimeDetectionViewReceiveSensorData, sensorDataModel);
        await detectionHub.Clients.All.SendAsync(SignalR.MonitoringSoftwareMethod.DeviceStatusManagementViewCheckIfTheThresholdIsExceeded, sensorDataModel);

    }

    public async override Task OnConnectedAsync()
    {
        logger.Information("One Client Connected to SensorHub:\t" + Context.ConnectionId);
        await Task.Delay(100);
    }


    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.Warning("One Client Disconnected from SensorHub:\t" + Context.ConnectionId + "\nReason:\t" + exception);
        await Task.Delay(100);
    }

}