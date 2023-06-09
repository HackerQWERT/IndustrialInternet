namespace IndustrialInternet.Services;

public class SignalR
{

    public static class MonitoringSoftwareHubMethod
    {

        public static string ReceiveTemperatureSensorLogFromDeviceStatusManagementView { get; } = "ReceiveTemperatureSensorLogFromDeviceStatusManagementView";
        public static string ReceivePressureSensorLogFromDeviceStatusManagementView { get; } = "ReceivePressureSensorLogFromDeviceStatusManagementView";
        public static string ReceiveVibrationSensorLogFromDeviceStatusManagementView { get; } = "ReceiveVibrationSensorLogFromDeviceStatusManagementView";


        public static string ReceiveVibrationRequestFromEquipmentMaintenanceRecordsView { get; } = "ReceiveVibrationRequestFromEquipmentMaintenanceRecordsView";
        public static string ReceivePressureRequestFromEquipmentMaintenanceRecordsView { get; } = "ReceivePressureRequestFromEquipmentMaintenanceRecordsView";
        public static string ReceiveTemperatureRequestFromEquipmentMaintenanceRecordsView { get; } = "ReceiveTemperatureRequestFromEquipmentMaintenanceRecordsView";


    }

    public static class SensorHubMethod
    {

        public static string ReceiveSensorData { get; } = "ReceiveSensorData";

    }


    public static class MonitoringSoftwareMethod
    {
        public static string RealTimeDetectionViewReceiveSensorData { get; } = "RealTimeDetectionViewReceiveSensorData";

        public static string DeviceStatusManagementViewCheckIfTheThresholdIsExceeded { get; } = "DeviceStatusManagementViewCheckIfTheThresholdIsExceeded";
       
        public static string EquipmentMaintenanceRecordsViewReceiveVibrationSensorLogs { get; } = "EquipmentMaintenanceRecordsViewReceiveVibrationSensorLogs";
        public static string EquipmentMaintenanceRecordsViewReceivePressureSensorLogs { get; } = "EquipmentMaintenanceRecordsViewReceivePressureSensorLogs";
        public static string EquipmentMaintenanceRecordsViewReceiveTemperatureSensorLogs { get; } = "EquipmentMaintenanceRecordsViewReceiveTemperatureSensorLogs";


    }

    public static class SensorMethod
    {


    }
}

