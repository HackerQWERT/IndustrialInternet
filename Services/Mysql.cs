namespace IndustrialInternet.Services;


public class Mysql
{
    private readonly Serilog.ILogger logger;

    public Mysql(Serilog.ILogger logger)
    {
        ConnectionString = $"server={Ip};port={Port};user={User};password={Password}; database={Database};";
        MySqlConnection = new MySqlConnection(ConnectionString);
        this.logger = logger;

    }

    public MySqlConnection MySqlConnection { get; set; }
    public string Port { get; set; } = "3306";
    public string Ip { get; set; } = "127.0.0.1";
    public string Database { get; set; } = "SensorDatas";
    public string User { get; set; } = "root";
    public string Password { get; set; } = "F";
    public string ConnectionString { get; }

    public async Task<int> InsertSensorData(SensorDataModel sensorDataModel)
    {
        string sqlString = @"INSERT INTO SensorData (Time,Temperature,Pressure,Vibration) VALUES (NOW(),@Temperature,@Pressure,@Vibration)";

        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, sensorDataModel);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return -1;
        }
    }
    public async Task<int> InsertTemperatureSensorLog(TemperatureSensorLogModel temperatureSensorLogModel)
    {
        string sqlString = @"INSERT INTO TemperatureSensorLog (Time,Temperature,DeviceStatus,FaultCondition) VALUES (NOW(),@Temperature,@DeviceStatus,@FaultCondition)";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, temperatureSensorLogModel);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return -1;
        }
    }

    public async Task<int> InsertPressureSensorLog(PressureSensorLogModel pressureSensorLogModel)
    {
        string sqlString = @"INSERT INTO PressureSensorLog (Time,Pressure,DeviceStatus,FaultCondition) VALUES (NOW(),@Pressure,@DeviceStatus,@FaultCondition)";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, pressureSensorLogModel);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return -1;
        }
    }


    public async Task<int> InsertVibrationSensorLog(VibrationSensorLogModel vibrationSensorLogModel)
    {
        string sqlString = @"INSERT INTO VibrationSensorLog (Time,Vibration,DeviceStatus,FaultCondition) VALUES (NOW(),@Vibration,@DeviceStatus,@FaultCondition)";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, vibrationSensorLogModel);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return -1;
        }
    }


    public async Task<List<SensorDataModel>>? QuerySensorDataBetweenTime(SensorDataTimeSpanModel sensorDataTimeSpanModel)
    {
        var sqlString = @"Select * From SensorData Where Time  BETWEEN   @StartTime AND @EndTime ";
        try
        {
            var result = await MySqlConnection.QueryAsync<SensorDataModel>(sqlString, sensorDataTimeSpanModel);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return null;
        }
    }

    public async Task<List<SensorDataModel>>? QuerySensorDataBetweenTemperature(SensorDataTemperatureSpanModel sensorDataTemperatureSpanModel)
    {
        var sqlString = @"Select * From SensorData Where Temperature BETWEEN @LowThresholdTemperature AND @HighThresholdTemperature";
        try
        {
            var result = await MySqlConnection.QueryAsync<SensorDataModel>(sqlString, sensorDataTemperatureSpanModel);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);

            return null;

        }
    }

    public async Task<List<SensorDataModel>>? QuerySensorDataBetweenPressure(SensorDataPressureSpanModel sensorDataPressureSpanModel)
    {
        var sqlString = @"Select * From SensorData Where Pressure BETWEEN @LowThresholdPressure AND @HighThresholdPressure";
        try
        {
            var result = await MySqlConnection.QueryAsync<SensorDataModel>(sqlString, sensorDataPressureSpanModel);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);

            return null;

        }
    }
    public async Task<List<SensorDataModel>>? QuerySensorDataBetweenVibration(SensorDataVibrationSpanModel sensorDataVibrationSpanModel)
    {
        var sqlString = @"Select * From SensorData Where Vibration BETWEEN @LowThresholdVibration AND @HighThresholdVibration";
        try
        {
            var result = await MySqlConnection.QueryAsync<SensorDataModel>(sqlString, sensorDataVibrationSpanModel);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return null;
        }
    }

    public async Task<List<VibrationSensorLogModel>> QueryVibrationSensorLogs()
    {
        var sqlString = @"Select * From VibrationSensorLog";
        try
        {
            var result = await MySqlConnection.QueryAsync<VibrationSensorLogModel>(sqlString);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return null;
        }
    }

    public async Task<List<PressureSensorLogModel>> QueryPressureSensorLogs()
    {
        var sqlString = @"Select * From PressureSensorLog";
        try
        {
            var result = await MySqlConnection.QueryAsync<PressureSensorLogModel>(sqlString);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return null;
        }
    }
    public async Task<List<TemperatureSensorLogModel>> QueryTemperatureSensorLogs()
    {
        var sqlString = @"Select * From TemperatureSensorLog";
        try
        {
            var result = await MySqlConnection.QueryAsync<TemperatureSensorLogModel>(sqlString);
            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
            return null;
        }
    }
}