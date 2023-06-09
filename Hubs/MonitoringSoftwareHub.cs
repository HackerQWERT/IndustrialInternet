namespace IndustrialInternet.Hubs;

public class MonitoringSoftwareHub : Hub
{
    private readonly SignalR signalR;
    private readonly Mysql mysql;
    private readonly Serilog.ILogger logger;

    public MonitoringSoftwareHub(SignalR signalR, Mysql mysql, Serilog.ILogger logger)
    {
        this.signalR = signalR;
        this.mysql = mysql;
        this.logger = logger;
    }
    //插入温度传感器日志
    public async Task ReceiveTemperatureSensorLogFromDeviceStatusManagementView(TemperatureSensorLogModel temperatureSensorLogModel)
    {
        await mysql.InsertTemperatureSensorLog(temperatureSensorLogModel);

    }
    //插入压力传感器日志
    public async Task ReceivePressureSensorLogFromDeviceStatusManagementView(PressureSensorLogModel pressureSensorLogModel)
    {
        await mysql.InsertPressureSensorLog(pressureSensorLogModel);

    }
    //插入振动传感器日志
    public async Task ReceiveVibrationSensorLogFromDeviceStatusManagementView(VibrationSensorLogModel vibrationSensorLogModel)
    {
        await mysql.InsertVibrationSensorLog(vibrationSensorLogModel);

    }

    //接受并发送自设备状态管理界面的振动传感器日志
    public async Task ReceiveVibrationRequestFromEquipmentMaintenanceRecordsView(int a)
    {
        if (a != 1)
            return;
        var vibrationSensorLogModels = await mysql.QueryVibrationSensorLogs();
        await Clients.Caller.SendAsync(SignalR.MonitoringSoftwareMethod.EquipmentMaintenanceRecordsViewReceiveVibrationSensorLogs, vibrationSensorLogModels);
    }
    //接受并发送自设备状态管理界面的压力传感器日志
    public async Task ReceivePressureRequestFromEquipmentMaintenanceRecordsView(int a)
    {
        if (a != 1)
            return;
        var pressureSensorLogModels = await mysql.QueryPressureSensorLogs();
        await Clients.Caller.SendAsync(SignalR.MonitoringSoftwareMethod.EquipmentMaintenanceRecordsViewReceivePressureSensorLogs, pressureSensorLogModels);
    }

    //接受并发送自设备状态管理界面的温度传感器日志
    public async Task ReceiveTemperatureRequestFromEquipmentMaintenanceRecordsView(int a)
    {
        if (a != 1)
            return;
        var temperatureSensorLogModels = await mysql.QueryTemperatureSensorLogs();
        await Clients.Caller.SendAsync(SignalR.MonitoringSoftwareMethod.EquipmentMaintenanceRecordsViewReceiveTemperatureSensorLogs, temperatureSensorLogModels);
    }


    public async override Task OnConnectedAsync()
    {
        logger.Information("One Client Connected to MonitoringSoftwareHub:\t" + Context.ConnectionId);
        await Task.Delay(100);
    }


    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.Warning("One Client Disconnected from MonitoringSoftwareHub:\t" + Context.ConnectionId + "\nReason:\t" + exception);

        await Task.Delay(100);
    }


}